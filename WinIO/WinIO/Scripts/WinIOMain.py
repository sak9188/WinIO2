# -*- coding: UTF-8 -*-
import os
import sys

from WinIO2.MainWindow import MainWindow

sys = reload(sys)
sys.setdefaultencoding('utf8')
sys.path.append("D:/Project/Dev/Develop/PyHelp")
sys.path.append("D:/Project/Dev/Develop/PyCode")

# path = os.path.realpath(__file__)
# path = path[:path.find("Develop")] + r"Develop\PyCode"
# if path not in sys.path: sys.path.append(path)
# path = path.replace("PyCode", "PyHelp")
# if path not in sys.path: sys.path.append(path)

from Server import GSEnvironment
from Tool.GameIO import GIONetWork


io_select = GIONetWork.get_io_select()

if GSEnvironment.is_windows():
	main_window = MainWindow()
	
	# main_window.write("PURPLE ======================================================================\n")
	# main_window.write("WinIO2 使用帮助\n")
	# main_window.write("PURPLE ======================================================================\n")

	# io_select.start()