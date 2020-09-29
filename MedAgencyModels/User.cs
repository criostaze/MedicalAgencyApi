using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedAgencyApi.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        private string hex { get; set; }
        public string soult { get; set; }
        //sdfsdfsdfsdf
    }
}
