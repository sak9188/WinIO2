# -*- coding: UTF-8 -*-

from WinIO import MainProgram


class Application(object):
	__share__ = {}	
	
	def __init__(self):
		if self.__share__:
			self.__dict__ = self.__share__
			return
		self.app = MainProgram.app
		self.main_window = self.app.MainWindow

	def get_mainwindow(self):
		return self.main_window


app = Application()
def get_app():
	return app


