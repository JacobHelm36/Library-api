using System;
using System.Collections.Generic;
using System.Security.Claims;
using library_api.Models;
using library_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace library_api.Controller
{
  [ApiController]
  [Route("api/[controller]")]

  public class AuthorsController : ControllerBase
  {
    private readonly AuthorsService _as;

    public AuthorsController(AuthorsService ass)
    {
      _as = ass;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Author>> Get()
    {
      try
      {
          return Ok(_as.Get());
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            try
            {
                return Ok(_as.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Author> Create([FromBody] Author newAuthor)
        {
            try
            {
                // req.user.sub || req.userInfo.sub
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
                newAuthor.Name = userId;
                return Ok(_as.Create(newAuthor));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // TODO create deleted path
  }
}