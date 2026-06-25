using Microsoft.AspNetCore.Mvc;
using SalesWeb.Application.UseCases.Department.GetAll;
using SalesWeb.Application.UseCases.Department.Register;
using SalesWeb.Communication.Requests;

public class DepartmentsController : Controller
{
    private readonly IRegisterDepartmentUseCase _registerUseCase;
    private readonly IGetAllDepartmentUseCase _getAllUseCase;

    public DepartmentsController(
        IRegisterDepartmentUseCase registerUseCase,
        IGetAllDepartmentUseCase getAllUseCase)
    {
        _registerUseCase = registerUseCase;
        _getAllUseCase = getAllUseCase;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RequestRegisterDepartmentJson request)
    {
        await _registerUseCase.Execute(request);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Index()
    {
        var departments = await _getAllUseCase.Execute();

        return View(departments);
    }
}