using ConsoleApp1.Context;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new();
            /*
            List<Department> departments = [
                new(){Name = "Dept1"},
                new(){Name = "Dept2"},
                new(){Name = "Dept3"},
                new(){Name = "Dept4"},
                new(){Name = "Dept5"},
            ];
            context.AddRange(departments);

            
            List<Student> stds = [
                new(){Age = new Random().Next(5 , 40) , Salary = new Random().Next(5000 , 40000) , Name="Ali" , DepartmentId =1},
                new(){Age = new Random().Next(5 , 40) , Salary = new Random().Next(5000 , 40000) , Name="Mohammed" , DepartmentId = 1},
                new(){Age = new Random().Next(5 , 40) , Salary = new Random().Next(5000 , 40000) , Name="Ziad" , DepartmentId = 1},
                new(){Age = new Random().Next(5 , 40) , Salary = new Random().Next(5000 , 40000) , Name="Hossam" , DepartmentId = 1},
                new(){Age = new Random().Next(5 , 40) , Salary = new Random().Next(5000 , 40000) , Name="Khaled" , DepartmentId = 2},
                new(){Age = new Random().Next(5 , 40) , Salary = new Random().Next(5000 , 40000) , Name="Mohammed" , DepartmentId = 2},
                new(){Age = new Random().Next(5 , 40) , Salary = new Random().Next(5000 , 40000) , Name="Ibrahem" , DepartmentId = 3},
                new(){Age = new Random().Next(5 , 40) , Salary = new Random().Next(5000 , 40000) , Name="Mohsen" , DepartmentId = 4},
                new(){Age = new Random().Next(5 , 40) , Salary = new Random().Next(5000 , 40000) , Name="Osama" , DepartmentId = 5},
                new(){Age = new Random().Next(5 , 40) , Salary = new Random().Next(5000 , 40000) , Name="Hani", DepartmentId = 4},
            ];
            context.AddRange(stds);
            context.SaveChanges();
            */

            Console.WriteLine();
            Console.WriteLine("----------students----------");
            Console.WriteLine();
            var students = context.Students.ToList();
            foreach(var item in students)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("----------departments----------");
            Console.WriteLine();
            var departments = context.Departments.ToList();
            foreach(var item in departments)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("----------studentsWithDepts----------");
            Console.WriteLine();
            var studentsWithDepts = context.Students.Include(s=>s.Department);
            foreach (var item in studentsWithDepts)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine();
            Console.WriteLine("----------stdDept1----------");
            Console.WriteLine();
            var stdDept1 = studentsWithDepts.Where(s => s.DepartmentId == 1);
            foreach (var item in stdDept1)
            {
                Console.WriteLine(item);
            }
            
            var stdDept1Sorted = stdDept1.OrderByDescending(s => s.Name);
            Console.WriteLine();
            Console.WriteLine("----------stdDept1Sorted----------");
            Console.WriteLine();

            foreach (var item in stdDept1Sorted)
            {
                Console.WriteLine(item);
            }

           //---------- Lab2 -------------------
            var allStds = from e in context.Students
                          select e;
            Console.WriteLine();
            Console.WriteLine("---------allStds-----------");
            Console.WriteLine();

            foreach (var item in allStds)
            {
                Console.WriteLine(item);
            }
            allStds = context.Students; // fluent

            Console.WriteLine();
            Console.WriteLine("----------stdsOlderThan30----------");
            Console.WriteLine();

            var stdsOlderThan30 = context.Students.Where(s => s.Age > 30);
            foreach (var item in stdsOlderThan30)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("----------stdsSalaryLessThan5000----------");
            Console.WriteLine();

            var stdsSalaryLessThan5000 = context.Students.Where(s => s.Salary < 5000);
            foreach (var item in stdsSalaryLessThan5000)
            {
                Console.WriteLine(item);
            }



            var stdsDept1_SalaryGT4000_ObyNameDesc = context.Students
                .Where(s => s.DepartmentId == 1 && s.Salary > 4000)
                .OrderByDescending(s=>s.Name);
            Console.WriteLine();
            Console.WriteLine("----------stdsDept1_SalaryGT4000_ObyNameDesc----------");
            Console.WriteLine();

            foreach (var item in stdsDept1_SalaryGT4000_ObyNameDesc)
            {
                Console.WriteLine(item);
            }

            var stds_dept1_nameContainsM = context.Students.Where(s => s.DepartmentId == 1 && s.Name.ToLower().Contains('m'));
            Console.WriteLine();
            Console.WriteLine("----------stds_dept1_nameContainsM----------");
            Console.WriteLine();

            foreach (var item in stds_dept1_nameContainsM)
            {
                Console.WriteLine(item);
            }

            var firstStd_salaryGT5000 = context.Students.FirstOrDefault(s => s.Salary > 5000);
            Console.WriteLine();
            Console.WriteLine("----------firstStd_salaryGT5000----------");
            Console.WriteLine();
            Console.WriteLine(firstStd_salaryGT5000);

            try
            {
                var firstStd_salaryGT5000_v2 = context.Students.First(s => s.Salary > 5000);
                Console.WriteLine();
                Console.WriteLine("----------firstStd_salaryGT5000_v2----------");
                Console.WriteLine();
                Console.WriteLine(firstStd_salaryGT5000_v2);
            }
            catch
            { Console.WriteLine("----------firstStd_salaryGT5000_v2----------");
                Console.WriteLine("There is no student with salary greater than 5000");
            }


            try
            {
                var lastStd_dept10 = context.Students.Where(s=>s.DepartmentId == 10).ToList().Last();
                Console.WriteLine();
                Console.WriteLine("----------lastStd_dept10----------");
                Console.WriteLine();
                Console.WriteLine(lastStd_dept10);
            }
            catch
            {Console.WriteLine("----------lastStd_dept10----------");
                Console.WriteLine("no std in department 10");
            }

            try
            {
                var lastStd_dept10_v2 = context.Students.LastOrDefault(s => s.DepartmentId == 10);
                Console.WriteLine();
                Console.WriteLine("-----------lastStd_dept10_v2---------");
                Console.WriteLine();
                Console.WriteLine(lastStd_dept10_v2);
            }
            catch
            {Console.WriteLine("-----------lastStd_dept10_v2---------");
                Console.WriteLine("There is no student in Dept 10");
            }





            try
            {
                var onlyStd_ageEQ25 = context.Students.SingleOrDefault(s => s.Age == 25);
                Console.WriteLine();
                Console.WriteLine("----------onlyStd_ageEQ25----------");
                Console.WriteLine();
                Console.WriteLine(onlyStd_ageEQ25);
            }
            catch
            {                Console.WriteLine("----------onlyStd_ageEQ25----------");

                Console.WriteLine("Many stds are 25 YO");
            }

            try
            {
                var onlyStd_ageEQ25_v2 = context.Students.Single(s => s.Age == 25);
                Console.WriteLine();
                Console.WriteLine("----------onlyStd_ageEQ25_v2----------");
                Console.WriteLine();
                Console.WriteLine(onlyStd_ageEQ25_v2);
            }
            catch
            {                Console.WriteLine("----------onlyStd_ageEQ25_v2----------");

                Console.WriteLine("Many or no stds are 25 YO");
            }





            try
            {
                var onlyStd_dept4 = context.Students.SingleOrDefault(s => s.DepartmentId == 4);
                Console.WriteLine();
                Console.WriteLine("----------onlyStd_dept4----------");
                Console.WriteLine();
                Console.WriteLine(onlyStd_dept4);
            }
            catch
            {                Console.WriteLine("----------onlyStd_dept4----------");

                Console.WriteLine("Many stds are in department 4");
            }

            try
            {
                var onlyStd_dept4_v2 = context.Students.Single(s => s.DepartmentId == 4);
                Console.WriteLine();
                Console.WriteLine("----------onlyStd_dept4_v2----------");
                Console.WriteLine();
                Console.WriteLine(onlyStd_dept4_v2);
            }
            catch
            {                Console.WriteLine("----------onlyStd_dept4_v2----------");

                Console.WriteLine("Many or no stds are in department 4");
            }


            
            context.SaveChanges();
        }
    }
}
