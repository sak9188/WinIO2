# -*- coding: UTF-8 -*-
from signal import SIG_BLOCK
from WinIO2.Core import ThreadHelper


App = ThreadHelper.App

class ConfigureMeta(type):
	ConfigDict = {}
	Discribers = {}

	def __init__(self, name, bases, attr_dict):
		for key, item in self.ConfigDict.iteritems():
			self.Discribers[key] = ConfigDiscriber(*item, key=key)	

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

	def get_discribers(self):
		return self.Discribers


class ConfigDiscriber(object):
	RegControl = {}

	def __init__(self, tip_string, control, sub_type=None, key=None):
		self.text = tip_string
		self.key = key
		self.sub_type = sub_type
		self.is_resource = False
		self.callback = set()

		# 如果这里是空的话， 说明要从资源列表里获取资源
		if control is None:
			self.is_resource = True
			control = App.TryFindResource(key)
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
	def reg_control(cls, control, fun):
		cls.RegControl[control] = fun

	def reg_observer(self, fun):
		self.callback.add(fun)

	def __notify(self):
		for fun in self.callback:
			fun(self)
	
	def convert_row(self, row):
		# 将Row转化成对应的配置行
		fun = self.RegControl.get(type(self.control))
		if not fun:
			return
		fun(row, self)


class StringType(object):
	Normal = 0
	Dialog = 1


from System import Double
from System.Windows.Controls import Label, TextBlock
from System.Windows.Media import FontFamily

from WinIO.Controls import FontComboBox, AdvanceTextBox

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


def __input_string(row, disc):
	pass