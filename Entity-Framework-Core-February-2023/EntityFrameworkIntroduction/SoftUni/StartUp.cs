namespace SoftUni;

using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore;

using Data;
using Models;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();

        string result = GetAddressesByTown(dbContext);
        Console.WriteLine(result);
    }

    //Problem 3
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                Salary = e.Salary.ToString("f2")
            })
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary}");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 4
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Salary > 50000)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 5
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepName = e.Department.Name,
                e.Salary
            })
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepName} - ${e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 6 
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address address = new Address
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        Employee? employee = context.Employees
            .FirstOrDefault(e => e.LastName == "Nakov");
        employee.Address = address;

        context.SaveChanges();

        var addressTexts = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address!.AddressText)
            .ToArray();

        return String.Join(Environment.NewLine, addressTexts);
    }

    //Problem 7
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                MangagerFirstName = e.Manager.FirstName,
                ManagerLastName = e.Manager.LastName,
                Projects = e.EmployeesProjects
                    .Where(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003)
                    .Select(p => new
                    {
                        p.Project.Name,
                        StartDate = p.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = p.Project.EndDate.HasValue ? p.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                    })
            })
            .Take(10)
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.MangagerFirstName} {e.ManagerLastName}");

            foreach (var p in e.Projects)
            {
                sb.AppendLine($"--{p.Name} - {p.StartDate} - {p.EndDate}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 8 ?
    public static string GetAddressesByTown(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var addresses = context.Addresses
            .OrderByDescending(a => a.Employees.Count())
            .ThenBy(a => a.Town.Name)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .Select(a => new
            {
                a.AddressText,
                TownName = a.Town.Name,
                EmployeesCount = a.Employees.Count()
            })
            .ToArray();

        foreach (var a in addresses)
        {
            sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 9
    public static string GetEmployee147(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employee = context.Employees
            .Find(147);

        sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

        foreach (var p in employee.EmployeesProjects.OrderBy(p => p.Project.Name))
        {
            sb.AppendLine(p.Project.Name);
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 10
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var departments = context.Departments
            .Where(d => d.Employees.Count() > 5)
            .OrderBy(d => d.Employees.Count())
            .ThenBy(d => d.Name)
            .Select(d => new
            {
                d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                d.Employees
            })
            .ToArray();

        foreach (var dep in departments)
        {
            sb.AppendLine($"{dep.Name} - {dep.ManagerFirstName}  {dep.ManagerLastName}");

            foreach (var e in dep.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 11
    public static string GetLatestProjects(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var projects = context.Projects
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .OrderBy(p => p.Name)
            .Select(p => new
            {
                p.Name,
                p.Description,
                p.StartDate
            })
            .ToArray();

        foreach (var p in projects)
        {
            sb.AppendLine(p.Name);
            sb.AppendLine(p.Description);
            sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 12
    public static string IncreaseSalaries(SoftUniContext context)
    {
        const decimal increasementPercentage = 0.12m;

        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" }.Contains(e.Department.Name))
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToArray();

        foreach (var e in employees)
        {
            e.Salary += increasementPercentage * e.Salary;

            sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 13
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.FirstName.StartsWith("Sa"))
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 14
    public static string DeleteProjectById(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        const int projectToDeleteId = 2;

        var employeesProjectsToDelete = context.EmployeesProjects
            .Where(ep => ep.Project.ProjectId == projectToDeleteId)
            .ToArray();

        context.EmployeesProjects.RemoveRange(employeesProjectsToDelete);

        var projectToDelete = context.Projects.Find(projectToDeleteId);
        context.Projects.Remove(projectToDelete);

        context.SaveChanges();

        var projects = context.Projects
            .Take(10)
            .Select(p => new
            {
                p.Name
            })
            .ToArray();

        foreach (var p in projects)
        {
            sb.AppendLine(p.Name);
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 15
    public static string RemoveTown(SoftUniContext context)
    {
        //Finding the town we want to delete
        var town = context.Towns
            .FirstOrDefault(t => t.Name == "Seattle");

        //Finding the addresses that are referring to this town
        var addressesToDelete = context.Addresses
             .Where(a => a.TownId == town.TownId);

        int rowsAffected = addressesToDelete.Count();

        //Setting employee's addressId to null so that they do not refer to those addresses
        var employees = context.Employees
            .Where(e => addressesToDelete.Any(a => a.AddressId == e.AddressId));

        foreach (var e in employees)
        {
            e.AddressId = null;
        }

        //Deleting from Addresses
        context.Addresses.RemoveRange(addressesToDelete);

        //Deleting the Town
        context.Towns.Remove(town);

        context.SaveChanges();

        return $"{rowsAffected} addresses in Seattle were deleted";
    }
}