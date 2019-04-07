using System;

namespace TaskSystem.DAL.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public short Priority { get; set; }
        public string Orgcode { get; set; }
        public string FileNumber { get; set; }
        public string Requestor { get; set; }
        public string Status { get; set; }
        public int? RecurringId { get; set; }
        public DateTime? DeletionFlag { get; set; }
    }
}
