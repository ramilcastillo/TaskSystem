namespace TaskSystem.DTO.Task
{
    public class TaskCommentDetailRequest
    {
        public string TaskId { get; set; }
        public string Comment { get; set; }
        public string DateUpdate { get; set; }
        public string UserName { get; set; }
    }
}
