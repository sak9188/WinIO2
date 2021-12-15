# -*- coding: UTF-8 -*-
from WinIO2.Core import ThreadHelper

from collections import OrderedDict
import pickle

App = ThreadHelper.App

class ConfigureMeta(type):

	ConfigBinName = "winio_config.bin"

	ConfigDict = OrderedDict() 
	Discribers = OrderedDict()

	ConfigSerialDict = {}

	def __init__(self, name, bases, attr_dict):
		if not ConfigureMeta.ConfigSerialDict:
			ConfigureMeta.ConfigSerialDict = ConfigureMeta.load_config()
		serial_config = ConfigureMeta.ConfigSerialDict.get(name, {})
		for key, item in self.ConfigDict.iteritems():
			serial = serial_config.get(key)
			if serial:
				desc = ConfigDiscriber(item[0], *serial)
			else:
				desc = ConfigDiscriber(*item, key=key)
			self.Discribers[key] = desc	
		ConfigureMeta.ConfigSerialDict[name] = self

	def __getitem__(self, name):
		discriber = self.Discribers.get(name)

		if discriber: return discriber.control
		else: return None

	def __setitem__(self, key, value):
		# 每次添加 item
		discriber = self.Discribers.get(key)
		if not discriber:
			try:
				tip, control = value
				discriber = (tip, control, key)
				self.Discribers[key] = discriber
			except:
				print "添加设置配置错误"
			return
		# 如果存在描述器的话, 那个Value必然是对应的控件
		discriber.control = value
		self.Discribers[key] = discriber

	def get_discriber(self, name):
		return self.Discribers.get(name)

	def get_discribers(self):
		return self.Discribers

	@classmethod
	def save_config(self):
		big_config = {}
		for name, serial_config in self.ConfigSerialDict.iteritems():
			kvd = {}
			discribers = serial_config.Discribers
			for key, disc in discribers.iteritems():
				ser_obj = disc.get_serialize()
				kvd[key] = ser_obj
			big_config[name] = kvd

		# 这里要存储到文件里
		with open(ConfigureMeta.ConfigBinName, "wb+") as f:
			pickle.dump(kvd, f)

	@classmethod
	def load_config(self):
		kvd = {}
		try:
			with open(ConfigureMeta.ConfigBinName, "rb") as f:
				kvd = pickle.load(f)
		except:
			# 这里一般都是没有这个文件， 直接不处理就得了
			pass
		return kvd


class ConfigDiscriber(object):
	RegControl = {}
	RegSerialize = {}

	def __init__(self, tip_string, control, sub_type=None, key=None):
		self.text = tip_string
		self.key = key
		self.real_type = type(control)
		self.sub_type = sub_type
		self.is_resource = False
		self.callback = set()
		self.serial = None

		# 如果这里是空的话， 说明要从资源列表里获取资源
		if control is None:
			self.is_resource = True
			control = App.TryFindResource(key)
			self.real_type = type(control)
		self._control = control

	@property
	def control(self):
		return self._control

	@control.setter
	def control(self, value):
		self._control = value
		if self.is_resource:
			App.Resources[self.key] = value
		# 这里要进行一个通知
		self.__notify()

	@classmethod
	def reg_control(cls, control, fun, sub_type=None):
		if not sub_type:
			cls.RegControl[control] = fun
		else:
			cls.RegControl[control, sub_type] = fun

	@classmethod
	def reg_serialize_fun(cls, control, serfun, deserfun):
		cls.RegSerialize[control] = (serfun, deserfun)

	def get_serialize(self):
		if self.serial:
			return self.serial
		servalue = self.RegSerialize.get(self)
		if servalue:
			ser_fun, _ = servalue
			serial = ser_fun(self.control)
		else:
			serial = self.control
		self.serial = serial
		return serial, self.sub_type, self.key

	@classmethod
	def get_deserialize(self, obj):
		_, deser = self.RegSerialize.get(self)
		deser_obj = deser(obj)
		return deser_obj
	
	def reg_observer(self, fun):
		self.callback.add(fun)

	def __notify(self):
		for fun in self.callback:
			fun(self)
	
	def convert_row(self, row):
		# 将Row转化成对应的配置行
		if self.sub_type:
			fun = self.RegControl.get((self.real_type, self.sub_type))	
		else:
			fun = self.RegControl.get(self.real_type)
		if not fun:
			return
		fun(row, self)


from System import Double
from System.Windows.Controls import Label, TextBlock
from System.Windows.Media import FontFamily

from WinIO.Controls import FontComboBox, AdvanceTextBox, TextBoxDialog


# 下面是序列化的创建(因为C#对象不能直接被Python给序列化，又因为控件并不是都需要提供一个可序列化)
def _ser_fontfamily(control):
	return control.Source


def _deser_fontfamily(obj):
	return FontFamily(obj)


ConfigDiscriber.reg_serialize_fun(FontFamily, _ser_fontfamily, _deser_fontfamily)


# 下面是控件的创建
class StringType(object):
	Normal = 0
	Dialog = 1


def __font_family(row, disc):
	lab = Label()
	font_combo = FontComboBox(disc)
	text_block = TextBlock()
	lab.Content = text_block
	row.Children.Add(lab)
	row.Children.Add(font_combo)
	
	lab.Style = App.TryFindResource("BaseSettingLabel")
	text_block.Text = disc.text
	text_block.Style = App.TryFindResource("BaseTextBlockStyle")

ConfigDiscriber.reg_control(FontFamily, __font_family)


def __input_nummber(row, disc):
	lab = Label()
	input_number = AdvanceTextBox(disc, AdvanceTextBox.EInputType.eInteger) 
	text_block = TextBlock()
	lab.Content = text_block
	row.Children.Add(lab)
	row.Children.Add(input_number)
	
	lab.Style = App.TryFindResource("BaseSettingLabel")
	text_block.Text = disc.text
	text_block.Style = App.TryFindResource("BaseTextBlockStyle")

ConfigDiscriber.reg_control(Double, __input_nummber)
ConfigDiscriber.reg_control(float, __input_nummber)


def __input_string_dialog(row, disc):
	lab = Label()
	dialog = TextBoxDialog(disc) 
	text_block = TextBlock()
	lab.Content = text_block
	row.Children.Add(lab)
	row.Children.Add(dialog)

	lab.Style = App.TryFindResource("BaseSettingLabel")
	text_block.Text = disc.text
	text_block.Style = App.TryFindResource("BaseTextBlockStyle")

# 对于DialogString的注册
ConfigDiscriber.reg_control(str, __input_string_dialog, StringType.Dialog)