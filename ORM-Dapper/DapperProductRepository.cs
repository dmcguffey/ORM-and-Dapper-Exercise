using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    internal class DapperProductRepository : IProductReporsitory
    {

        private readonly IDbConnection _conn;

        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }


        public void CreateProduct(string name, double price, int categoryID)
        {
            _conn.Execute("INSERT INTO products (Name, Price, CategoryID ) VALUES (@name, @price, @categoryID);",
                new { name = name, price = price, categoryID = categoryID });
        }

        public void UpdateProduct(string name, double price, int categoryID)
        {
            _conn.Execute("UPDATE products SET Name = (@name), Price = (@price), CategoryID = (@categoryID)  WHERE Name = 'Zphone';",
                new { name = name, price = price, categoryID = categoryID });
        }

        public void DeleteProduct(int ProductID)
        {
            _conn.Execute("DELETE FROM sales WHERE ProductID = (@ProductID)", new { ProductID = ProductID });
            _conn.Execute("DELETE FROM reviews WHERE ProductID = (@ProductID)", new { ProductID = ProductID });
            _conn.Execute("DELETE FROM products WHERE ProductID = (@ProductID)", new { ProductID = ProductID });

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }
    }
}
