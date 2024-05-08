create database doctorClinicdb

use doctorClinicdb

CREATE TABLE Doctors("Doc_ID" Int NOT NULL,"Name" Varchar(20) Not Null,"Specialization" Varchar(20) NOt Null,Primary Key ("Doc_ID"));
 Select * from Doctors

CREATE TABLE Patient("Patient_ID" Int NOT NUll Primary Key,"Name" VarChar(20),"Address" Varchar(50) Not NULL, "PhoneNumber" Varchar(20))
Select * from Patient

 Create Table Appointment("Appointment_Id" INt Not Null Primary Key , "Date"  DateTime ,"Doc_ID" INt ,"Patient_ID" Int,
 Foreign key(Doc_ID) References Doctors(Doc_ID),Foreign key(Patient_ID) References Patient(Patient_ID))

 select * from Appointment