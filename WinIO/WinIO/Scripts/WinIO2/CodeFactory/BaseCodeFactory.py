# -*- coding: UTF-8 -*-
import os
from multiprocessing import Process

# 基本的代码工厂

class BaseCodeFacotry(object):

	def __init__(self):
		self.process = None

	def __call__(self, *args, **kwds):
		# self.process = Process(target=self.code, args=args, kwargs=kwds).start()
		self.code(*args, **kwds)

	def open_process(self, name, path=None):
		os.system("%s/%s" % (path, name))

	def code(self):
		pass

