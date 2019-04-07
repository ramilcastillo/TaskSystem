using System.Collections.Generic;

namespace TaskSystem.DTO.Accounts
{
    public class RegisterLoginResponse
    {
        //public ApplicationUser User { get; set; }
        public IList<string> Roles { get; set; }
        public string Token { get; set; }
    }
}
