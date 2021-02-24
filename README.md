# CSharp-Console-Program

This project contains a Student class which has three string properties, FirstName, LastName, and HNumber. 
The FirstName and LastName use setters which throw ArgumentExceptions if the properties are set to an empty string.
The HNumber setter throws an ArgumentException if the value length is not 9, the value does not start with H, and the characters following H are not all digits. 
The Student class overrides the ToString() method so it returns "LastName, FirstName - HNumber"
There is also a static method called DivideStudents() with three List<Student> parameters. The method should run throguh the studentList in order and examine the first digit of the HNumber and sorts students based on the initial digit.
