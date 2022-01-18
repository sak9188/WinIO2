# -*- coding: UTF-8 -*-

class_dict = {}

wrap_view = """
# 这里是自动生成的代码，修改了是无法保存的
from WinIO2.Core import code

code.execute(%s)
"""

def get_code(value_class):
	cls_name = value_class.__name__
	return wrap_view % cls_name


def execute(cls_name):
	cls_tup = class_dict.get(cls_name)
	if type(cls_tup) is tuple:
		_, obj = cls_tup
	else:
		obj = cls_tup()
		class_dict[cls_name] = (cls_tup, obj)
	obj()

