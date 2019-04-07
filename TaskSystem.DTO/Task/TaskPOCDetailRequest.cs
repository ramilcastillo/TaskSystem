using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TaskSystem.DTO.Task
{
    public class TaskPOCDetailRequest
    {
        public int Id { get; set; }
        public int PoctaskId { get; set; }
        public string ParentUsername { get; set; }
        public string Pocusername { get; set; }
        public string PocdateAssigned { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? PocdateClosed { get; set; }
        //public string PocdateClosed { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? PocdateDue { get; set; }
        //public string PocdateDue { get; set; }
    }
}
