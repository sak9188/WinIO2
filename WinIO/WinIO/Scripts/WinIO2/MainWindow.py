# -*- coding: UTF-8 -*-

from WinIO2.Application import Application
from WinIO2.Controls.MenuItem import MenuItem
from WinIO2.Core.List import List

class MainWindow(object):
	__share__ = {}

	def __init__(self):
		if self.__share__:
			self.__dict__ = self.__share__
			return
		self.__dict__ = self.__share__
		self.app = Application()
		self.main_window = self.app.get_mainwindow()
		self.init_self()

	def __str__(self):
		constring = """  _       __ _         ____ ____     
 | |     / /(_)____   /  _// __ \    
 | | /| / // // __ \  / / / / / /    
 | |/ |/ // // / / /_/ / / /_/ /     
 |__/|__//_//_/ /_//___/ \____/ """
		return constring
	
	def init_self(self):
		self.init_output()
		self.init_ui()
		self.init_input()

		menu = self.main_window.PanelMenu
		# 这里如果采用自动转换的话, 如果右边的list发生变化, 但是左边的ItemSource并不会发生变化
		# 那么这样的自动转化毫无意义, 最好的方法就是用原生C#对象, 这样就可以捕捉成员的变化
		# 1. 包装一下Menu, 但是同样不能达到马上的变化
		# 2. 直接使用C#原生对象, 可以达到原生变化, 但是API接口相关就得用C#了
		# 3. 继承C#得类, 然后通过Python手动创建, 这样得化, 便可以得双全
		a = MenuItem("青龙在手", "../../../splash.png")
		b = MenuItem("Test3")
		a.add(b)
		b.add(a)
		# def change_title():
		# 	a.title = "龙飞凤舞"
		# a.click.append(lambda x,y: change_title())
		menu.ItemsSource = List([a, MenuItem("test2")])

	def init_output(self):
		pass

	def init_ui(self):
		pass

	def init_input(self):
		pass