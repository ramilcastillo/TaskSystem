using System;

namespace TaskSystem.DAL.SP_DTO
{
    public class SP_GetTasksResponse
    {
        public int Id { get; set; }
        public DateTime TaskOwnerDuedate { get; set; }
        public DateTime TaskOwnerDate { get; set; }
        public string TaskOwnerComments { get; set; }
        public string Subject { get; set; }
        public string Requestor { get; set; }
        public string Status { get; set; }
        public string ParentUsername { get; set; }
        public string TaskOwner { get; set; }
    }
}
