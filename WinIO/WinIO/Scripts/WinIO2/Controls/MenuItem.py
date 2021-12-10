# -*- coding: UTF-8 -*-

from WinIO.Models import MenuItemView
from WinIO.Core import PyDelegateConverter as PyDel

from WinIO2.Core.FunctionTool import FunctionChain

class MenuItem(MenuItemView):

	def __init__(self, title, icon=None, on_click=None):
		self.Icon = icon
		self.Title = title
		self.click_fun = FunctionChain()
		self.child_dict = {}
		self.Click = PyDel.ToRoutedEventHandler(self.click_fun)
		if on_click:
			self.click_fun.append(on_click)

	def add(self, menu_item):
		self.Add(menu_item)
		self.child_dict[menu_item.title] = menu_item

	def insert(self, index, menu_item):
		self.insert(index, menu_item)

	def add_range(self, menu_item_list):
		for menu_item in menu_item_list:
			self.add(menu_item)

	def find(self, title):
		return self.child_dict.get(title)
	
	@property
	def click(self):
		return self.click_fun

	@click.setter
	def click(self, value):
		self.click_fun = value

	@property
	def title(self):
		return self.Title

	@title.setter
	def title(self, value):
		self.Title = value