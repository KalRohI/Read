using Read.DataAccess.Data;
using Read.DataAccess.Repository.IRepository;
using Read.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            var objFromDB = _db.Products.FirstOrDefault(u=> u.Id == obj.Id);
            if (objFromDB != null)
            {
                objFromDB.Title = obj.Title;
                objFromDB.ISBN = objFromDB.ISBN;
                objFromDB.Price = objFromDB.Price;
                objFromDB.Price50 = objFromDB.Price50;
                objFromDB.Price100 = objFromDB.Price100;
                objFromDB.ListPrice = objFromDB.ListPrice;
                objFromDB.Author = objFromDB.Author;
                objFromDB.Description = obj.Description;
                objFromDB.CategoryID = obj.CategoryID; 
                if(obj.ImageURL != null)
                {
                    objFromDB.ImageURL = obj.ImageURL;
                }

            }
        }
    }
}
