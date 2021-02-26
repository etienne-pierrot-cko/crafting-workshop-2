using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using BirthdayGreeting.Domain;
using CsvHelper;

namespace BirthdayGreeting.Infrastructure
{
    public class FileEmployeeRegistry : EmployeeRegistry
    {
        private List<Employee> _employees;

        public FileEmployeeRegistry()
            => _employees = ParseCSVFile().ToList();

        private IEnumerable<Employee> ParseCSVFile()
        {
            using var reader = new StreamReader("employees.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            SkipHeader(csv);
            while (csv.Read())
            {
                yield return new Employee(
                    csv.GetField<string>("first_name"),
                    csv.GetField<string>("last_name"),
                    csv.GetField<DateTime>("date_of_birth"),
                    csv.GetField<string>("email"));
            }
        }

        private static void SkipHeader(CsvReader csv)
        {
            csv.Read();
            csv.ReadHeader();
        }

        public List<Employee> GetAll()
            => _employees;
    }
}