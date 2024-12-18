using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Prueba.Application.Interfaces;
using Prueba.Domain.Common.Dto;
using Prueba.Domain.Entities;
using Prueba.Domain.Ports;

namespace Prueba.Application.Services
{
    public class TaskServices : ITaskServices
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskServices(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<TaskDto> AddTaskAsync(TaskDto task)
        {
           if (task == null) 
                throw new ArgumentNullException(nameof(task));

           var taskEntity = _mapper.Map<TaskEntity>(task);

           var createTask = await _taskRepository.AddAsync(taskEntity);

            return _mapper.Map<TaskDto>(createTask);

        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            // Obtener la entidad
            var taskEntity = await _taskRepository.GetByIdAsync(id);

            if (taskEntity == null)
                throw new KeyNotFoundException($"No se encontró el Task con el Id {id}");

            // Eliminar la entidad
            await _taskRepository.DeleteAsync(taskEntity);

            // Retornar si la eliminación fue exitosa (puedes usar un valor booleano basado en el repositorio)
            return true;
        }

        public async Task<IEnumerable<TaskDto>> GetTasksAsync()
        {
           var datotask = await _taskRepository.GetAllAsync();
            return _mapper.Map<List<TaskDto>>(datotask);
        }

        public async Task<TaskDto> UpdateTaskAsync(int id, TaskDto task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            var existingEntity = await _taskRepository.GetByIdAsync(id);

            if (existingEntity == null)
                throw new KeyNotFoundException($"No se encontró el Task con el Id {id}");

            _mapper.Map(task, existingEntity);

            await _taskRepository.UpdateAsync(existingEntity);   

            return _mapper.Map<TaskDto>(existingEntity);
        }
    }
}
