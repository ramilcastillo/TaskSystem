using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TaskSystem.BusinessLogic.DTO;
using TaskSystem.BusinessLogic.Interface;
using TaskSystem.DAL;
using TaskSystem.DAL.Entities;

namespace TaskSystem.BusinessLogic
{
    public class UserBusinessLogic:IUserBusinessLogic
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public UserBusinessLogic(IRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        public async Task SaveUserAdmin(BlAddUserAdminRequest request)
        {
            var admin = _mapper.Map<BlAddUserAdminRequest, TaskDelegates>(request);
            await _repo.InsertAdministrator(admin);
        }

        public async Task RemoveUserAdmin(BlRemoveUserAdminRequest request)
        {
            var record = _mapper.Map<BlRemoveUserAdminRequest, TaskDelegates>(request);
            await _repo.DeleteAdministratorByUserName(record);
        }

        public async Task<IEnumerable<BlAdministratorListResponse>> GetAllAdministratorByUserName(string userName)
        {
            var records = await _repo.GetAdministratorByActualUser(userName);
            var recordsMapped = _mapper.Map<IEnumerable<TaskDelegates>, IEnumerable<BlAdministratorListResponse>>(records);

            return recordsMapped;
        }

        public async Task<IEnumerable<BlUsersResponse>> GetAllUsers(string searchName)
        {
            var records = await _repo.GetUsers(searchName);
            var recordsMapped = _mapper.Map<IEnumerable<UserNames>, IEnumerable<BlUsersResponse>>(records);
            return recordsMapped;
        }
    }
}
