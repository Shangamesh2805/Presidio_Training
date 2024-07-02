# 2) Inheritance in python

class Person:#parent class
  def __init__(self, fname, lname):
    self.firstname = fname
    self.lastname = lname

  def printname(self):
    print(self.firstname, self.lastname)
    
class Student(Person):#child class
  def __init__(self,fname,lname,gender):
     Person.__init__(self, fname, lname)
     self.gender=gender
    
x = Person("John", "Wayne")
x.printname()

x = Student("Jake", "Byran","Male")
x.printname()


