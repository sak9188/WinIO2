# -*- coding: UTF-8 -*-

class FunctionChain(object):

	def __init__(self, *funs):
		self.funs = list(funs)
		self.sets = set()

	def __iter__(self):
		return iter(self.funs)
	
	def append(self, fun):
		# 做一个简单的防止重复的测试， 但是这个并不能完全的防止
		# 匿名函数， 以及包装函数是无法捕捉的
		if fun in self.sets:
			return
		self.funs.append(fun)
		self.sets.add(fun)

	def __add__(self, rhs):
		self.append(rhs)
		return self

	def __sub__(self, rhs):
		if rhs in self.sets:
			self.sets.remove(rhs)
		self.funs.remove(rhs)
		return self

	def __call__(self, *args, **kwds):
		for fun in self:
			try:
				fun(*args, **kwds)
			except Exception as e:
				print "函数调用发生错误:%s, %s" % (fun.__name__, e)