using System;

namespace TaskSystem.DAL.Entities
{
    public class TaskOwners
    {
        public int Id { get; set; }
        public int TaskOwnerId { get; set; }
        public string TaskOwnerName { get; set; }
        public DateTime? TaskOwnerDateClosed { get; set; }
        public DateTime? TaskOwnerDateAssigned { get; set; }
        public string ParentUsername { get; set; }
        public DateTime? TaskOwnerDuedate { get; set; }
        public string TaskOwnerSort { get; set; }
        public int? TaskOwnerLevel { get; set; }
        public bool? TaskOwnerFlag { get; set; }
        public string TaskOwnerComments { get; set; }
        public DateTime? TaskOwnerDate { get; set; }
    }
}
