# 1) Python class
# 2) Inheritance in python
# 3) Polymorphism in python
# 4) Modules in python
# 5) Exception Handling(Try Except)
# 6) File handling - Read and Write

#class

class MyClass:
    i = 12345

    def f(self):
        return 'hello world'

a=MyClass()

print(a.f())


#__init__() - instantiate itself 

class Numbers:
    def __init__(self, a, b):
        self.k = a
        self.i = b

x = Numbers(3.0, -4.5)
print(x.k, x.i)


#instance

class Dog:

    kind = 'canine'         # class variable shared by all instances

    def __init__(self, name):
        self.name = name    # instance variable unique to each instance

d = Dog('Fido')
e = Dog('Buddy')
print("d =",d.name,"e = ", e.name)
print(d.kind,e.kind)


#priortise instance over class

class Warehouse:
   purpose = 'storage'
   region = 'west'

w1 = Warehouse()
print(w1.purpose, w1.region)

w2 = Warehouse()
w2.region = 'east'
print(w2.purpose, w2.region)


