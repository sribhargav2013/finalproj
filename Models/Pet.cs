using System.ComponentModel.DataAnnotations;

namespace finalproj.Models
{
    public class Pet
    {
        [Key]
        [Required]
        public string AnimalID { get; set; }

        public string Data_Source { get; set; }

        public string Link { get; set; }

        public string Current_Location { get; set; }

        public string Animal_Gender { get; set; }

        public string Animal_Breed { get; set; }

        public string Address { get; set; }

        public string Jurisdiction { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string ImageUrl { get; set; }

        public string Memo { get; set; }

        public string Temperament { get; set; }
    }
}
