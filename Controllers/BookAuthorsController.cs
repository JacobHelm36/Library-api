// using System;
// using System.Security.Claims;
// using books.Services;
// using library_api.Models;
// using library_api.Services;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// namespace library_api.Controller
// {
//   [ApiController]
//   [Route("api/[controller")]
//   public class BookAuthorsController : ControllerBase
//   {
//     private readonly BookAuthorsService _service;
//     private readonly BooksService _bs;
//     public BookAuthorsController(BookAuthorsService service, BooksService bs)
//     {
//       _service = service;
//       _bs = bs;
//     }
//   [HttpPost]
//   [Authorize]
//   public ActionResult<BookAuthors> Create([FromBody] BookAuthors newBookAuthors)
//   {
//     try
//     {
//         string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
//         newBookAuthors.AtId = userId;
//         return Ok(_service.Create(newBookAuthors));
//     }
//     catch (Exception e)
//     {
//         return BadRequest(e.Message);
//     }
//   }
//   }


// }