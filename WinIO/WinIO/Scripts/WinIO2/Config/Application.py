# -*- coding: UTF-8 -*-

from WinIO2.Config.Configure import ConfigDiscriber, ConfigureMeta


# 应用程序的配置文件
class ApplicationString:
	OutputFont = "OutputDefaultFontFamily"
	OutputFontSize = "OutputDefaultFontSize"


class ApplicationCofigure(object):
	ConfigDict = {
		ApplicationString.OutputFont: ("输出面板字体", None), 
		ApplicationString.OutputFontSize: ("输出面板字体大小", None) 
	}

	__metaclass__ = ConfigureMeta
