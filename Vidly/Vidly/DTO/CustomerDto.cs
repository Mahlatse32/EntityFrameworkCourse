using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.DTO
{
    public class CustomerDto
    {
        //public CustomerDto()
        //{
        //    Id = 0;
        //    Name = string.Empty;
        //    IsSubscribedToNewsLetter = false;
        //    MembershipTypeId = 1;
        //    BirthDay = DateTime.Now;
        //}
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //[Min18YrsIfMember]
        public DateTime? BirthDay { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }


                
    }
}