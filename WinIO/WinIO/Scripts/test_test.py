import clr

from System.Windows.Controls import Button

class AClass(object):
    def __init__(self):
        self.win = None
        self.val = None
        self.int_val = 9

    def invoke(self):
        self.val("hello", str(self.int_val))
        self.int_val += 1
        
        button = Button()
        button.Content = "hello"
        self.win.GetButtonPanel().Children.Add(button)

    def recur(self):
        print "refunction"
        #self.win.Recur()


test_obj = AClass()