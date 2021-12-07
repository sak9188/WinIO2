# -*- coding: UTF-8 -*-
from System.Windows.Controls import FlowDocumentScrollViewer, ScrollBarVisibility
from WinIO.Controls import OutputDocument

class OutputPanel(FlowDocumentScrollViewer):
	def __init__(self):
		self.VerticalScrollBarVisibility = ScrollBarVisibility.Auto
		self.Document = OutputDocument()

	def write(self, s):
		self.Document.AppendText(s)

	def append(self, s, fore=None, back=None, fm=None, fs=None):
		self.Document.AppendText(s, fore, back, fm, fs)

	def append_line(self, s, fore=None, back=None, fm=None, fs=None):
		self.Document.AppendLine(s, fore, back, fm, fs)