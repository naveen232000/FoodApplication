using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Interface
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddressesByUserId(int userId);
        IEnumerable<Address> GetAddressesById(int id);
        void DeleteAddress(int adsid);
        void SaveAddress(Address address);
        void Detach(Address rest);

    }
}
