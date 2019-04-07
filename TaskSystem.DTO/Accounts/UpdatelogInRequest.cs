namespace TaskSystem.DTO.Accounts
{
    public class UpdateLoginRequest
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
