using Microsoft.AspNetCore.Mvc;
using SalesWeb.Application.UseCases.Department.Register;
using SalesWeb.Communication.Requests;
using SalesWeb.Domain.Repositories;

public class DepartmentsController : Controller
{
    private readonly RegisterDepartmentUseCase _useCase;
    private readonly IDepartmentRepository _repository;

    public DepartmentsController(RegisterDepartmentUseCase useCase, IDepartmentRepository repository)
    {
        _useCase = useCase;
        _repository = repository;
    }

    // GET: /Departments/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Departments/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(RequestRegisterDepartmentJson request)
    {
        _useCase.Execute(request);

        return RedirectToAction(nameof(Index));
    }

    // GET: /Departments
    public IActionResult Index()
    {
        var departments = _repository.GetAll();
        return View();
    }
}