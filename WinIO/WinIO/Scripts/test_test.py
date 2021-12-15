class nonZero(int):
    def __new__(cls,value):
        print("__new__ is executed")
        return super().__new__(cls,value) if value != 0 else None

    def __init__(self,skipped_value):
        #此例中会跳过此方法
        print("__init__()")
        super().__init__()

print(type(nonZero(-12)))
print(type(nonZero(0)))