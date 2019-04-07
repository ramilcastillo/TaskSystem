namespace TaskSystem.DTO.Task
{
    public class UpdateTaskDetailRequest
    {
        public string Id { get; set; }
        public string Pocsusername { get; set; }
        public string PocdateDue { get; set; }
        public string PocdateAssigned { get; set; }
        public string PocdateClosed { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Requestor { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string PocpersonalDate { get; set; }
        public string PocpersonalNote { get; set; }
    }
}
