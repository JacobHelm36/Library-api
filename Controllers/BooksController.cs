using System;
using System.Collections.Generic;
using books.Services;
using library_api.Models;
// using library_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace books.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _vs;
        // NOTE Dependency Injection
        public BooksController(BooksService vs)
        {
            _vs = vs;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Bookers>> Get()
        {
            try
            {
                return Ok(_vs.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<Bookers> Get(int id)
        {
            try
            {
                return Ok(_vs.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public ActionResult<Bookers> Create([FromBody] Bookers newBook)
        {
            try
            {
                return Ok(_vs.Create(newBook));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Bookers> Edit(int id, [FromBody] Bookers updatedBook)
        {
            try
            {
                updatedBook.Id = id;
                return Ok(_vs.Edit(updatedBook));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                return Ok(_vs.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}