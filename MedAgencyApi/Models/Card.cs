using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedAgencyApi.Models
{
    public class Card
    {
        public int Id { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public string PersonalId { get; set; }

        // Foreign Key
        public long UserId { get; set; }
        //Navigation property
        public User User { get; set; }

    }
}
