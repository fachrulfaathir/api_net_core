using System.ComponentModel.DataAnnotations.Schema;

namespace testing_net_api.Models
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = null;
        public string Author { get; set; } = null;

        public int YearPblished { get; set; }
    }
}
