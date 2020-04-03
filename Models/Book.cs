using System.ComponentModel.DataAnnotations;

namespace library_api.Models
{
    public class Bookers
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Pages { get; set; }
        public bool IsAvailable { get; set; }
        public int lbId { get; set; }
    }


    public class BookAuthors
    {
        public int Id {get; set; }
        public int BkId { get; set; }
        public int AtId { get; set; }
    }
}