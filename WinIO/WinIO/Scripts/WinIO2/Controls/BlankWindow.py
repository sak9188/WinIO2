# -*- coding: UTF-8 -*-
from WinIO.FluentWPF import AcrylicWindow


class AcrylicWindowStyle(object):
	Normal = 0
	NoIcon = 1
	Null = 2


class BlankWindow(AcrylicWindow):

	@property
	def title(self):
		return self.Title

	@title.setter
	def title(self, value):
		self.Title = value

	@property
	def height(self):
		return self.Height

	@height.setter
	def height(self, value):
		self.Height = value

	@property
	def width(self):
		return self.Width

	@width.setter
	def width(self, value):
		self.Width = value
		
	def set_window_style(self, style):
		self.AcrylicWindowStyle = style