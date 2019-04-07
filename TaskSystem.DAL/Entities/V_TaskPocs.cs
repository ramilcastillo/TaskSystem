using System;
using System.ComponentModel.DataAnnotations;
namespace TaskSystem.DAL
{
    public class V_TaskPocs
    {

        [Key]
        public int Id { get; set; }
        public int PoctaskId { get; set; }
        public string Pocusername { get; set; }
        public DateTime? PocdateClosed { get; set; }
        public DateTime PocdateAssigned { get; set; }
        public string ParentUsername { get; set; }
        public DateTime? PocdateDue { get; set; }
        public string Pocsort { get; set; }
        public int? Poclevel { get; set; }
        public bool? PocisFlagged { get; set; }
        public string PocpersonalNote { get; set; }
        public DateTime? PocpersonalDate { get; set; }
    }
}