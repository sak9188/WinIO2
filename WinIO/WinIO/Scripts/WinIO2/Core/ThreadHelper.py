# -*- coding: UTF-8 -*-
from System.Threading import Thread
from System.Windows import Application

from WinIO.Core import PyDelegateConverter as PyDel
from WinIO import MainProgram

App = MainProgram.app
AppThreadID = App.Dispatcher.Thread.ManagedThreadId


def get_thread_id():
	return Thread.CurrentThread.ManagedThreadId


def dispatcher(func):
	def wrapper(*args, **kwargs):

		def __fun():
			return func(*args, **kwargs)

		if AppThreadID != get_thread_id():
			return App.Dispatcher.Invoke(
					PyDel.ToFunc(__fun))
		else:
			return func(*args, **kwargs)

	return wrapper