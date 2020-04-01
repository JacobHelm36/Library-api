using System.Collections.Generic;
using System.Data;
using library_api.Models;
using Dapper;
using System;

namespace books.Repositories
{
    public class BooksRepository
    {
        private readonly IDbConnection _db;
        public BooksRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Bookers> Get()
        {
            string sql = "SELECT * FROM bookers";
            return _db.Query<Bookers>(sql);
        }

        //get by id
        public Bookers Get(int Id)
        {
            string sql = "SELECT * FROM bookers WHERE id = @Id";
            return _db.QueryFirstOrDefault<Bookers>(sql, new { Id });
        }

        //post
        public Bookers Create(Bookers newBook)
        {
            string sql = @"
            INSERT INTO bookers
            (title, pages, IsAvailable, lbId)
            VALUES
            (@Title, @Pages, true, @lbId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newBook);
            newBook.Id = id;
            newBook.IsAvailable = true;
            return newBook;
        }

        //put
        public Bookers Edit(Bookers updatedBook)
        {
            string sql = @"
            UPDATE bookers
            SET
                title = @Title, 
                pages = @Pages,
                isAvailable = @IsAvailable
            WHERE id = @Id;
            ";
            _db.Execute(sql, updatedBook);
            return updatedBook;
        }

    internal IEnumerable<Bookers> GetBooksByLsId(int Id)
    {
      string sql = @"
      SELECT * FROM bookers WHERE lsId = @Id";
      return _db.Query<Bookers>(sql, new { Id });
    }

    //delete
    public bool Delete(int Id)
        {
            string sql = "DELETE FROM bookers WHERE id = @Id LIMIT 1";
            int changed = _db.Execute(sql, new { Id });
            return changed == 1;
        }
    }
}