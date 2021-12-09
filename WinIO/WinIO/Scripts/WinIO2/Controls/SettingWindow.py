# -*- coding: UTF-8 -*-

from WinIO2.Controls.BlankWindow import BlankWindow


class SettingWindow(BlankWindow):

	def __init__(self, title):
		self.title = title
		self.height = 400
		self.width = 400

	def load_configure(self, title):
		pass
		