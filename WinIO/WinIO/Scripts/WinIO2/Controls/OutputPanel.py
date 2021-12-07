# -*- coding: UTF-8 -*-
from System.Windows.Controls import FlowDocumentScrollViewer, ScrollBarVisibility
from WinIO.Controls import OutputDocument

class OutputPanel(FlowDocumentScrollViewer):
	def __init__(self, parent=None):
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

	def write(self, s):
		self.Document.AppendText(s)

	def append(self, s, fore=None, back=None, fm=None, fs=None):
		self.Document.AppendText(s, fore, back, fm, fs)

	def append_line(self, s, fore=None, back=None, fm=None, fs=None):
		self.Document.AppendLine(s, fore, back, fm, fs)