# -*- coding: UTF-8 -*-


from WinIO2.Application import Application
from WinIO2.Controls.MenuItem import MenuItem

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
		menu.ItemsSource = [MenuItem("test1"), MenuItem("test2")]

	def init_ui(self):
		pass

	def init_input(self):
		pass