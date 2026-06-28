using System;
using System.Threading.Tasks;
using SalesWeb.Domain.Repositories;
using SalesWeb.Exceptions;

namespace SalesWeb.Application.UseCases.Department.Delete
{
    public class DeleteDepartmentUseCase : IDeleteDepartmentUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentRepository _repository;

        public DeleteDepartmentUseCase(IUnitOfWork unitOfWork, IDepartmentRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }


        public async Task Execute(Guid id)
        {
            await ValidateDepartmentExists(id);
            await _repository.Delete(id);
            await _unitOfWork.Commit();
        }
        private async Task ValidateDepartmentExists(Guid id)
        {
            var departmentId = await _repository.GetById(id);
        
            if (departmentId is null)
                throw new NotFoundException(ResourceMessagesExceptions.VALIDATION_DEPARTMENT_NOT_FOUND);
        }
    }
}