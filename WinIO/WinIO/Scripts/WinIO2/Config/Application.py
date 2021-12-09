# -*- coding: UTF-8 -*-
from WinIO2.Core.Configure import ConfigureMeta
# 应用程序的配置文件

class ApplicationString:

	OutputFont = "OutputDefaultFontFamily"
	OutputFontSize = "OutputDefaultFontSize"


class ApplicationCofigure(object):
	ConfigDict = {
		ApplicationString.OutputFont: 

	}

	__metaclass__ = ConfigureMeta