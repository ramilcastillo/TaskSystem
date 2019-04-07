using System;

namespace TaskSystem.BusinessLogic.DTO
{
    public class BlUploadFileRequest
    {
        public int FileTaskId { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public byte[] FileData { get; set; }
        public string ContentType { get; set; }
        public string FileAddedBy { get; set; }
        public DateTime FileAddedDate { get; set; }
        public int FileUploadVersion { get; set; }
    }
}
