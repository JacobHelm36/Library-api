// using System.Data;
// using Dapper;
// using library_api.Models;

// namespace library_api.Repository
// {
//   public class BookAuthorsRepository 
//   {
//     private readonly IDbConnection _db;
//     public BookAuthorsRepository(IDbConnection db)
//     {
//       _db = db;
//     }

//             internal BookAuthors Create(BookAuthors newBookAuthors)
//         {
//             string sql = @"
//             INSERT INTO bookauthors 
//             (bkId, atId) 
//             VALUES 
//             (@BkId, @AtId);
//             SELECT LAST_INSERT_ID()";
//             newBookAuthors.Id = _db.ExecuteScalar<int>(sql, newBookAuthors);
//             return newBookAuthors;
//         }
//   }
// }