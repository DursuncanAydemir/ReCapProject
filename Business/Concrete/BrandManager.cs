using Business.Abstratc;
using Core.Aspects.Autofac.Caching;
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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        [CacheAspect]

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        [CacheAspect]

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == brandId));
        }

        public IResult Delete(Brand brand)
        {
            Brand brandToDelete = _brandDal.Get(b=>b.BrandId == brand.BrandId);
            _brandDal.Delete(brandToDelete);
            return new SuccessResult();
        }

        public IResult Update(Brand brand)
        {
            Brand brandToUpdate = _brandDal.Get(b=>b.BrandId==brand.BrandId);
            brandToUpdate.BrandId = brand.BrandId;
            brandToUpdate.BrandName = brand.BrandName;
            return new SuccessResult();
        }
    }
}
