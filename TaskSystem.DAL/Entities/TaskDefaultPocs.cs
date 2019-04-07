using System;
using System.Collections.Generic;

namespace TaskSystem.DAL.Entities
{
    public partial class TaskDefaultPocs
    {
        public int Id { get; set; }
        public string ActualUser { get; set; }
        public string DefaultPoc { get; set; }
    }
}
