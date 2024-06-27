# 4) Take name, age, date of birth and phone print details in proper forma
import pandas as pd
name=input("Enter Your Name: ")
age=input("Enter Your Age: ")
DOB=input("Enter Your Date OF Birth: ")
a=1
while(a):
    phone_no=input("Enter Your 10 Digit Phone_No: ")
    if len(phone_no)==10:
        break

table = [[name, age, DOB, phone_no]]
df = pd.DataFrame(table, columns = ['Name', 'Age', 'DOB', 'Phone_no'], index=['1'])
print(df)