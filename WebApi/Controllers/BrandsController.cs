﻿using Business.Abstratc;
using DataAccess.Abstratc;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll() 
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult Get(int id) 
        {
            var result = _brandService.GetById(id);
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]

        public IActionResult Add(Brand brand) 
        {
            var result = _brandService.Add(brand);
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]

        public IActionResult Update(Brand brand) 
        {
            var result = _brandService.Update(brand);
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]

        public IActionResult Delete(Brand brand) 
        {
            var result = _brandService.Delete(brand);
            if(result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
