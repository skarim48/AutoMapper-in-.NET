// See https://aka.ms/new-console-template for more information
//Create and Populate Employee Object i.e. Source Object
using ConsoleApp1.MapperConfigiration;
using ConsoleApp1.Model;
using ConsoleApp1.ModelDTO;
using System.Reflection;

Employee emp = new Employee
{
    Name = "James",
    Salary = 20000,
    Address = "London",
    Department = "IT"
};

//Old Way :(
EmployeeDTO empDTO = new EmployeeDTO
{
    Name = emp.Name,
    Salary = emp.Salary,
};



//New Way :)
//Initializing AutoMapper
var mapper = MapperConfig.InitializeAutomapper();

//Way1
var empDTO1 = mapper.Map<EmployeeDTO>(emp);

//Way2
var empDTO2 = mapper.Map<Employee, EmployeeDTO>(emp);

//Get all properties Values
Type myType = empDTO2.GetType();
IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

foreach (PropertyInfo prop in props)
{
    object propValue = prop.GetValue(empDTO2, null);
    Console.WriteLine(prop.Name + " : " + propValue);
}

