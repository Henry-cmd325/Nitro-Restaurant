using System.ComponentModel.DataAnnotations;

namespace ApiNitroRestaurant.Models.Request
{
    public class AccountRequest
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
