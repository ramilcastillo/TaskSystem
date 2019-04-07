    using System;
using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

namespace TaskSystem.DAL.Entities
{
    public partial class UserNames
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string OrgCode { get; set; }
        public bool? ActiveEmployee { get; set; }
        public string Email { get; set; }
        [Key]
        public string UserName { get; set; }
        public bool? AllowLogin { get; set; }
        public bool? AllowEditInfo { get; set; }
        public string PrivLevel { get; set; }
        public string Password { get; set; }
        public DateTime? AdupdateDate { get; set; }
        public bool? EmailWeekly { get; set; }
        public string PalviewDefault { get; set; }
        public bool? RedesignSuggReport { get; set; }
        public DateTime? AdwhenCreated { get; set; }
        public bool? DivLevel { get; set; }
        public bool? GovEmp { get; set; }
        public string ScriptPath { get; set; }
    }
}
