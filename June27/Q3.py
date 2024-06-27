# 3) Take name and gender print greet with salutation

name=input("Enter Your Name: ")

print("~"*10)

gender=input("Enter Your Gender: ")


if gender[0]=='M' or gender[0]=='m':
    salutation="Mr."
elif gender[0]=='F' or gender[0]=='f':
    salutation="Ms."
else:
    salutation="Mx."
    
print("~"*10)
print("Welcome ",salutation+name)
print("~"*10)
