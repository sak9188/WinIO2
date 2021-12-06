# -*- coding: UTF-8 -*-

from System.Collections import ArrayList

class List(ArrayList):

	def __init__(self, data_list):
		for item in data_list:
			self.Add(item)

	def append(self, data):
		self.Add(data)
	