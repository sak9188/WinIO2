# -*- coding: UTF-8 -*-


from WinIO.Models import TreeItemView


class TreeItem(TreeItemView):

	def __init__(self, name):
		self.name = name
		self.childs = []

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

	def selected_items(self):
		select = []
		for child in self.childs:
			if child.is_checked:
				select.append(child)
		return select
