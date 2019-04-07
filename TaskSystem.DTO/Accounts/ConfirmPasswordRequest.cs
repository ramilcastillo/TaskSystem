namespace TaskSystem.DTO.Accounts
{
    public class ConfirmPasswordRequest
    {
        public string PasswordResetToken { get; set; }
        public string NewPassword { get; set; }
    }
}
