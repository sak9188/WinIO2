# -*- coding: UTF-8 -*-
from WinIO2.Core import ThreadHelper
from WinIO2.Core.List import List


App = ThreadHelper.App

class ConfigureMeta(type):
	ConfigDict = {}
	Discribers = {}

	def __init__(self, name, bases, attr_dict):
		for key, item in self.ConfigDict.iteritems():
			_s, _c = item
			self.Discribers[key] = ConfigDiscriber(_s, _c, key)	

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

	def __init__(self, tip_string, control, key=None):
		self.text = tip_string
		self.key = key
		self.is_resource = False

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
		if self.is_resource:
			App.Resources[self.key] = value
		self._control = value

	@classmethod
	def reg_control(cls, control, fun):
		cls.RegControl[control] = fun

	def convert_row(self, row):
		# 将Row转化成对应的配置行
		fun = self.RegControl.get(type(self.control))
		if not fun:
			return
		fun(row, self)


from System import Double
from System.Windows import Style
from System.Windows.Controls import Label, TextBlock, ComboBox
from System.Windows.Media import FontFamily


def __font_family(row, disc):
	lab = Label()
	font_combo = ComboBox()
	text_block = TextBlock()
	lab.Content = text_block
	row.Children.Add(lab)
	row.Children.Add(font_combo)
	
	lab.Style = (Style)(App.TryFindResource("BaseSettingLabel"))
	text_block.Text = disc.text
	text_block.Style = (Style)(App.TryFindResource("BaseTextBlockStyle"))

	font_combo.Style = (Style)(App.TryFindResource("ComboBoxRevealStyle"))
	font_combo.ItemsSource = List(["test_0", "tset_1", "tset_2"])

ConfigDiscriber.reg_control(FontFamily, __font_family)


def __input_nummber(row, disc):
	pass
ConfigDiscriber.reg_control(Double, __input_nummber)