﻿using OCP;

class Program
{
    static void Main(string [] args)
    {
        List<IApplicantModel> applicants = new List<IApplicantModel>{
            new PersonModel {FirstName="Jake", LastName = "Willow"},
            new ManagerModel {FirstName="Sam", LastName = "Smith"},
            new ExecutiveModel {FirstName="Abby", LastName = "Gail"},
        };

        List<EmployeeModel> employees = new List<EmployeeModel>();

        foreach (var person in applicants)
        {
            employees.Add(person.AccountProcessor.Create(person));
        }

        foreach (var employee in employees)
        {
            System.Console.WriteLine($"{employee.FirstName} {employee.LastName}:{employee.Email} IsManager: {employee.IsManager} IsExecutive: {employee.IsExecutive}");
        }

        System.Console.ReadLine();

    }
}