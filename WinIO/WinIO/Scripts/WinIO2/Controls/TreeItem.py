# -*- coding: UTF-8 -*-


from WinIO.Models import TreeItemView


class TreeItem(TreeItemView):

	def __init__(self, name):
		self.name = name

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
		self.Children.Add(child)

	def reomve(self, child):
		self.Children.remove(child)
