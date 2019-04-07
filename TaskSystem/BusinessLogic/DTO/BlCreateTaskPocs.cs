using System;

namespace TaskSystem.BusinessLogic.DTO
{
    public class BlCreateTaskPocs
    {
        public int PoctaskId { get; set; }
        public string Pocusername { get; set; }
        public DateTime PocdateAssigned { get; set; }
        public string ParentUsername { get; set; }
        public DateTime PocpersonalDate { get; set; }
        public int POClevel { get; set; }
        public string POCsort { get; set; }
    }
}
