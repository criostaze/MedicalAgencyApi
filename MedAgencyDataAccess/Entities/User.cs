using System;
using System.ComponentModel.DataAnnotations;

namespace MedAgencyDataAccess.Entities
{
	public class User
    {
        public long Id { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime BirthDate { get; set; }

        public string Adress { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string Salt { get; set; }
    }
}
