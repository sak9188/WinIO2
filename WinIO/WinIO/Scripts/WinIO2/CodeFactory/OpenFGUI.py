# -*- coding: UTF-8 -*-

from WinIO2.CodeFactory import BaseCodeFactory


class OpenFGUI(BaseCodeFactory.BaseCodeFactory):

	def code(self):
		# 这个可能后期要修改掉
		self.open_process("FairyGUI-Editor.exe", "D:\Project\Dev\ZTool\FairyGUI-Editor")



