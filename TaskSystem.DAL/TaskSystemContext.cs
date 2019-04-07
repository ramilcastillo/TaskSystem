using Microsoft.EntityFrameworkCore;
using TaskSystem.DAL.Entities;
using TaskSystem.DAL.SP_DTO;

//using TaskSystem.DAL.Entities;

namespace TaskSystem.DAL
{
    public class TaskSystemContext : DbContext
    {
        public TaskSystemContext()
        {
        }

        public TaskSystemContext(DbContextOptions<TaskSystemContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TaskDelegates> TaskDelegates { get; set; }
        //public virtual DbSet<TaskOwners> TaskOwners { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<V_Tasks> V_Tasks { get; set; }
        public virtual DbSet<TaskUpdates> TaskUpdates { get; set; }
        public virtual DbSet<TaskFiles> TaskFiles { get; set; }
        public virtual DbSet<TaskDefaultPocs> TaskDefaultPocs { get; set; }
        public virtual DbSet<UserNames> Users { get; set; }
        public virtual DbSet<SP_GetTasksResponse> TasksHome { get; set; }
        public virtual DbSet<TaskPocs> TaskPocs { get; set; }
        public virtual DbSet<V_TaskPocs> V_TaskPocs { get; set; }
        public virtual DbSet<UserNames> UserNames { get;set; }
    }

}
