# -*- coding: UTF-8 -*-

from WinIO.Models import CommandView
from WinIO.Core import PyDelegateConverter as PyDel

from WinIO2.Core.FunctionTool import FunctionChain

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