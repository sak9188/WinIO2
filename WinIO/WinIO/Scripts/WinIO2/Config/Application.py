# -*- coding: UTF-8 -*-

from WinIO2.Config.Configure import ConfigDiscriber, ConfigureMeta, StringType


# 应用程序的配置文件
class ApplicationString:
	OutputFont = "OutputDefaultFontFamily"
	OutputFontSize = "OutputDefaultFontSize"
	BackgroundImage = "BackgroundImage"


class ApplicationCofigure(object):
	ConfigDict = {
		ApplicationString.OutputFont: ("输出面板字体", None), 
		ApplicationString.OutputFontSize: ("输出面板字体大小", None),
		ApplicationString.BackgroundImage: ("窗口桌面背景", "", StringType.Dialog) 
	}

	__metaclass__ = ConfigureMeta
