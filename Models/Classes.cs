using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_marketplase_TRiZBD.Models
{
    public class Classes : DbContext
    {
        public class User
        {
            public int UserID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; } // В продакшене рекомендуется хранить хэши паролей, а не сами пароли
            public string Role { get; set; } // 'admin', 'employee'
        }

        public class Product
        {
            public int ProductID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }

        public class Order
        {
            public int OrderID { get; set; }
            public int UserID { get; set; }
            public DateTime OrderDate { get; set; }
            public virtual User User { get; set; }
            public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        }

        public class OrderDetail
        {
            public int OrderID { get; set; }
            public int ProductID { get; set; }
            public int Quantity { get; set; }
            public virtual Order Order { get; set; }
            public virtual Product Product { get; set; }
        }

        public class Warehouse
        {
            public int WarehouseID { get; set; }
            public string Location { get; set; }
            public virtual ICollection<WarehouseEmployee> WarehouseEmployees { get; set; }
        }

        public class WarehouseEmployee
        {
            public int WarehouseID { get; set; }
            public int UserID { get; set; }
            public virtual Warehouse Warehouse { get; set; }
            public virtual User User { get; set; }
        }


    }

}
