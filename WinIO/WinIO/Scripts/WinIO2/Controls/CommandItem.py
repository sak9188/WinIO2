# -*- coding: UTF-8 -*-

from WinIO.Models import CommandView
from WinIO.Core import PyDelegateConverter as PyDel

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
		self.command = value