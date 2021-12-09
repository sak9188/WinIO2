# -*- coding: UTF-8 -*-
from System.Windows.Controls import FlowDocumentScrollViewer, ScrollBarVisibility
from WinIO.Controls import OutputDocument

from WinIO2.Config.ColorBrush import ColorConfigure
from WinIO2.Core import ThreadHelper

import StringIO


class OutputPanel(FlowDocumentScrollViewer):
	def __init__(self, parent=None):
		self.thread_id = self.Dispatcher.Thread.ManagedThreadId
		self.VerticalScrollBarVisibility = ScrollBarVisibility.Auto
		self.Document = OutputDocument()
		self._parent = parent

	@property
	def parent(self):
		return self._parent

	@parent.setter
	def parent(self, value):
		self._parent = value

	def reset(self):
		self._parent.Content = self

	def __get_color(self, s):
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