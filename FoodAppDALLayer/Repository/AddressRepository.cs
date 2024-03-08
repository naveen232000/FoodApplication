using FoodAppDALLayer.ApplicationDbContext;
using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly FoodAppDbContext _dbContext;

        public AddressRepository(FoodAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Address> GetAddressesByUserId(int userId)
        {
            return _dbContext.Addresses.Where(a => a.UserId == userId).ToList();
        }

        public void SaveAddress(Address address)
        {
            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();
        }
        public void Detach(Address entity)
        {
            var context = _dbContext as DbContext;
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            objectContext.Detach(entity);
        }
    }
}
