# -*- coding: UTF-8 -*-
from System.Windows.Controls import StackPanel, Orientation

from WinIO2.Controls.BlankWindow import BlankWindow
from WinIO2.Core import ThreadHelper

App = ThreadHelper.App
BaseSettingStackPanel = App.TryFindResource("BaseSettingStackPanel")

class SettingWindow(BlankWindow):

	def __init__(self, title):
		self.title = title
		self.Content = content = StackPanel()
		content.Style = BaseSettingStackPanel
		content.Orientation = Orientation.Vertical

		self.loaded_config = set([])

	def __add_discriber(self, disc):
		row = StackPanel()
		row.Style = BaseSettingStackPanel
		row.Orientation = Orientation.Horizontal
		disc.convert_row(row)
		self.Content.Children.Add(row)

	def load_configure(self, class_obj):
		disc_dict = class_obj.get_discribers()
		self.loaded_config.add(class_obj)

		for discriber in disc_dict.itervalues():
			self.__add_discriber(discriber)