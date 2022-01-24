# -*- coding: UTF-8 -*-

# 命令台
from WinIO.Controls import CommandWindow
from WinIO.Core import PyDelegateConverter as PyDel

from WinIO2.Controls import TreeItem
from WinIO2.Controls.IBaseControls.OutputControl import OutputControl


class CommandWindow(CommandWindow):

	ItemPool = {}

	def __init__(self):
		self.output = OutputControl(self.Output)

	@classmethod
	def add_item(cls, item, sort_fun=None):
		if sort_fun:
			sort_string = sort_fun(item)
			pitem = cls.ItemPool.get(sort_string)
			if not pitem:
				pitem = TreeItem.TreeItem(sort_string)
				cls.ItemPool[sort_string] = pitem
				CommandWindow.Items.Add(pitem)
			pitem.add(item)
		else:
			CommandWindow.Items.Add(item)

	@classmethod
	def remove_item(cls, item, sort_fun=None):
		if sort_fun:
			sort_string = sort_fun(item)
			pitem = cls.ItemPool.get(sort_string)
			if not pitem:
				# 如果移除的时候没有找到到父亲的话
				# 说明这个sortfun可能有问题, 这里就直接不操作了
				return
			pitem.remove(item)
			if pitem.Children.Count == 0:
				CommandWindow.Items.Remove(pitem)
		else:
			CommandWindow.Items.Remove(item)

	def write(self, s):
		self.output.write(s)

	def append(self, s):
		self.output.append(s)

	def append_line(self, s):
		self.output.append_line(s)