using System.ComponentModel.DataAnnotations;

namespace Hotel.ATR.Web.First.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public string FullName { get; set; }
        public string Description { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public string ImageUrl { get; set; }
    }
}