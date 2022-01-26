# -*- coding: UTF-8 -*-


from WinIO.Models import TreeItemView


class TreeItem(TreeItemView):

	def __init__(self, name):
		self.name = name
		self.childs = []
		self.key = 0

	@property
	def name(self):
		return self.Name

	@name.setter
	def name(self, value):
		self.Name = value

	@property
	def is_checked(self):
		return self.IsChecked

	@is_checked.setter
	def is_checked(self, value):
		self.IsChecked = value

	def add(self, child):
		self.Add(child)
		self.childs.append(child)

	def reomve(self, child):
		self.Remove(child)
		self.childs.remove(child)

	def copy(self):
		item = TreeItem(self.name)
		item.key = self.key
		for child in self.childs:
			item.add(child.copy())
		return item

	def selected_items(self):
		select = []
		for child in self.childs:
			if child.is_checked:
				select.append(child)
		return select
