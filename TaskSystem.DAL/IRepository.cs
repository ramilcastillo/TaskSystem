using System.Collections.Generic;
using System.Threading.Tasks;
using TaskSystem.DAL.Entities;
//using TaskSystem.DAL.SP_DTO;

namespace TaskSystem.DAL
{
    public interface IRepository
    {
        Task<IEnumerable<Tasks>> GetAllTasks();
        //Task<IEnumerable<Tasks>> GetAllTasks(List<int> allTaskPocsPerCurrentUserInt);
        IEnumerable<Tasks> GetAllTasks(List<int> allTaskPocsPerCurrentUserInt);
        Task<IEnumerable<TaskPocs>> GetAllTasksPocs();
        Task<IEnumerable<TaskPocs>> GetAllTasksPocs(string userName,string taskSatus);
        Task<IEnumerable<V_Tasks>> GetTopTasks();
        Task<IEnumerable<V_TaskPocs>> GetTopTasksPocs();
        Task InsertTask(Tasks task);
        Task InsertTaskPocs(TaskPocs taskPocs);
        Task InsertTaskUpdates(TaskUpdates task);
        Task<Tasks> GetTaskById(int id);
        //Task<TaskPocs> GetTaskPocByTaskId(int id);

        Task<IEnumerable<TaskPocs>> GetTaskPocByTaskIdUserName(int id, string userName);
        Task<IEnumerable<TaskPocs>> GetTaskPocsByTaskId(int id);
        Task<IEnumerable<TaskPocs>> GetTaskPocByTaskId(int id);

        Task InsertAdministrator(TaskDelegates administrator);
        Task DeleteAdministratorByUserName(TaskDelegates administrator);
        Task<IEnumerable<TaskDelegates>> GetAdministratorByActualUser(string userName);
        Task<IEnumerable<UserNames>> GetUsers(string searchName);
        Task<IEnumerable<TaskPocs>> GetTaskOwnerByUserName(string userName);
        //Task<IEnumerable<Tasks>> GetTasksById(int id);
        Task<TaskDelegates> CheckAdminRecordExists(string actualUserName, string delegateUserName);
        Task UpdateTaskPocAsync(TaskPocs taskPocs);
        Task UpdateTask(Tasks tasks);
        Task UploadFile(TaskFiles taskFiles);
        Task InsertCommentAsync(TaskUpdates taskUpdates);
        Task InsertPocAsync(TaskPocs taskUpdates);
        Task<IEnumerable<TaskUpdates>> GetTaskUpdatesById(int id);
        Task DeleteExistingCommentUpdate(int id);
        Task<TaskFiles> GetUploadFileById(int id);
        Task DeleteUploadedById(int id);
        Task DeletePocByTaskId(int id);
        Task DeletePocByTaskId(int id, string userName);
        Task<IEnumerable<TaskFiles>> GetUploadedFilesById(string id);
    }
}
