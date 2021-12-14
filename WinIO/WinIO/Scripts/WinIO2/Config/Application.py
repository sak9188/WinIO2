# -*- coding: UTF-8 -*-

from WinIO2.Config.Configure import ConfigureMeta, StringType

from collections import OrderedDict

# 应用程序的配置文件
class ApplicationString:
	OutputFont = "OutputDefaultFontFamily"
	OutputFontSize = "OutputDefaultFontSize"
	BackgroundImage = "BackgroundImage"


class ApplicationCofigure(object):
	ConfigDict = OrderedDict([
		(ApplicationString.OutputFont, ("输出面板字体", None)), 
		(ApplicationString.OutputFontSize, ("输出面板字体大小", None)),
		(ApplicationString.BackgroundImage, ("窗口桌面背景", "", StringType.Dialog))
	])

	Discribers = OrderedDict()

	__metaclass__ = ConfigureMeta
