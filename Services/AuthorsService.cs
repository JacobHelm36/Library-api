using System;
using System.Collections.Generic;
using library_api.Models;
using library_api.Repository;

namespace library_api.Services
{
  public class AuthorsService
  {
    private readonly AuthorsRepository _repo;
    public AuthorsService(AuthorsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Author> Get()
    {
          return _repo.GetPublic();
    }

    internal Author Get(int id)
    {
      Author found = _repo.Get(id);
      if(found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Author Create(Author newAuthor)
    {
      return _repo.Create(newAuthor);
    }
  }
}