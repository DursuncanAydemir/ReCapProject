using Business.Abstratc;
using Business.Constants;
using Core.Helpers.FileHelper;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstratc;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;


        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));//mevcut iş kuralı varsa onu çalıştırır.
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _fileHelper.Upload(file, PathConstant.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("image uploaded successfully :)");
        }

        public IResult Delete(CarImage carImages)
        {
            _fileHelper.Delete(PathConstant.ImagesPath + carImages.ImagePath);
            //pathconstants.ImagePath ifadesi, resim dosyalarının bulunduğu dosya yolunu temsil eder, carimage.ımagepath ise silinecek resim dosyasının yolunu içerir. Bu iki ifade birleştirilerek silinecek resim dosyasının tam yolu elde edilir

            _carImageDal.Delete(carImages);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                //eğer araba resmi varsa hata
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            //eger araba resmi yoksa default resmi getiriyor
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(x => x.Id == imageId));
        }

        public IResult Update(IFormFile file, CarImage carImages)
        {
            carImages.ImagePath = _fileHelper.Update(file, PathConstant.ImagesPath + carImages.ImagePath, PathConstant.ImagesPath);
            //mevcut resim dosyalarının bulunduğu klasor yoluna yeni resim yolu eklenir
            _carImageDal.Update(carImages);
            return new SuccessResult();

        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            //maximum resim boyutunu kontrol ediyor. eğer bir arabanın 5 den fazla resmi varsa error
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }


        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage
            {
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = "DefaultImage.jpg"
            });

            return new SuccessDataResult<List<CarImage>>(carImage);
        }
    }
}
