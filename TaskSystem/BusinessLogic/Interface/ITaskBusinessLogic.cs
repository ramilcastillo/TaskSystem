using System.Collections.Generic;
using TaskSystem.BusinessLogic.DTO;

namespace TaskSystem.BusinessLogic.Interface
{
    public interface ITaskBusinessLogic
    {
        System.Threading.Tasks.Task CreateAsync(BL_TaskCreateRequest request);
        System.Threading.Tasks.Task<IEnumerable<BL_TaskListResponseDetail>> GetTasksForUser(string userName,string taskSatus);
        //System.Threading.Tasks.Task<BlTaskDetailResponse> GetTaskById(int id);
        System.Threading.Tasks.Task<BlTaskDetailResponse> GetTaskById(int id, string Pocusername);
        System.Threading.Tasks.Task UpdateAsync(BlUpdateTaskDetail request);
        //System.Threading.Tasks.Task UploadFile(BlFileDocumentRequest request);
        System.Threading.Tasks.Task CreateCommentAsync(BlTaskCommentDetailRequest request);
        System.Threading.Tasks.Task CreatePOCAsync(IEnumerable<BlTaskPOCDetailRequest> request);
        //System.Threading.Tasks.Task CreatePOCAsync(BlTaskPOCDetailRequest request);
        System.Threading.Tasks.Task UploadFile(BlUploadFileRequest request);
    }
}