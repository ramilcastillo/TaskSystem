using System;
using System.ComponentModel.DataAnnotations;


namespace TaskSystem.BusinessLogic.DTO
{
    public class BL_TaskListResponseDetail
    {
        public int Id { get; set; }
        public string FileNumber { get; set; }
        public string PocdateDue { get; set; }
        public string PocpersonalDate { get; set; }
        public string PocpersonalNote { get; set; }
        public string Requestor { get; set; }
        public string Pocusername { get; set; }
        //public BlTaskStatusEnum Status { get; set; }
        public string Status { get; set; }
        public string Subject { get; set; }
    }
}