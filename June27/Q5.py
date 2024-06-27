import pandas as pd
import datetime

a = 1

while a:
    name = input("Enter Your Name: ")
    if len(name) >= 3:
        break
    else:
        print("Enter a Valid Name with more than 3 characters")

print("-" * 20)

while a:
    age = input("Enter Your Age: ")
    if age.isdigit() and int(age) > 0:
        age = int(age)
        break
    else:
        print("Enter a Valid Age")

print("-" * 20)

while a:
    DOB = input("Enter Your Date OF Birth (dd/mm/yyyy): ")
    try:
        day, month, year = map(int, DOB.split("/"))
        datetime.datetime(year, month, day)
        break
    except ValueError:
        print("Enter a Proper Date in format dd/mm/yyyy")

print("-" * 20)

while a:
    phone_no = input("Enter Your 10 Digit Phone_No: ")
    if phone_no.isdigit() and len(phone_no) == 10:
        break
    else:
        print("Please Enter a 10 Digit Mobile Number")

print("-" * 20)

table = [[name, age, DOB, phone_no]]
df = pd.DataFrame(table, columns=['Name', 'Age', 'DOB', 'Phone_no'], index=['row_1'])
print(df)
