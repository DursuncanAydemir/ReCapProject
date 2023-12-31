﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstratc
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<List<Car>> GetCarsByBrandId(int id);

        IDataResult<List<Car>> GetCarsByColorId(int id);

        Result Add(Car car);

        Result Update(Car car);

        Result Delete(Car car);

        IDataResult<List<CarDetailDto>> GetCarDetails();

        Result  AddTransactionalTest(Car car);


    }
}
