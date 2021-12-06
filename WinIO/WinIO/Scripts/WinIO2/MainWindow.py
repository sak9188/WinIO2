# -*- coding: UTF-8 -*-

from WinIO2.Application import Application
from WinIO2.Controls.MenuItem import MenuItem
from WinIO2.Core.List import List

class MainWindow(object):
	__share__ = {}

	def __init__(self):
		if self.__share__:
			self.__dict__ = self.__share__
			return
		self.__dict__ = self.__share__
		self.app = Application()
		self.main_window = self.app.get_mainwindow()
		self.init_self()
	
	def init_self(self):
		menu = self.main_window.PanelMenu
		# 这里如果采用自动转换的话, 如果右边的list发生变化, 但是左边的ItemSource并不会发生变化
		# 那么这样的自动转化毫无意义, 最好的方法就是用原生C#对象, 这样就可以捕捉成员的变化
		# 1. 包装一下Menu, 但是同样不能达到马上的变化
		# 2. 直接使用C#原生对象, 可以达到原生变化, 但是API接口相关就得用C#了
		menu.ItemsSource = List([MenuItem("青龙在手"), MenuItem("test2")])

	def init_ui(self):
		pass

	def init_input(self):
		pass