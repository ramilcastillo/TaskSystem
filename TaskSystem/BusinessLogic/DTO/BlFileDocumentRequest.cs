namespace TaskSystem.BusinessLogic.DTO
{
    public class BlFileDocumentRequest
    {
        public int? FileTaskId { get; set; }
        public byte[] FileData { get; set; }
        public string FileName { get; set; }
        public string FileAddedBy { get; set; }
    }
}
