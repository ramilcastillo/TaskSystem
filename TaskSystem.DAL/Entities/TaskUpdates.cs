using System;
using System.Collections.Generic;

namespace TaskSystem.DAL.Entities
{
    public class TaskUpdates
    {
        public int Id { get; set; }
        public int? TaskId { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string Comment { get; set; }
        public float? Labor { get; set; }
        public string UserName { get; set; }
        public bool? Deleted { get; set; }
    }
}
