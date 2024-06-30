string="Presidio"

print(string[-1])#accessing
print(string[:5])#slicing

print(string[::-1])#reversal

#Manipulating

s="Presidio"
list=list(s)
print(list)
list[0]='p'
s="".join(list)
print(s)


s = s[0:2] + 'p' + s[3:]
print(s)

a = 12.3456789

print(f"The value of Integer1 is {a:.3f}")

