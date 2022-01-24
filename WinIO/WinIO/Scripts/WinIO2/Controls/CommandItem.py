# -*- coding: UTF-8 -*-
from WinIO.Models import CommandView

from WinIO2.CodeFactory import BaseCodeFactory
from WinIO2.Core import code

class CommandItem(CommandView):

	def __init__(self, header, icon="", command=""):
		self.icon = icon
		self.header = header
		self.command = command

	@property
	def icon(self):
		return self.Icon

	@icon.setter
	def icon(self, value):
		self.Icon = value

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
		elif issubclass(value, BaseCodeFactory.BaseCodeFactory):
			# 如果这里是类型话可能要做其他的操作
			self.Command = code.get_code(value)