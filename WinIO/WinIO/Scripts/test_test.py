from System.Windows.Controls import Button

class AClass(object):
    def __init__(self):
        self.win = None
        self.val = None
        self.int_val = 9

    def invoke(self):
        self.val("hello", str(self.int_val))
        self.int_val += 1
        
        #button = Button()
        #button.Content = "hello"
        #self.win.GetButtonPanel().Children.Add(button)

    def invoke_again(self):
        self.invoke()

    def recur(self):
        print "refunction"
        self.win.Recur()

    def after_click(self, o, args):
        self.val("after_click", "after_click")



test_obj = AClass()