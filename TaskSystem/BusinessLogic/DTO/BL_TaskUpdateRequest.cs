namespace TaskSystem.BusinessLogic.DTO
{
    public class BL_TaskUpdateRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
