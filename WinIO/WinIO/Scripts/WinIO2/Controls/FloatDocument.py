from WinIO.Controls import CustomeDocument

class FloatDocument(CustomeDocument):

	def __init__(self, title, control):
		self.Title = title
		self.Content = control
		control.parent = self
