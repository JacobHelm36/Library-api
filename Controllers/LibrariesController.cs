using System;
using System.Collections.Generic;
using books.Services;
using library.Services;
using library_api.Models;
using Microsoft.AspNetCore.Authorization;
// using library_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LibraryController : ControllerBase
  {
    private readonly LibraryService _ls;
    private readonly BooksService _bs;
    public LibraryController(LibraryService ls, BooksService bs)
    {
      _ls = ls;
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Library>> Get()
    {
      try
      {
          return Ok(_ls.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Library> Get(int id)
    {
      try
      {
          return Ok(_ls.Get(id));
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/books")]
    public ActionResult<IEnumerable<Bookers>> GetBooksByLsId(int id)
    {
      try
      {
          return Ok(_bs.GetBooksByLsId(id));
      }
      catch (Exception e)
      {          
          return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Library> Create([FromBody] Library newLibrary)
    {
      try
      {
          return Ok(_ls.Create(newLibrary));
      }
      catch (Exception e)
      {          
          return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<LibraryController> Update(int id, [FromBody] Library updatedLibrary)
    {
      try
      {
          updatedLibrary.Id = id;
          return Ok(_ls.Edit(updatedLibrary));
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    // [HttpDelete("{id}")]
    // public ActionResult<Library> Delete(int id)
    // {
    //   try
    //   {
    //       return Ok(_ls.Delete(id));
    //   }
    //   catch (Exception e)
    //   {
    //       return BadRequest(e.Message);
    //   }
    // }
  }
}