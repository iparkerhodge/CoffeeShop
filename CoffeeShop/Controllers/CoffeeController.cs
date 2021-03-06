﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CoffeeShop.Models;
using CoffeeShop.Repositories;

namespace CoffeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly CoffeeRepository _coffeeRepository;
        public CoffeeController(IConfiguration configuration)
        {
            _coffeeRepository = new CoffeeRepository(configuration);
        }

        // https://localhost:5001/api/coffee/
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_coffeeRepository.GetAll());
        }

        // https://localhost:5001/api/coffee/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var variety = _coffeeRepository.Get(id);
            if (variety == null)
            {
                return NotFound();
            }
            return Ok(variety);
        }

        // https://localhost:5001/api/coffee/
        [HttpPost]
        public IActionResult Post(Coffee beanVariety)
        {
            _coffeeRepository.Add(beanVariety);
            return CreatedAtAction("Get", new { id = beanVariety.Id }, beanVariety);
        }

        // https://localhost:5001/api/coffee/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Coffee beanVariety)
        {
            if (id != beanVariety.Id)
            {
                return BadRequest();
            }

            _coffeeRepository.Update(beanVariety);
            return NoContent();
        }

        // https://localhost:5001/api/coffee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _coffeeRepository.Delete(id);
            return NoContent();
        }
    }
}