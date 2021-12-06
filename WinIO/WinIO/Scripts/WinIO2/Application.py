# -*- coding: UTF-8 -*-

from WinIO import MainProgram


class ToolTipIcon:
	Null = 0
	Info = 1
	Warning = 2
	Error = 3


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

	def eznotify(self, title, context):
		self.app.Notification(title, context)

	def notify(self, title, context, time=1000, toolicon=ToolTipIcon.Info):
		self.app.Notification(time, title, context, toolicon)


app = Application()
def get_app():
	return app


