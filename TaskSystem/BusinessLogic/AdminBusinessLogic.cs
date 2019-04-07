using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using AutoMapper;
using TaskSystem.BusinessLogic.DTO;
using TaskSystem.BusinessLogic.Interface;
using TaskSystem.DAL;
using TaskSystem.DAL.Entities;
using TaskSystem.DTO.Admin;

namespace TaskSystem.BusinessLogic
{
    public class AdminBusinessLogic: IAdminBusinessLogic
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public AdminBusinessLogic(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BlAdminTaskOwnerResponse>> GetTaskOwnerListByUsername(string userName)
        {
            //var result = await _repository.GetTaskOwnerByUserName(userName);
            var result = await _repository.GetAdministratorByActualUser(userName);

            //var resultMapped = _mapper.Map<IEnumerable<TaskPocs>, IEnumerable<BlAdminTaskOwnerResponse>>(result);
            var resultMapped = _mapper.Map<IEnumerable<TaskDelegates>, IEnumerable<BlAdminTaskOwnerResponse>>(result);

            return resultMapped;
        }

        public static List<PointF> RemoveDuplicates(List<PointF> listPoints)
        {
            List<PointF> result = new List<PointF>();

            for (int i = 0; i < listPoints.Count; i++)
            {
                if (!result.Contains(listPoints[i]))
                    result.Add(listPoints[i]);
            }

            return result;
        }

        public async Task AddTaskOwner(BlAddUserAdminRequest request)
        {
            var requestMapped = _mapper.Map<BlAddUserAdminRequest, TaskDelegates>(request);
            if (await CheckTaskOwnerExists(request.ActualUser, request.DelegateUser))
            {}
            else
            {
                await _repository.InsertAdministrator(requestMapped);
            }

        }

        public async Task<bool> CheckTaskOwnerExists(string actualUserName, string delegateUserName)
        {
            var result = await _repository.CheckAdminRecordExists(actualUserName, delegateUserName);

            if (result == null)
                return false;
            else
                return true;
        }
    }
}
