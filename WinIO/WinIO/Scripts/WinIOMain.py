# -*- coding: UTF-8 -*-
import sys

sys = reload(sys)
sys.setdefaultencoding('utf8')
sys.path.append("D:/Project/Dev/Develop/PyHelp/")
sys.path.append("D:/Project/Dev/Develop/PyCode/")

class Debug(object):

	def __init__(self):
		sys.stdout = self
		sys.stderr = self

	def write(self, s):
		from System import Console
		Console.Write(s)

	def redirect(self, o):
		if not o:
			return
		sys.stdout = o
		sys.stderr = o


debug = Debug()


from WinIO2.MainWindow import MainWindow
from WinIO2.Core.FunctionTool import FunctionChain

# path = os.path.realpath(__file__)
# path = path[:path.find("Develop")] + r"Develop\PyCode"
# if path not in sys.path: sys.path.append(path)
# path = path.replace("PyCode", "PyHelp")
# if path not in sys.path: sys.path.append(path)

from Server import GSEnvironment
from Tool.GameIO import GIONetWork


io = GIONetWork.get_io_select()


if GSEnvironment.is_windows():
	main_window = MainWindow()
	# 把IO给MainWindow
	main_window.io = io
	debug.redirect(main_window)

	io.on_write_callback = FunctionChain(main_window.on_write) 
	io.on_progress_callback = main_window.on_progress
	io.on_accept_callback = main_window.on_accept
	io.on_recv_callback = main_window.on_recv
	io.on_close_callback = main_window.on_close
	io.on_except_callback = main_window.on_except

	main_window.after_closed += lambda x, y: io.stop()

	main_window.write("PURPLE ===============================================\n")
	main_window.write("WinIO2 使用帮助\n")
	main_window.write("PURPLE ===============================================\n")

	io.start()