using System;
using System.Collections.Generic;
using books.Repositories;
using library_api.Models;
// using library_api.Repositories;

namespace books.Services
{
    public class BooksService
    {
        private readonly BooksRepository _repo;
        public BooksService(BooksRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Bookers> Get()
        {
            return _repo.Get();
        }

        public Bookers Get(int id)
        {
            Bookers found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        public Bookers Create(Bookers newVid)
        {
            return _repo.Create(newVid);
        }

        public Bookers Edit(Bookers updatedBook)
        {
            Bookers exists = _repo.Get(updatedBook.Id);
            if (exists == null)
            {
                throw new Exception("Invalid Id");
            }
            return _repo.Edit(updatedBook);
        }

        public string Delete(int id)
        {
            Bookers exists = _repo.Get(id);
            if (exists == null)
            {
                throw new Exception("Invalid Id");
            }
            //if you are the creator
            if (_repo.Delete(id))
            {
                return "Success";
            }
            throw new Exception("Something went wrong with deleting that item");
        }

    internal IEnumerable<Bookers> GetBooksByLsId(int id)
    {
        return _repo.GetBooksByLsId(id);
    }
  }
}