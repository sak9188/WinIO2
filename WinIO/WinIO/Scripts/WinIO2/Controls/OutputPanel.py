# -*- coding: UTF-8 -*-
from System.Windows.Controls import FlowDocumentScrollViewer, ScrollBarVisibility
from WinIO.Controls import OutputDocument

from WinIO2.Config.ColorBrush import ColorConfigure
from WinIO2.Controls.IBaseControls.OutputControl import OutputControl
from WinIO2.Core import ThreadHelper

import StringIO


class OutputPanel(FlowDocumentScrollViewer, OutputControl):
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
