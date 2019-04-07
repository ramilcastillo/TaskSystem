using System.Collections.Generic;

namespace TaskSystem.BusinessLogic.DTO
{
    public class BL_UserListResponse
    {
        public IEnumerable<BL_UserListResponseDetail> UserList { get; set; }
    }
}
