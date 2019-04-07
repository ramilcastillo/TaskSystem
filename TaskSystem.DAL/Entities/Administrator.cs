namespace TaskSystem.DAL.Entities
{
    public class Administrator
    {
        public int Id { get; set; }
        public string ActualUser { get; set; }
        public string DelegateUser { get; set; }
    }
}
