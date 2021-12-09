# -*- coding: UTF-8 -*-
from System.Threading import Thread

from WinIO.Core import PyDelegateConverter as PyDel
from WinIO import MainProgram

App = MainProgram.app
AppThreadID = App.Dispatcher.Thread.ManagedThreadId


def get_thread_id():
	return Thread.CurrentThread.ManagedThreadId


def invoke(func):
	def wrapper(*args, **kwargs):

		def __fun():
			return func(*args, **kwargs)

		if AppThreadID != get_thread_id():
			return App.Dispatcher.Invoke(
					PyDel.ToFunc(__fun))
		else:
			return func(*args, **kwargs)

	return wrapper


def begin_invoke(func):
	def wrapper(*args, **kwargs):

		def __fun():
			return func(*args, **kwargs)

		if AppThreadID != get_thread_id():
			App.Dispatcher.BeginInvoke(
					PyDel.ToFunc(__fun))
		else:
			func(*args, **kwargs)

	return wrapper