from WinIO.Controls import CustomeDocument

class FloatDocument(CustomeDocument):

	def __init__(self, title, control):
		self.Title = title
		self.Content = control
		control.parent = self

	@property
	def ban_resort(self):
		return self.BanResort

	@ban_resort.setter
	def ban_resort(self, value):
		self.BanResort= value
