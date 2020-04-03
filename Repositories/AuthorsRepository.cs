using System.Collections.Generic;
using System.Data;
using Dapper;
using library_api.Models;

namespace library_api.Repository
{
  public class AuthorsRepository
  {
    private readonly IDbConnection _db;
    public AuthorsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Author> GetPublic()
    {
      string sql = "SELECT * FROM authors";
      return _db.Query<Author>(sql);
    }

        internal Author Get(int id)
    {
        string sql = "SELECT * FROM authors WHERE id = @Id";
        return _db.QueryFirstOrDefault<Author>(sql, new { Id = id });
    }

            internal Author Create(Author newAuthor)
        {
            string sql = @"
            INSERT INTO authors 
            (name) 
            VALUES 
            (@Name);
            SELECT LAST_INSERT_ID()";
            newAuthor.Id = _db.ExecuteScalar<int>(sql, newAuthor);
            return newAuthor;
        }
  }
}