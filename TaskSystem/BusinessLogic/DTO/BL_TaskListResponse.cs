using System.Collections;
using System.Collections.Generic;

namespace TaskSystem.BusinessLogic.DTO
{
    public class BL_TaskListResponse
    {
        public IEnumerable<BL_TaskListResponseDetail> TasksList { get; set; }
    }
}
