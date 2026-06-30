using Mapster;
using SalesWeb.Application.UseCases.Department.GetById;
using SalesWeb.Communication.Responses.DepartmentResponses;
using SalesWeb.Domain.Repositories;
using SalesWeb.Exceptions;

namespace SalesWeb.Application.UseCases.Department.GetById;

    public class GetDepartmentByIdUseCase : IGetDepartmentByIdUseCase
    {
        private readonly IDepartmentRepository _repository;

        public GetDepartmentByIdUseCase(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseDepartmentJson> Execute(Guid id)
        {
            var department = await _repository.GetById(id);
            if (department is null)
            {
                throw new NotFoundException(
                ResourceMessagesExceptions.VALIDATION_DEPARTMENT_NOT_FOUND);
            }
            return department.Adapt<ResponseDepartmentJson>();
        }
    }

