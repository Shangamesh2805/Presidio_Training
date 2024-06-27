# 9) Find All Permutations of a given string
from itertools import permutations

string=input("Enter a string: ")
perms = [''.join(perm) for perm in permutations(string)]
print(perms)

