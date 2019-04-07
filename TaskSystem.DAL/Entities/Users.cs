using System;
using System.ComponentModel.DataAnnotations;

namespace TaskSystem.DAL.Entities
{
    public partial class Users
    {
        [Key]
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Ocode { get; set; }
        public bool? ActiveFt { get; set; }
        public string Email { get; set; }
        public bool? AllowLogin { get; set; }
        public bool? AllowEditInfo { get; set; }
        public string PrivLevel { get; set; }
        public string Password { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? WeeklyEmail { get; set; }
        public string DefaultView { get; set; }
        public bool? Reported { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Allign { get; set; }
        public bool? Ftemp { get; set; }
        public string Stpath { get; set; }
    }
}
