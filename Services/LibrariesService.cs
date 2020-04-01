using System;
using System.Collections.Generic;
using library.Repositories;
using library_api.Models;
// using library_api.Repositories;

namespace library.Services
{
  public class LibraryService
  {
    private readonly LibraryRepository _repo;
    public LibraryService(LibraryRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Library> Get()
    {
      return _repo.Get();
    }

    internal Library Get(int id)
    {
      Library found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Library Create(Library newLibrary)
    {
      Library created = _repo.Create(newLibrary);
      if (created == null)
      {
        throw new Exception("Create request failed");
      }
      return created;
    }

    internal Library Edit(Library updatedLibrary)
    {
      Library original = Get(updatedLibrary.Id);
      original.Name = updatedLibrary.Name;
      _repo.Edit(original);
      return original;
    }

    // internal Library Delete(int id)
    // {
    //   Library exists = _repo.Get(id);
    //     if (exists == null)
    //     {
    //         throw new Exception("Invalid Id");
    //     }
    //     if (_repo.Delete(id))
    //     {
    //       // why???
    //         return exists;
    //     }
    //     throw new Exception("Something went wrong with deleting that item");
    // }
  }
}