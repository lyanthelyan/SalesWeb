using Microsoft.AspNetCore.Mvc;
using SalesWeb.Application.UseCases.Department.Delete;
using SalesWeb.Application.UseCases.Department.Details;
using SalesWeb.Application.UseCases.Department.GetAll;
using SalesWeb.Application.UseCases.Department.GetById;
using SalesWeb.Application.UseCases.Department.Register;
using SalesWeb.Application.UseCases.Department.Update;
using SalesWeb.Communication.Requests.DepartmentRequests.Register;
using SalesWeb.Communication.Requests.DepartmentRequests.Update;
using SalesWeb.Exceptions.ExceptionBase;

public class DepartmentsController : Controller
{
    private readonly IRegisterDepartmentUseCase _registerUseCase;
    private readonly IGetAllDepartmentUseCase _getAllUseCase;
    private readonly IGetDepartmentByIdUseCase _getDepartmentByIdUseCase;
    private readonly IDeleteDepartmentUseCase _deleteDepartmentUseCase;
    private readonly IUpdateDepartmentUseCase _updateDepartmentUseCase;
    private readonly IGetDepartmentDetailsUseCase _getDepartmentDetailsUseCase;

    public DepartmentsController(
        IRegisterDepartmentUseCase registerUseCase,
        IGetAllDepartmentUseCase getAllUseCase,
        IGetDepartmentByIdUseCase getDepartmentByIdUseCase,
        IDeleteDepartmentUseCase deleteDepartmentUseCase,
        IUpdateDepartmentUseCase updateDepartmentUseCase,
        IGetDepartmentDetailsUseCase getDepartmentDetailsUseCase)
    {
        _registerUseCase = registerUseCase;
        _getAllUseCase = getAllUseCase;
        _getDepartmentByIdUseCase = getDepartmentByIdUseCase;
        _deleteDepartmentUseCase = deleteDepartmentUseCase;
        _updateDepartmentUseCase = updateDepartmentUseCase;
        _getDepartmentDetailsUseCase = getDepartmentDetailsUseCase;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var departments = await _getAllUseCase.Execute();

        return View(departments);
    }
    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var department = await _getDepartmentByIdUseCase.Execute(id);
        return View(department);
    }
    [HttpGet]
    public async Task<IActionResult> Details(Guid id)
    {
        var department = await _getDepartmentDetailsUseCase.Execute(id);

        return View(department);
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var department = await _getDepartmentByIdUseCase.Execute(id);

        var request = new RequestUpdateDepartmentJson
        {
            Id = department.Id,
            Name = department.Name
        };

        return View(request);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RequestRegisterDepartmentJson request)
    {
        try
        {
            await _registerUseCase.Execute(request);

            return RedirectToAction(nameof(Index));
        }
        catch (ErrorOnValidationException ex)
        {
            ModelState.Clear();

            foreach (var error in ex.GetErrorMessages())
            {
                ModelState.AddModelError(string.Empty, error);
            }

            return View(request);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _deleteDepartmentUseCase.Execute(id);
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, RequestUpdateDepartmentJson request)
    {
        try
        {
            await _updateDepartmentUseCase.Execute(id, request);

            return RedirectToAction(nameof(Index));
        }
        catch (ErrorOnValidationException ex)
        {
            ModelState.Clear();

            foreach (var error in ex.GetErrorMessages())
            {
                ModelState.AddModelError(string.Empty, error);
            }

            return View(request);
        }


    }


}