using System;
using System.Collections.Generic;
using TaskSystem.DTO.Task;

namespace TaskSystem.BusinessLogic.DTO
{
    public class BlTaskDetailResponse
    {
        /// <summary>
        /// Task ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Task Pocusername
        /// </summary>
        public string Pocsusername { get; set; }
        /// <summary>
        /// Parent Username
        /// </summary>
        public string ParentUsername { get; set; }
        /// <summary>
        /// OpenDate
        /// </summary>
        //public DateTime? PocdateAssigned { get; set; }
        public string PocdateAssigned { get; set; }
        /// <summary>
        /// PocdateDue
        /// </summary>
        //public DateTime? PocdateDue { get; set; }
        public string PocdateDue { get; set; }
        /// <summary>
        /// Close Date
        /// </summary>
        //public DateTime? PocdateClosed { get; set; }
        public string PocdateClosed { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        //public BlTaskStatusEnum Status { get; set; }
        public string Status { get; set; }
        /// <summary>
        /// Task Type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Requested By
        /// </summary>
        public string Requestor { get; set; }
        /// <summary>
        /// File Number
        /// </summary>
        public string FileNumber { get; set; }
        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Action Required
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Task Pocusername Date
        /// </summary>
        //public DateTime? PocpersonalDate { get; set; }
        public string PocpersonalDate { get; set; }
        /// <summary>
        /// Task Pocusername Comments
        /// </summary>
        public string PocpersonalNote { get; set; }

        public IEnumerable<TaskCommentDetailResponse> TaskComments { get; set; }
        public IEnumerable<TaskPOCDetailRequest> TaskPocs { get; set; }
        public IEnumerable<TaskFileResponse> Files { get; set; }
    }
}
