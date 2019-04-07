using System;
using System.ComponentModel.DataAnnotations;

namespace TaskSystem.DTO.Task
{
    public class TaskPOCList
    {
        public string PocName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateAssigned { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DueDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateClosed { get; set; }
        public string AssignedBy { get; set; }
    }
}
