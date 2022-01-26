# -*- coding: UTF-8 -*-

# UI事件

class UIEvent(object):

	def __init__(self, name):
		self.name = name
		self.fun_dict = {}
		self.lambda_set = set()
		self.callhook = None
		self._event_args = UIEventArg(name)
	
	def set_callhook(self, fun):
		self.callhook = fun

	def __call__(self, *args, **kwds):
		# if not self.callhook:
		for key, fun in self.fun_dict.iteritems():
			try:
				fun(self._event_args, *args, **kwds)
			except Exception as e:
				print "UI事件:%s 回调发生错误 函数名: %s, 错误: %s" % (self.name, key, e)

	def __add__(self, rhs):
		key = rhs.__name__
		if key == '<lambda>':
			key = hash(rhs)
			self.lambda_set.add(rhs)
		self.fun_dict[key] = rhs
		return self
	
	def __sub__(self, rhs):
		key = rhs.__name__
		if key == '<lambda>':
			# 对于匿名函数暂时是这个处理方式
			key = hash(rhs)
			self.lambda_set.remove(rhs)
		if key in self.fun_dict:
			self.fun_dict.pop(key)
		return self


class UIEventArg(object):

	def __init__(self, name, **kwds):
		self.name = name
		self.kargs = kwds

	def __getitem__(self, rhs):
		return self.kargs.get(rhs)

	def __setitem__(self, key, value):
		self.kargs[key] = value
	


