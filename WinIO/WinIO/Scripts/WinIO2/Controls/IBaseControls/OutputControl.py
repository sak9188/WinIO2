# -*- coding: UTF-8 -*-

import heapq
import StringIO

from WinIO2.Config.ColorBrush import ColorConfigure
from WinIO2.Core import ThreadHelper


class HookFunction(object):
	# 这个类暂且就先这么处理了, 可以看看后面有没有优化的必要
	def __init__(self, fun, pri = 0):
		self.fun = fun
		self.pri = pri

	def __call__(self, *args, **kwds):
		return self.fun(*args, **kwds)

	def __lt__(self, other):
		return self.pri < other.pri


# 输出接口类
class OutputControl(object):
	def __init__(self, document):
		self.Document = document
		self.__line_hook = []
		# 注册一下默认的string hook函数
		self.reg_line_hook(self.__get_color)

	@classmethod
	def __get_color(cls, s):
		# 这里需要修改一下
		# 潜规则，如果要显示颜色则必须有一个空格，且大写
		strs = s.split(" ", 1)
		if len(strs) > 1:
			color = ColorConfigure[strs[0]]
			if color:
				return strs[1], color
		return s, None

	def reg_line_hook(self, fun, pri=0):
		# line color
		heapq.heappush(self.__line_hook, HookFunction(fun, pri))

	def line_hook(self, line):
		# TODO 这里的数据接口暂时就这么处理
		fore = None
		for hook in self.__line_hook:
			line, fore = hook(line)
		return line, fore

	@ThreadHelper.begin_invoke
	def write(self, s):
		buf = StringIO.StringIO(s)
		line = buf.readline()
		while line:
			line, fore = self.line_hook(line)
			if line:
				self.Document.AppendText(line, fore)
			line = buf.readline()

	@ThreadHelper.begin_invoke
	def append(self, s, fore=None, back=None, fm=None, fs=None):
		self.Document.AppendText(s, fore, back, fm, fs)

	@ThreadHelper.begin_invoke
	def append_line(self, s, fore=None, back=None, fm=None, fs=None):
		self.Document.AppendLine(s, fore, back, fm, fs)