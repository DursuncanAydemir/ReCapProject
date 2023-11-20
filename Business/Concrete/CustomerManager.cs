using Business.Abstratc;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            Customer customerToDelete= _customerDal.Get(cu=>cu.UserId==customer.UserId);
            _customerDal.Delete(customerToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
           return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<List<Customer>> GetById(int customerId)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(cu=>cu.UserId==customerId));
        }

        public IResult Update(Customer customer)
        {
            Customer customerToUpdate = _customerDal.Get(cu => cu.UserId == customer.UserId);
            customerToUpdate.UserId = customer.UserId;
            customerToUpdate.CompanyName = customer.CompanyName;
            return new SuccessResult();
            
        }
    }
}
