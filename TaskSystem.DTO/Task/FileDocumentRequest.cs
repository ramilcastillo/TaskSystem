namespace TaskSystem.DTO.Task
{
    public class FileDocumentRequest
    {
        public int? FileTaskId { get; set; }
        public byte[] FileData { get; set; }
        public string FileName { get; set; }
        public string FileAddedBy { get; set; }
    }
}
