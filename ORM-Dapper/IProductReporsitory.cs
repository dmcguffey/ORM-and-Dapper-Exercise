using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    internal interface IProductReporsitory
    {
        IEnumerable<Product> GetAllProducts();

        void CreateProduct(string name, double price, int categoryID);

        void UpdateProduct(string name, double price, int categoryID);

        void DeleteProduct(int ProductID);  
    }
}
