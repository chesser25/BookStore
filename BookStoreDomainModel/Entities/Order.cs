using System.ComponentModel.DataAnnotations;

namespace BookStoreDomainModel.Entities
{
    public class Order
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        public int HomeNumber { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your country")]
        public string Country { get; set; }
    }
}
