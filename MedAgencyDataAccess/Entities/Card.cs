using System;
using System.ComponentModel.DataAnnotations;

namespace MedAgencyDataAccess.Entities
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
