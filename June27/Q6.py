# 6) Find if the given number is prime
from math import sqrt
print("Checking Prime Number")
a=int(input("Enter a Number: "))
flag=1
for i in range(2,int(sqrt(a))+1):
   
    if a%i==0 and i!=a:
        print("The Given number",a,"is not a prime number")
        flag=0
        break
    
if a==1:
        print("1 is neither prime nor composite")
        flag=0
if(flag):
    print("The Given number",a,"is a prime number")
        
    