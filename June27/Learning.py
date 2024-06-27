print("Hello, World!")

print()
# input and outputs

a=input("Enter  number:")

print("Type of variable a :",type(a))
print()
# DataTypes

integer_var = 10
float_var = 20.5
string_var = "Hello"
boolean_var = True

# print("interger=",integer_var)
print("Datatype of integer_var: ",type(integer_var))
# print("TypeCasting int to str",str(integer_var))


#Operators

a = 10
b = 5

# Arithmetic Operators

print(a + b)  # Addition
print(a - b)  # Subtraction
print(a * b)  # Multiplication
print(a / b)  # Division

# Comparison Operators


print(a == b)  # Equal to
print(a != b)  # Not equal to

# Logical Operators

print(a > b and a != 0)  # Logical AND
print(a > b or b == 0)   # Logical OR
print(not(a > b))        # Logical NOT


# Conditions Statements

x = 10
if x > 0:
    print("x is positive")
elif x < 0:
    print("x is negative")
else:
    print("x is zero")

#Loops

for x in range(6):
  print(x)

i = 0
while i < 6:
  i += 1
  if i == 3:
    continue
  print(i)

i = 0
while i < 6:
  i += 1
  if i == 3:
    break
  print(i)

# list

my_list = [10, 20, 30, 40, 50]
list1 = ["abc", 34, True, 40, "male"]
print(my_list[0])  # First element
print(my_list[-1]) # Last element

#tuple

tuple = ("apple", "banana", "cherry", "apple", "cherry")
print(tuple[1])

#set

set1 = {"abc", 34, True, 40, "male"}
for x in set1:
    print(x)

#dictionary 
thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964,
  "year": 2020
}
print(thisdict["year"])

#functions

def my_function():
  print("Hello from my function")

my_function()

#parameters

def Add_Numbers(a,b):
   print("Sum of Numbers: ",a+b)

Add_Numbers(1,2)
   

