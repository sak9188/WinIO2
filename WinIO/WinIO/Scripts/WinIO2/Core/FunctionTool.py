# -*- coding: UTF-8 -*-

class FunctionChain(object):
	def __init__(self):
		self.funs = list()

	def __iter__(self):
		return iter(self.funs)
	
	def append(self, fun):
		self.funs.append(fun)

	def __call__(self, *args, **kwds):
		for fun in self:
			fun(*args, **kwds)