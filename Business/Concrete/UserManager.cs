using Business.Abstratc;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstratc;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    
        public class UserManager : IUserService
        {
            IUserDal _userDal;
            public UserManager(IUserDal userDal)
            {
                _userDal = userDal;
            }

            public IResult Add(User user)
            {
                _userDal.Add(user);
                return new SuccessResult();
            }

            public IResult Delete(User user)
            {
                User userToDelete= _userDal.Get(u=>u.Id==user.Id);
                _userDal.Delete(userToDelete);
                return new SuccessResult();
            }

            public IDataResult<User> Get(int userId)
            {
                return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
            }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Update(User user)
            {
                User userToUpdate= _userDal.Get(u=>u.Id==user.Id);
                _userDal.Update(userToUpdate);
                return new SuccessResult();
            }
        }
    }
