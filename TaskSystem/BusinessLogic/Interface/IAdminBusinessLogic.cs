using System.Collections.Generic;
using System.Threading.Tasks;
using TaskSystem.BusinessLogic.DTO;
using TaskSystem.DTO.Admin;

namespace TaskSystem.BusinessLogic.Interface
{
    public interface IAdminBusinessLogic
    {
        Task<IEnumerable<BlAdminTaskOwnerResponse>> GetTaskOwnerListByUsername(string userName);
        Task AddTaskOwner(BlAddUserAdminRequest request);
        Task<bool> CheckTaskOwnerExists(string actualUserName, string delegateUserName);
    }
}
