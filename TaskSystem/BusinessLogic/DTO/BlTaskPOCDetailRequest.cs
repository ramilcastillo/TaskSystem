namespace TaskSystem.BusinessLogic.DTO
{
    public class BlTaskPOCDetailRequest
    {
        public int Id { get; set; }
        public int PoctaskId { get; set; }
        public string ParentUsername { get; set; }
        public string PocdateAssigned { get; set; }
        public string PocdateClosed { get; set; }
        public string PocdateDue { get; set; }
        public string Pocusername { get; set; }
    }
}
