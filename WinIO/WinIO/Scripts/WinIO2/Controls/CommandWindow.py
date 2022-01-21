# -*- coding: UTF-8 -*-

# 命令台

from WinIO.Controls import CommandWindow
from WinIO.Core import PyDelegateConverter as PyDel

from WinIO2.Controls.IBaseControls.OutputControl import OutputControl
from WinIO2.Core.FunctionTool import FunctionChain

class CommandWindow(CommandWindow, OutputControl):

	def __init__(self):
		pass

	@classmethod
	def add_item(self, item):
		CommandWindow.Items.Add(item)

	@classmethod
	def remove_item(self, item):
		CommandWindow.Items.Remove(item)