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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
            Color colorToDelete = _colorDal.Get(c=>c.ColorId == color.ColorId);
            _colorDal.Delete(colorToDelete);
            return new SuccessResult();

        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<List<Color>> GetById(int colorId)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c=>c.ColorId==colorId));
        }

        public IResult Update(Color color)
        {
            Color colorToUpdate = _colorDal.Get(c=>c.ColorId==color.ColorId);
            colorToUpdate.ColorId = color.ColorId;
            colorToUpdate.ColorName = color.ColorName;
            return new SuccessResult();

        }
    }
}
