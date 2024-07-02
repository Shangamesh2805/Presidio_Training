import os
import datetime
import re
import pandas as pd
from fpdf import FPDF

class Employee:
    def __init__(self, name, dob, phone, email):
        self.name = name
        self.dob = dob
        self.phone = phone
        self.email = email

    def calculate_age(self):
        today = datetime.date.today()
        birth_date = datetime.datetime.strptime(self.dob, "%Y-%m-%d").date()
        age = today.year - birth_date.year - ((today.month, today.day) < (birth_date.month, birth_date.day))
        return age

def validate_name(name):
    if not name.isalpha() or len(name) < 3:
        raise ValueError("Name must be at least 3 characters long and contain only letters.")

def validate_dob(dob):
    try:
        datetime.datetime.strptime(dob, "%Y-%m-%d")
    except ValueError:
        raise ValueError("Date of birth must be in YYYY-MM-DD format.")

def validate_phone(phone):
    if not re.match(r"^\d{10}$", phone) or phone.isnumeric():
        raise ValueError("Phone number must be 10 digits long.")

def validate_email(email):
    if not re.match(r"[^@]+@[^@]+\.[^@]+", email):
        raise ValueError("Invalid email format.")

def get_employee_details():
    try:
        name = input("Enter employee name: ")
        validate_name(name)
        
        dob = input("Enter date of birth (YYYY-MM-DD): ")
        validate_dob(dob)
        
        phone = input("Enter phone number: ")
        validate_phone(phone)
        
        email = input("Enter email address: ")
        validate_email(email)
        
        return Employee(name, dob, phone, email)
    except ValueError as e:
        print(f"Error: {e}")
        return None

def save_to_file(employees, filename_with_extension):
    file_format = filename_with_extension.split('.')[-1]
    if file_format == 'txt':
        with open(filename_with_extension, "w") as file:
            for employee in employees:
                file.write(f"Name: {employee.name}\n")
                file.write(f"Date of Birth: {employee.dob}\n")
                file.write(f"Phone: {employee.phone}\n")
                file.write(f"Email: {employee.email}\n")
                file.write(f"Age: {employee.calculate_age()} years\n")
                file.write("\n")
        print(f"Employee details saved to {filename_with_extension}")
    elif file_format == 'xlsx':
        data = [{
            "Name": employee.name,
            "DOB": employee.dob,
            "Phone": employee.phone,
            "Email": employee.email,
            "Age": employee.calculate_age()
        } for employee in employees]
        df = pd.DataFrame(data)
        df.to_excel(filename_with_extension, index=False)
        print(f"Employee details saved to {filename_with_extension}")
    elif file_format == 'pdf':
        pdf = FPDF()
        pdf.add_page()
        pdf.set_font("Arial", size=12)
        for employee in employees:
            pdf.cell(200, 10, txt=f"Name: {employee.name}", ln=True)
            pdf.cell(200, 10, txt=f"Date of Birth: {employee.dob}", ln=True)
            pdf.cell(200, 10, txt=f"Phone: {employee.phone}", ln=True)
            pdf.cell(200, 10, txt=f"Email: {employee.email}", ln=True)
            pdf.cell(200, 10, txt=f"Age: {employee.calculate_age()} years", ln=True)
            pdf.cell(200, 10, txt="", ln=True)  # Blank line between entries
        pdf.output(filename_with_extension)
        print(f"Employee details saved to {filename_with_extension}")
    else:
        print(f"Unsupported file format: {file_format}")

def read_from_excel(filename, employees):
    try:
        df = pd.read_excel(filename)
        for _, row in df.iterrows():
            employees.append(Employee(row["Name"], row["DOB"], row["Phone"], row["Email"]))
        print(f"Employees retrieved from {filename}")
        display_employees(employees)
    except FileNotFoundError:
        print(f"File '{filename}' not found.")
    except KeyError:
        print(f"File '{filename}' does not contain the required columns.")

def edit_employee_details(employees, filename_with_extension):
    name_to_edit = input("Enter the name of the employee to edit: ")
    for emp in employees:
        if emp.name.lower() == name_to_edit.lower():
            print(f"Editing details for {emp.name}:")
            dob = input("Enter updated date of birth (YYYY-MM-DD): ")
            validate_dob(dob)
            emp.dob = dob
            
            phone = input("Enter updated phone number: ")
            validate_phone(phone)
            emp.phone = phone
            
            email = input("Enter updated email address: ")
            validate_email(email)
            emp.email = email
            
            print("Employee details updated successfully.")
            save_to_file(employees, filename_with_extension)
            break
    else:
        print(f"Employee with name '{name_to_edit}' not found.")

def display_employees(employees):
    if not employees:
        print("No employees to display.")
    else:
        for emp in employees:
            print(f"Name: {emp.name}, Date of Birth: {emp.dob}, Phone: {emp.phone}, Email: {emp.email}, Age: {emp.calculate_age()} years")

def main():
    print("Welcome to the Employee Management System!")
    employees = []

    print("\nChoose a file format to save the employee details:")
    print("1. Text")
    print("2. Excel")
    print("3. PDF")
    format_choice = input("Enter your choice (1/2/3): ")

    filename = input("Enter a filename (without extension): ")
    if format_choice == "1":
        filename_with_extension = f"{filename}.txt"
    elif format_choice == "2":
        filename_with_extension = f"{filename}.xlsx"
    elif format_choice == "3":
        filename_with_extension = f"{filename}.pdf"
    else:
        print("Invalid choice. Exiting.")
        return

    while True:
        print("\nMenu:")
        print("1. Add Employee")
        print("2. View Employees")
        print("3. Edit Employee Details")
        print("4. Retrieve Employees from Excel")
        print("5. Exit")
        choice = input("Enter your choice (1/2/3/4/5): ")

        if choice == "1":
            employee = get_employee_details()
            if employee:
                employees.append(employee)
                save_to_file(employees, filename_with_extension)
        elif choice == "2":
            display_employees(employees)
        elif choice == "3":
            edit_employee_details(employees, filename_with_extension)
        elif choice == "4":
            excel_filename = input("Enter the Excel filename (with extension): ")
            read_from_excel(excel_filename, employees)
        elif choice == "5":
            print("Exiting. Thank you!")
            break
        else:
            print("Invalid choice. Please select a valid option.")

if __name__ == "__main__":
    main()
