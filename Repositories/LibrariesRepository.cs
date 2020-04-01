using System.Collections.Generic;
using System.Data;
using Dapper;
using library_api.Models;

namespace library.Repositories
{
  public class LibraryRepository
  {
    private readonly IDbConnection _db;
    public LibraryRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Library> Get()
    {
      string sql = "SELECT * FROM libraries";
      return _db.Query<Library>(sql);
    }

    internal Library Get(int id)
    {
      string sql = "SELECT * FROM libraries WHERE id = @Id";
      return _db.QueryFirstOrDefault<Library>(sql, new { id });
    }

    internal Library Create(Library newLibrary)
    {
      string sql = @"
      INSERT INTO libraries
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();
      ";
      newLibrary.Id = _db.ExecuteScalar<int>(sql, newLibrary);
      return newLibrary;
    }

    internal void Edit(Library updated)
    {
      string sql = @"
      UPDATE libraries
      SET
          name = @Name
      WHERE id = @Id;
      ";
      _db.Execute(sql, updated);
    }

    internal bool Delete(int Id)
    {
      string sql = "DELETE FROM libraries WHERE id = @Id LIMIT 1";
      int deleted = _db.Execute(sql, new { Id });
      return deleted == 1;
    }
  }
}