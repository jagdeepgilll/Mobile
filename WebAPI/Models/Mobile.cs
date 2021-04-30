using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Mobile
    {
        //Mobiles primary key
        [Key]
        public int Id { get; set; }

        //Mobile reg
        public string Reg { get; set; }

        //Mobile make
        public string Make { get; set; }

        //Mobile model
        public string Model { get; set; }

        //Mobile colour
        public string Colour { get; set; }

        //Mobile year
        public int Year { get; set; }
    }
}