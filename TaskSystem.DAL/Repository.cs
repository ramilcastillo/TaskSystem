using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskSystem.DAL.Entities;

namespace TaskSystem.DAL
{
    public class Repository: IRepository
    {
        private readonly TaskSystemContext _context;
        public Repository(TaskSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tasks>> GetAllTasks()
        {
            try
            {
                var result = await _context.Tasks.ToListAsync();
                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Tasks> GetAllTasks(List<int> allTaskPocsPerCurrentUserInt)

        {
            try
            {
                //var result = await _context.Tasks.ToListAsync();
                //return result;
                //return await _context.Tasks.Where(s => s.Id == Id).ToListAsync();
                return _context.Tasks.Where(s => allTaskPocsPerCurrentUserInt.Contains(s.Id)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<TaskPocs>> GetAllTasksPocs()
        {
            try
            {
                var result = await _context.TaskPocs.ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<TaskPocs>> GetAllTasksPocs(string userName,string taskSatus)
        {
            try
            {
                //var result = await _context.TaskPocs.ToListAsync();
                //return result;
                if (taskSatus == "ClosedTasks")
                    return await _context.TaskPocs.Where(s => s.PocdateClosed != null && s.Pocusername == userName && s.ParentUsername == "*").ToListAsync();
                else
                    return await _context.TaskPocs.Where(s => s.Pocusername == userName).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task InsertTask(Tasks task)
        {
            try
            {
                await _context.Tasks.AddAsync(task);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task InsertTaskPocs(TaskPocs taskPocs)
        {
            try
            {
                await _context.TaskPocs.AddAsync(taskPocs);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task InsertTaskUpdates(TaskUpdates taskUpdates)
        {
            try
            {
                await _context.TaskUpdates.AddAsync(taskUpdates);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Tasks> GetTaskById(int id)
        {
            try
            {
                return await _context.Tasks.SingleOrDefaultAsync(s => s.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<TaskPocs>> GetTaskPocsByTaskId(int id)
        {
            try
            {
                //return await _context.TaskPocs.Where(s => s.PoctaskId == id).ToListAsync();
                return await _context.TaskPocs.Where(s => s.Id == id).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<TaskPocs>> GetTaskPocByTaskId(int id)
        {
            try
            {
                return await _context.TaskPocs.Where(s => s.PoctaskId == id).ToListAsync();
                //return await _context.TaskPocs.Where(s => s.Id == id).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<TaskPocs>> GetTaskPocByTaskIdUserName(int id, string UserName)
        {
            try
            {
                //return await _context.TaskPocs.SingleOrDefaultAsync(s => s.PoctaskId == id && s.Pocusername == UserName);
                return await _context.TaskPocs.Where(s => s.PoctaskId == id && s.Pocusername == UserName).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //public async Task<TaskPocs> GetTaskPocByTaskId(int id)
        //{
        //    try
        //    {
        //        return await _context.TaskPocs.SingleOrDefaultAsync(s => s.Id == id);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        public async Task InsertAdministrator(TaskDelegates administrator)
        {
            try
            {
                await _context.TaskDelegates.AddAsync(administrator);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteAdministratorByUserName(TaskDelegates administrator)
        {
            var record = await _context.TaskDelegates.FirstOrDefaultAsync(s => s.ActualUser == administrator.ActualUser && s.DelegateUser ==administrator.DelegateUser);
            _context.TaskDelegates.Remove(record);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskDelegates>> GetAdministratorByActualUser(string userName)
        {
            //var result = await _context.TaskDelegates.Where(s => s.ActualUser == userName).ToListAsync();
            var result = await _context.TaskDelegates.Where(s => s.DelegateUser == userName).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<UserNames>> GetUsers(string searchName)
        {
            var result = await _context.Users.Where(s=>s.LastName.ToUpper().Contains(searchName.ToUpper())).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<TaskPocs>> GetTaskOwnerByUserName(string userName)
        {
            //var result = await _context.TaskPocs.Where(s => s.Pocusername == userName).ToListAsync();
            var result = await _context.TaskPocs.Where(s => s.ParentUsername == userName || s.Pocusername == userName).ToListAsync();
            return result;
        }

        public async Task<TaskDelegates> CheckAdminRecordExists(string actualUserName, string delegateUserName)
        {
            try
            {
                //var result = await _context.Administrator.FirstOrDefaultAsync(s => s.ActualUser == actualUserName && s.DelegateUser == delegateUserName);
                var result = await _context.TaskDelegates.FirstOrDefaultAsync(s => s.ActualUser == actualUserName && s.DelegateUser == delegateUserName);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateTaskPocAsync(TaskPocs taskPocs)
        {
            try
            {
                _context.TaskPocs.Update(taskPocs);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateTask(Tasks tasks)
        {
            try
            {
                _context.Tasks.Update(tasks);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UploadFile(TaskFiles taskFiles)
        {
            try
            {
                await _context.TaskFiles.AddAsync(taskFiles);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task InsertCommentAsync(TaskUpdates taskUpdates)
        {
            try
            {
                await _context.TaskUpdates.AddAsync(taskUpdates);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task InsertPocAsync(TaskPocs taskPocs)
        {
            try
            {
                await _context.TaskPocs.AddAsync(taskPocs);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<TaskUpdates>> GetTaskUpdatesById(int id)
        {
            try
            {
                var result = await _context.TaskUpdates.Where(s=>s.TaskId == id).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteExistingCommentUpdate(int id)
        {
            try
            {
                await _context.TaskUpdates.Where(s => s.TaskId == id).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<V_Tasks>> GetTopTasks()
        {
            try
            {
                var result = await _context.V_Tasks.ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<V_TaskPocs>> GetTopTasksPocs()
        {
            try
            {
                var result = await _context.V_TaskPocs.ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TaskFiles> GetUploadFileById(int id)
        {
            try
            {
                var result = await _context.TaskFiles.SingleOrDefaultAsync(s => s.FileTaskId == id);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteUploadedById(int id)
        {
            try
            {
                var record = await _context.TaskFiles.FirstAsync(s => s.FileTaskId == id);
                _context.TaskFiles.Remove(record);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeletePocByTaskId(int id)
        {
            try
            {
                var records = await _context.TaskPocs.Where(s => s.PoctaskId == id).ToListAsync();
                //var records = await _context.TaskPocs.Where(s => s.PoctaskId == id && s.Pocusername == "*").ToListAsync();
                foreach (var record in records)
                {
                    _context.TaskPocs.Remove(record);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeletePocByTaskId(int id,string userName)
        {
            try
            {
                var records = await _context.TaskPocs.Where(s => s.PoctaskId == id && s.Pocusername == userName).ToListAsync();
                foreach (var record in records)
                {
                    _context.TaskPocs.Remove(record);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<TaskFiles>> GetUploadedFilesById(string id)
        {
            try
            {
                var result = await _context.TaskFiles.Where(s => s.FileTaskId == int.Parse(id)).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
