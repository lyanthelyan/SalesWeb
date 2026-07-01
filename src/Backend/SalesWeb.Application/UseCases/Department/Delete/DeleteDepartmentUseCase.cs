using SalesWeb.Domain.Repositories;
using SalesWeb.Exceptions;
using SalesWeb.Exceptions.ExceptionBase;

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
            await ValidateDepartmentCanBeDeleted(id);         
            await _repository.Delete(id);
            await _unitOfWork.Commit();
        }
        private async Task ValidateDepartmentCanBeDeleted(Guid id)
        {
            var department = await _repository.GetById(id);
            var departmentHasSellers = await _repository.ExistSellerWithDepartmentId(id);
            if (department is null)
                throw new NotFoundException(ResourceMessagesExceptions.VALIDATION_DEPARTMENT_NOT_FOUND);
            if (departmentHasSellers) 
            {
                throw new ErrorOnValidationException([ResourceMessagesExceptions.VALIDATION_DETELE_DEPARTMENT]);
            }
                
        }
    }
}