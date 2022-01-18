# -*- coding: UTF-8 -*-

from signal import valid_signals

from matplotlib.pyplot import vlines
from WinIO.Models import CommandView
from WinIO.Core import PyDelegateConverter as PyDel

from WinIO2.CodeFactory import BaseCodeFactory
from WinIO2.Core import code

class CommandItem(CommandView):

	def __init__(self, header, icon="", command=""):
		self.Icon = icon
		self.Header = header
		self.Command = command

	@property
	def header(self):
		return self.Header

	@header.setter
	def header(self, value):
		self.Header = value

	@property
	def command(self):
		return self.Command

	@header.setter
	def command(self, value):
		if type(value) is str:
			self.Command = value
		elif issubclass(value, BaseCodeFactory.BaseCodeFacotry) is type:
			# 如果这里是类型话可能要做其他的操作
			self.Command = code.get_view(value)