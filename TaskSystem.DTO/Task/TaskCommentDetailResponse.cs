using System;

namespace TaskSystem.DTO.Task
{
    public class TaskCommentDetailResponse
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime DateUpdate { get; set; }
        public string UserName { get; set; }
    }
}
