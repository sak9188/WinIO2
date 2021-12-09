# -*- coding: UTF-8 -*-

import re
from System.Windows.Media import SolidColorBrush, Colors

from WinIO2.Core.Configure import ConfigureMeta

class BrushString(object):
	BLUE = "BLUE"
	GREEN = "GREEN"
	YELLOW = "YELLOW"
	PURPLE = "PURPLE"
	RED = "RED"
	GRAY = "GRAY"
	ORANGE = "ORANGE"


class ColorConfigure(object):
	ConfigDict = {
		BrushString.BLUE: SolidColorBrush(Colors.Blue),
		BrushString.GREEN: SolidColorBrush(Colors.Green),
		BrushString.YELLOW: SolidColorBrush(Colors.Yellow),
		BrushString.RED: SolidColorBrush(Colors.Red),
		BrushString.GRAY: SolidColorBrush(Colors.Gray),
		BrushString.PURPLE: SolidColorBrush(Colors.Purple),
		BrushString.ORANGE: SolidColorBrush(Colors.Orange)
	}

	__metaclass__ = ConfigureMeta