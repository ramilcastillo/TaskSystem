using AutoMapper;
using TaskSystem.BusinessLogic.DTO;
using TaskSystem.DAL.Entities;
using TaskSystem.DTO.Admin;
using TaskSystem.DTO.Task;
using TaskSystem.DTO.User;

namespace TaskSystem.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BL_TaskCreateRequest, Tasks>();
            CreateMap<BlCreateTaskPocs, TaskPocs>();
            CreateMap<BlTaskUpdates, TaskUpdates>();
            CreateMap<BL_TaskListResponseDetail, TaskListResponseDetail>();
            CreateMap<Tasks, BlTaskResponse>();
            CreateMap<BlTaskDetailResponse, TaskResponseDetail>();
            CreateMap<AddUserAdminRequest, BlAddUserAdminRequest>();
            CreateMap<BlAddUserAdminRequest, TaskDelegates>();
            CreateMap<BlRemoveUserAdminRequest, TaskDelegates>();
            CreateMap<AddUserAdminRequest, BlRemoveUserAdminRequest>();
            CreateMap<TaskDelegates, BlAdministratorListResponse>();
            CreateMap<BlAdministratorListResponse, AdministratorListResponse>();
            CreateMap<UserNames, BlUsersResponse>();
            CreateMap<BlUsersResponse, UsersResponse>();
            CreateMap<TaskPocs, BlAdminTaskOwnerResponse>();
            CreateMap<BlAdminTaskOwnerResponse, TaskPOCsResponse>();
            CreateMap<UpdateTaskDetailRequest, BlUpdateTaskDetail>();
            CreateMap<BlUpdateTaskDetail, TaskPocs>();
            CreateMap<FileDocumentRequest, BlFileDocumentRequest>();
            CreateMap<BlFileDocumentRequest, TaskFiles>();
            CreateMap<TaskCommentDetailRequest, BlTaskCommentDetailRequest>();
            CreateMap<BlTaskCommentDetailRequest, TaskUpdates>();
            CreateMap<TaskUpdates, TaskCommentDetailResponse>();
            CreateMap<BlTaskCommentDetailRequest, TaskCommentDetailResponse>();
            CreateMap<UploadRequest, BlUploadFileRequest>();
            CreateMap<BlUploadFileRequest, TaskFiles>();
            CreateMap<TaskPOCDetailRequest, BlTaskPOCDetailRequest>();
            CreateMap<BlTaskPOCDetailRequest, TaskPocs>();
            CreateMap<TaskPocs, TaskPOCDetailRequest>();
            CreateMap<TaskFiles, TaskFileResponse>();
        }
    }    
}
