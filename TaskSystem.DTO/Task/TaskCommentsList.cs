using System;
using System.ComponentModel.DataAnnotations;

namespace TaskSystem.DTO.Task
{
    public class TaskCommentsList
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CommentsDate { get; set; }
        public string Comments { get; set; }
        public string AddedBy { get; set; }
        public string AssignedBy { get; set; }
    }
}
