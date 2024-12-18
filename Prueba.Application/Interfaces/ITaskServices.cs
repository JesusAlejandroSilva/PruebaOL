using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Domain.Common.Dto;

namespace Prueba.Application.Interfaces
{
    public interface ITaskServices
    {
        Task<IEnumerable<TaskDto>> GetTasksAsync();
        Task<TaskDto> AddTaskAsync(TaskDto task);
        Task<TaskDto> UpdateTaskAsync(int id , TaskDto task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
