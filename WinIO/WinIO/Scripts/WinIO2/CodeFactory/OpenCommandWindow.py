# -*- coding: UTF-8 -*-

from WinIO2.CodeFactory import BaseCodeFactory


class OpenCommandWindow(BaseCodeFactory.BaseCodeFactory):

	def code(self):
		from WinIO2.Controls.CommandWindow import CommandWindow
		CommandWindow().Show()