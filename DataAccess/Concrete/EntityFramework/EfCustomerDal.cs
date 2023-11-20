using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstratc;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,RentACarContext>, ICustomerDal
    {

    }
}
