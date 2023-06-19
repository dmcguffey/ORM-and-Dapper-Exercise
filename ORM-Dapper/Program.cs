using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            Console.WriteLine("===== Departments =====");

            var departmentRepo = new DapperDepartmentRepository(conn);

            departmentRepo.InsertDepartment("Dave's Faves");

           var departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
                Console.WriteLine();
            }

            Console.WriteLine("===== Products =====");

            var productRepo = new DapperProductRepository(conn);

            productRepo.CreateProduct("Zphone", 5000.00, 3);

            var products = productRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} / {product.Price} / {product.CategoryID}");
            }

            Console.WriteLine("UPDATE PRDUCT");

            productRepo.UpdateProduct("Iphone", 799.99, 3);

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} / {product.Price} / {product.CategoryID}");
            }

            productRepo.DeleteProduct(951);

            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} / { product.Name} / {product.Price} / {product.CategoryID}");
            }
        }
    }
}
