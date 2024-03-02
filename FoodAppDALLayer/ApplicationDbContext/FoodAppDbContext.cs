using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace FoodAppDALLayer.ApplicationDbContext
{
    public class FoodAppDbContext:DbContext
    {
        public FoodAppDbContext():base("name=FoodAppDb")
        {
            
        }

    }
}
