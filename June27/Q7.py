# 7) Take 10 numbers and find the average of all the prime numbers in the collection

from math import sqrt 
n = 10
a = []
while len(a) != n:
    a = list(map(int, input("Enter exactly 10 numbers separated by spaces: ").strip().split()))
    if len(a) != n:
        print(f"Please enter exactly {n} numbers. You entered {len(a)} numbers.")

def prime_number(n):
    flag=1
    for i in range(2,int(sqrt(n))+1):
    
        if n%i==0 and i!=n:
            return False
        
    if n==1:
        return False
    else:
        return True

   
c=0
sum=0
for i in a:
    if prime_number(i):
        sum=sum+i
        c=c+1
print()        
print("Average of prime number in ",a,"is :",sum/c)
    
        