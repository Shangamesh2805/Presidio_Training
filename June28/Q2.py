# 2) Print the list of prime numbers up to a given number

from math import sqrt
num=int(input("Enter a number :"))

def is_prime(n):
    if n <= 1:
        return False
    if n == 2:
        return True  
    if n % 2 == 0:
        return False
    for j in range(3, int(sqrt(n)) + 1, 2):
        if n % j == 0:
            return False
    return True

ans=[]
if num>1:
    for i in range(2,num+1):
        if is_prime(i):
            ans.append(i)

print(f"The list of prime number untit {num} are ",ans)
        