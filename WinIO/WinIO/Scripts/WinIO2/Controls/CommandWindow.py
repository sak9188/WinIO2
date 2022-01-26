# -*- coding: UTF-8 -*-

# 命令台
from WinIO.Controls import CommandWindow
from WinIO.Core import PyDelegateConverter as PyDel

from WinIO2.Controls import TreeItem
from WinIO2.Controls.IBaseControls.OutputControl import OutputControl
from WinIO2.Core.FunctionTool import FunctionChain
from WinIO2 import Application

from Tool.GameIO import GIONetWork
io = GIONetWork.get_io_select()

class CommandWindow(CommandWindow):

	ItemPool = {}
	Instances = set()

	def __init__(self):
		# 暂时先屏蔽这个功能
		# self.output = OutputControl(self.Output)
		self.click_exebutton = FunctionChain()
		self.click_exebutton += self.after_click_exebutton
		self.ExeButton.Click += PyDel.ToRoutedEventHandler(self.click_exebutton)
		self.init_data()
		CommandWindow.Instances.add(self)

	def after_click_exebutton(self, sender, args):
		items = self.selected_items()
		for item in items:
			io.send(item.key, self.EditText)
		Application.get_app().notify("指令发送完毕", "指令大小: %d, 总共发送给%d个进程" % (len(self.EditText), len(items)))
		
	def selected_items(self):
		item_list = []
		for item in self.items:
			item_list += item.selected_items()
		return item_list

	def init_data(self):
		items = []
		for ori in self.ItemPool.itervalues():
			copy_item = ori.copy()
			items.append(copy_item)
			self.Items.Add(copy_item)
		self.items = items
	
	def add_instance_item(self, item, sort_string=None):
		if sort_string:
			for pitem in self.items:
				if pitem.name == sort_string:
					pitem.add(item)
					break
		else:
			self.items.append(item)
			self.Items.Add(item)

	def remove_instance_item(self, item, sort_string=None):
		if sort_string:
			for pitem in self.items:
				if pitem.name == sort_string:
					pitem.reomve(item)
					break
		else:
			self.items.remove(item)
			self.Items.Remove(item)

	@classmethod
	def add_item(cls, item, sort_fun=None):
		sort_string = None
		if sort_fun:
			sort_string = sort_fun(item)
			pitem = cls.ItemPool.get(sort_string)
			if not pitem:
				pitem = TreeItem.TreeItem(sort_string)
				cls.ItemPool[sort_string] = pitem
			pitem.add(item)
		else:
			cls.ItemPool[item.name] = item

		for ins in cls.Instances:
			ins.add_instance_item(item, sort_string)

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
				cls.ItemPool.pop(item.name)
		else:
			cls.ItemPool.pop(item.name)

		for ins in cls.Instances:
			ins.remove_instance_item(item, sort_string)

	# def write(self, s):
	# 	self.output.write(s)

	# def append(self, s):
	# 	self.output.append(s)

	# def append_line(self, s):
	# 	self.output.append_line(s)