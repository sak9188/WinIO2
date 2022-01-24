# -*- coding: UTF-8 -*-

# 命令台

from WinIO.Controls import CommandWindow
from WinIO.Core import PyDelegateConverter as PyDel

from WinIO2.Controls.IBaseControls.OutputControl import OutputControl
from WinIO2.Core.FunctionTool import FunctionChain

class CommandWindow(CommandWindow):

	def __init__(self):
		self.output = OutputControl(self.Document)

	@classmethod
	def add_item(self, item):
		CommandWindow.Items.Add(item)

	@classmethod
	def remove_item(self, item):
		CommandWindow.Items.Remove(item)

	def write(self, s):
		self.output.write(s)

	def append(self, s):
		self.output.append(s)

	def append_line(self, s):
		self.output.append_line(s)