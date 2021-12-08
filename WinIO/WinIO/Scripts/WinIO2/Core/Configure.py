# -*- coding: UTF-8 -*-

class ConfigureMeta(type):
	ConfigDict = {}

	def __getitem__(self, name):
		brush = self.ConfigDict.get(name)
		if brush: return brush
		else: return None