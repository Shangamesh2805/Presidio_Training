using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStoreManagmentAPI.Models
{
    public class UserCredential
    {
        [Key]
        public int UserId {  get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordHashKey { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public string Status { get; set; }

    }
}
