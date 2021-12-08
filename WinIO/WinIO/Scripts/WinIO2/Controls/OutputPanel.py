# -*- coding: UTF-8 -*-
from System.Windows.Controls import FlowDocumentScrollViewer, ScrollBarVisibility
from WinIO.Controls import OutputDocument
from WinIO.Core import PyDelegateConverter as PyDel

from WinIO2.Core.ThreadHelper import dispatcher

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

	@dispatcher
	def write(self, s):
		self.Document.AppendText(s)

	@dispatcher
	def append(self, s, fore=None, back=None, fm=None, fs=None):
		self.Document.AppendText(s, fore, back, fm, fs)

	@dispatcher
	def append_line(self, s, fore=None, back=None, fm=None, fs=None):
		self.Document.AppendLine(s, fore, back, fm, fs)