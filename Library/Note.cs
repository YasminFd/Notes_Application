using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime created_at { get; set; } =  DateTime.Now;


    }
}
