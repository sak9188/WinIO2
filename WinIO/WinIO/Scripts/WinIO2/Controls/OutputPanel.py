# -*- coding: UTF-8 -*-
from System.Windows.Controls import FlowDocumentScrollViewer
from WinIO.Controls import OutputDocument

class OutputPanel(FlowDocumentScrollViewer):
	def __init__(self):
		self.Document = OutputDocument()