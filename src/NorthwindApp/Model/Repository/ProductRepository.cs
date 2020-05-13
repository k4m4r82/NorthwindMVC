using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Dapper;

using NorthwindApp.Model.Entity;
using NorthwindApp.Model.Context;

namespace NorthwindApp.Model.Repository
{
    public interface IProductRepository
    {
        int Save(Product obj);
        int Update(Product obj);
        int Delete(Product obj);

        IList<Product> GetAll();
    }

    public class ProductRepository : IProductRepository
    {
        private readonly IDbContext _context;

        public ProductRepository(IDbContext context)
        {
            _context = context;
        }

        public int Save(Product obj)
        {
            var result = 0;

            try
            {
                var sql = @"insert into products (product_name, unit_price, unit_in_stock, qty_per_unit)
                            values (@product_name, @unit_price, @unit_in_stock, @qty_per_unit);
                            select last_insert_id()";
                obj.product_id = _context.Conn.ExecuteScalar<int>(sql, obj);
                result = 1;
            }
            catch
            {
            }

            return result;
        }

        public int Update(Product obj)
        {
            var result = 0;

            try
            {
                var sql = @"update products set product_name = @product_name, 
                            unit_price = @unit_price, 
                            unit_in_stock = @unit_in_stock,
                            qty_per_unit = @qty_per_unit
                            where product_id = @product_id";
                obj.product_id = _context.Conn.Execute(sql, obj);
                result = 1;
            }
            catch
            {
            }

            return result;
        }

        public int Delete(Product obj)
        {
            var result = 0;

            try
            {
                var sql = @"delete from products
                            where product_id = @product_id";
                obj.product_id = _context.Conn.Execute(sql, obj);
                result = 1;
            }
            catch
            {
            }

            return result;
        }

        public IList<Product> GetAll()
        {
            var list = new List<Product>();

            try
            {
                var sql = @"select product_id, product_name, unit_price, unit_in_stock, qty_per_unit 
                            from products
                            order by product_name";
                list = _context.Conn.Query<Product>(sql)
                               .ToList();
            }
            catch
            {
            }

            return list;
        }
    }
}
