using System.Collections.Generic;
using System.Threading.Tasks;
using TaskSystem.BusinessLogic.DTO;
using TaskSystem.DTO.Admin;

namespace TaskSystem.BusinessLogic.Interface
{
    public interface IUserBusinessLogic
    {
        Task SaveUserAdmin(BlAddUserAdminRequest request);
        Task RemoveUserAdmin(BlRemoveUserAdminRequest request);
        Task<IEnumerable<BlAdministratorListResponse>> GetAllAdministratorByUserName(string userName);
        Task<IEnumerable<BlUsersResponse>> GetAllUsers(string searchName);
    }
}
