# -*- coding: UTF-8 -*-
import os
import subprocess

# 基本的代码工厂

class BaseCodeFactory(object):

	def __init__(self):
		self.process = None

	def __call__(self, *args, **kwds):
		# self.process = Process(target=self.code, args=args, kwargs=kwds).start()
		self.code(*args, **kwds)

	def open_process(self, name, path=None):
		# os.system("start%s/%s" % (path, name))
		subprocess.Popen("%s/%s" % (path, name), shell=False)

	def code(self):
		pass

