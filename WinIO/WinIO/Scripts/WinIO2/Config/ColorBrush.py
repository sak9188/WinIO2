# -*- coding: UTF-8 -*-
from System.Windows.Media import SolidColorBrush, Colors

from WinIO2.Config.Configure import ConfigureMeta

from collections import OrderedDict

class BrushString(object):
	BLUE = "BLUE"
	GREEN = "GREEN"
	YELLOW = "YELLOW"
	PURPLE = "PURPLE"
	RED = "RED"
	GRAY = "GRAY"
	ORANGE = "ORANGE"


class ColorConfigure(object):
	ConfigDict = OrderedDict([
		(BrushString.BLUE, ("蓝色", SolidColorBrush(Colors.Blue))),
		(BrushString.GREEN, ("绿色", SolidColorBrush(Colors.Green))),
		(BrushString.YELLOW, ("黄色", SolidColorBrush(Colors.Yellow))),
		(BrushString.RED, ("红色", SolidColorBrush(Colors.Red))),
		(BrushString.GRAY, ("灰色", SolidColorBrush(Colors.Gray))),
		(BrushString.PURPLE, ("紫色", SolidColorBrush(Colors.Purple))),
		(BrushString.ORANGE, ("橙色", SolidColorBrush(Colors.Orange))),
	]) 

	Discribers = OrderedDict()

	__metaclass__ = ConfigureMeta