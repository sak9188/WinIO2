# -*- coding: UTF-8 -*-

from WinIO.Models import MenuItemView


class MenuItem(MenuItemView):

	def __init__(self, title, icon=""):
		self.Icon = icon
		self.Title = title

	def add(self, menu_item):
		self.Add(menu_item)

	def insert(self, index, menu_item):
		self.insert(index, menu_item)