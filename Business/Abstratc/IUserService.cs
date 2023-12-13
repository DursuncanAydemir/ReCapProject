using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstratc
{
    public interface IUserService
    {
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<User> Get(int userId);
        IDataResult<List<User>> GetAll();
        List<OperationClaim> GetClaims(User user);
        IResult Add(User user);
        User GetByMail(string email);
    }
}
