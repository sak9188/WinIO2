# -*- coding: UTF-8 -*-


from WinIO.Models import TreeItemView
from WinIO.Core import PyDelegateConverter as PyDel

from WinIO2.Core.FunctionTool import FunctionChain

class TreeItem(TreeItemView):

	def __init__(self, name):
		self.name = name

	@property
	def name(self):
		return self.Name

	@name.setter
	def name(self):
		return self.Name


