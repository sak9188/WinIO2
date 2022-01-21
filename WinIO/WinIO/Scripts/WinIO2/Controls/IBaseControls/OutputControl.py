from io import StringIO

from WinIO2.Config.ColorBrush import ColorConfigure
from WinIO2.Core import ThreadHelper

# -*- coding: UTF-8 -*-

# 输出接口类
class OutputControl(object):
	def __get_color(self, s):
		# 这里需要修改一下
		# 潜规则，如果要显示颜色则必须有一个空格，且大写
		strs = s.split(" ", 1)
		if len(strs) > 1:
			color = ColorConfigure[strs[0]]
			if color:	
				return strs[1], color
		return s, None
		

	@ThreadHelper.begin_invoke
	def write(self, s):
		buf = StringIO.StringIO(s)
		line = buf.readline()
		while line:
			line, fore = self.__get_color(line)
			if line:
				self.Document.AppendText(line, fore)
			line = buf.readline()

	@ThreadHelper.begin_invoke
	def append(self, s, fore=None, back=None, fm=None, fs=None):
		self.Document.AppendText(s, fore, back, fm, fs)

	@ThreadHelper.begin_invoke
	def append_line(self, s, fore=None, back=None, fm=None, fs=None):
		self.Document.AppendLine(s, fore, back, fm, fs)