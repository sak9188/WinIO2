# -*- coding: UTF-8 -*-
from WinIO.Core import PyDelegateConverter as PyDel

from WinIO2.Application import Application
from WinIO2.Config.Application import ApplicationCofigure
from WinIO2.Controls.BlankWindow import AcrylicWindowStyle
from WinIO2.Controls.MenuItem import MenuItem
from WinIO2.Controls.SettingWindow import SettingWindow
from WinIO2.Core import ThreadHelper
from WinIO2.Core.FunctionTool import FunctionChain
from WinIO2.Core.List import List
from WinIO2.Controls.OutputPanel import OutputPanel
from WinIO2.Controls.FloatDocument import FloatDocument

import os

from Tool import ToolHelp, BatCallPythonFunction
from Common import File, Environment, String
from Tool.GameIO import GUnmanaged, GIOGM, GIOCore


class MainWindow(object):
	__share__ = {}

	def __init__(self):
		if self.__share__:
			self.__dict__ = self.__share__
			return
		self.__dict__ = self.__share__
		self.app = Application()
		self.main_window = self.app.get_mainwindow()
		self.window_menu = self.main_window.WindowMenu
		self.menu = self.main_window.PanelMenu
		self.menu_items_dict = {}
		self.dock_manager = self.main_window.DockMgr
		self.dock_pane = self.main_window.MainDockPane
		self.left_dock_pane = self.main_window.LeftMainDockPane
		self.document_dict = {}
		self.anchora_dict= {}
		self.after_closed = FunctionChain() 
		self.main_window.AfterClosed = PyDel.ToEventHandler(self.after_closed)
		self.init_self()

	def __str__(self):
		constring = \
"""
  _       __ _         ____ ____     
 | |     / /(_)____   /  _// __ \    
 | | /| / // // __ \  / / / / / /    
 | |/ |/ // // / / /_/ / / /_/ /     
 |__/|__//_//_/ /_//___/ \____/ 
"""
		return constring
	
	def init_self(self):
		self.init_output()
		self.init_base()
		self.init_gmui()
		self.init_input()
		self.init_config()

	def init_base(self):
		# 这里初始化一些基本UI
		menu_list = []
		self.tool_window = tool_window = SettingWindow("设置面板")
		tool_window.set_window_style(AcrylicWindowStyle.NoIcon)
		tool_window.height = 300
		tool_window.width = 500
		tool_window.load_configure(ApplicationCofigure)

		tool_menu = MenuItem("工具")
		def _open_setting_panel():
			tool_window.ShowDialog()

		self.after_closed.append(lambda x,y: tool_window.RealClose())

		setting_item = MenuItem("设置", on_click=lambda x,y: _open_setting_panel())
		tool_menu.add(setting_item)
		menu_list.append(tool_menu)
		self.window_menu.ItemsSource = List(menu_list)

	def init_output(self):
		self.output = self.create_anchorable("WinIO", OutputPanel())

		print self
		# 这里需要初始化基本的面板	

	def init_gmui(self):
		# 这里的皮
		# for os_name in GameDefine.OperatingSystemList:
		# 	self.create_menu_item("IO工具/设置批处理参数/" + os_name, GEvent(self, "change_bat_param", os_name))
		# for language_name in PlatformHelp.get_now_all_language_list():
		# 	self.create_menu_item("IO工具/设置批处理参数/" + language_name, GEvent(self, "change_bat_param", language_name))
		menu_dict = self.menu_items_dict
		menu_list = []		

		# 初始化工具集合
		io_menu = MenuItem("IO工具")
		io_menu_sub_list = [MenuItem("清理"), MenuItem("残酷的杀死服务器", on_click=lambda x,y: self.kill_server())]

		for io_fun in GUnmanaged.get_unmamaged_function_list():
			io_menu_sub_list.append(MenuItem(io_fun.name, on_click=lambda x,y: io_fun()))	

		io_menu.add_range(io_menu_sub_list)
		# 这里
		menu_dict[io_menu.title] = io_menu
		menu_list.append(io_menu)

		# 初始化工具指令
		for menu_string, fun in GIOCore.get_tool_menu_list(self):
			self.create_menuitem_from_string(menu_list, menu_string, fun)

		for fun_name, fun_desc in BatCallPythonFunction.get_iotool_menu_list():
			self.create_menuitem_from_string(menu_list, fun_desc, GIOCore.ExecuteFun(fun_name).as_tool_fun())

		# 初始化gm指令
		for module_doc, function_info_list in GIOGM.get_gm_command_list():
			moudule_item = menu_dict.get(module_doc)
			moudule_item = MenuItem(module_doc)
			menu_dict[moudule_item.title] = moudule_item
			menu_list.append(moudule_item)
			for function_doc, module_name, function_name in function_info_list:
				# 这里应该是双层级的
				sub_function_item = MenuItem(function_doc, on_click=lambda x,y: GIOCore.GMFunction(module_doc, function_doc, module_name, function_name)() )
				moudule_item.add(sub_function_item)
		
		# 一个HooK按钮
		def test_save():
			from WinIO2.Config.Configure import ConfigureMeta
			ConfigureMeta.save_config()

		def test_load():
			from WinIO2.Config.Configure import ConfigureMeta
			ConfigureMeta.load_config()

		hook = MenuItem("序列化测试", on_click=lambda x,y: test_save())
		hook1 = MenuItem("反序列化测试", on_click=lambda x,y: test_load())

		menu_list.insert(0, hook)
		menu_list.insert(1, hook1)
		# 最后把数据赋值上去
		self.menu.ItemsSource = List(menu_list)

	def init_input(self):
		pass

	def init_config(self):
		# 这里进行一些初始化配置信息
		from WinIO2.Config.Application import ApplicationString, ApplicationCofigure
		app_string = ApplicationString
		app_config = ApplicationCofigure
		# 注册配置事件
		desc = app_config.get_discriber(app_string.BackgroundImage)
		desc.reg_observer(self.after_change_background)

	"""
	功能函数
	"""
	def write(self, s):
		self.output.write(s)

	def on_write(self, s):
		self.output.write(s)

	def on_progress(self, s):
		pass

	@ThreadHelper.begin_invoke
	def on_accept(self, key, name):
		self.create_document(key, name, OutputPanel())

	def on_recv(self, key, data):
		document = self.document_dict.get(key)
		if document:
			document.write(data)

	def on_close(self, key):
		self.shutdown_document(key)

	def on_except(self, s):
		self.output.write(s)

	def create_menuitem_from_string(self, menu_list, string, fun):
		# 这里只存储父节点
		menu_dict = self.menu_items_dict
		menu_strs = string.rsplit("/", 1)
		if len(menu_strs) > 1:
			# 说明有一个父亲
			father_str, child_str = menu_strs
			# 直接找父亲
			father_item = menu_dict.get(father_str)
			# 子节点
			child_item = MenuItem(child_str, on_click=lambda x,y: fun())
			if not father_item:
				# 说明并没有这个父亲， 需要从头开始进行一个搜索
				fathers = father_str.split("/")
				father_item = None
				for father in fathers:
					# 所有父亲都应该被缓存了
					if father_item is None:
						# 第一次特例
						father_item = menu_dict.get(father)
						if not father_item:
							father_item = MenuItem(father)
							menu_dict[father] = father_item
							menu_list.append(father_item)
					else:
						# 说明已经找到父节点了
						sub_child_item = father_item.find(father)	
						if not sub_child_item:
							sub_child_item = MenuItem(father)
							father_item.add(sub_child_item)
						father_item = sub_child_item
				# 执行到这里的时候， father_item已经被生成或者找到
				menu_dict[father_str] = father_item
			father_item.add(child_item)
		else:
			# 说明自己本身就是一个节点
			item = MenuItem(menu_strs[0], on_click=lambda x,y: fun())
			menu_dict[item.title] = item
			menu_list.append(item)
	
	def kill_server(self):
		os.system("TASKKILL /F /IM %s.exe" % Environment.get_game_key())

	"""
	UI相关	
	"""	
	def save_layout(self):
		# 布局相关还没思考怎么做比较合适， 因为页签之间存在层级和逻辑关系
		pass

	def load_layout(self):
		# 布局相关还没思考怎么做比较合适， 因为页签之间存在层级和逻辑关系
		pass

	@ThreadHelper.invoke
	def create_document(self, index, name, control):
		document = FloatDocument(name, control)
		self.dock_pane.Children.Add(document)
		self.document_dict[index] = control
		return control

	@ThreadHelper.invoke
	def create_anchorable(self, name, control):
		document = FloatDocument(name, control)
		self.left_dock_pane.Children.Add(document)
		self.anchora_dict[name] = control
		return control

	@ThreadHelper.begin_invoke
	def shutdown_document(self, index):
		# 这里是真正的关闭
		control = self.document_dict.get(index)
		if not control:
			return
		self.dock_pane.RemoveChild(control.parent)
		self.document_dict.pop(index)
		del control

	@ThreadHelper.begin_invoke
	def close_document(self, index):
		control = self.document_dict.get(index)
		if not control:
			return
		self.dock_pane.RemoveChild(control.parent)

	"""
	配置回调	
	"""
	def after_change_background(self, desc):
		self.main_window.SetBackground(desc.control)
