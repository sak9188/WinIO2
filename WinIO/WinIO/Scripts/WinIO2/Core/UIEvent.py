# -*- coding: UTF-8 -*-

# UI事件

from WinIO2.Core.FunctionTool import FunctionChain


class UIEvent(object):

	def __init__(self, name):
		self.name = name
		self.funchain = FunctionChain()
		self._event_args = UIEventArg(name)

	def __call__(self, *args, **kwds):
		self.funchain(self._event_args, *args, **kwds)

	def __add__(self, rhs):
		self.funchain += rhs
	
	def __sub__(self, rhs):
		self.funchain -= rhs


class UIEventArg(object):

	def __init__(self, name, **kwds):
		self.name = name
		self.kargs = kwds

	def __get__(self, rhs):
		pass

	


