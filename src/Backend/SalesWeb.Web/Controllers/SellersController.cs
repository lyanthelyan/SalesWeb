using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SalesWeb.Application.UseCases.Department.GetAll;
using SalesWeb.Application.UseCases.Seller.GetAll;
using SalesWeb.Application.UseCases.Seller.Register;
using SalesWeb.Communication.Requests;
using SalesWeb.Exceptions.ExceptionBase;
using SalesWeb.Web.Models;

namespace SalesWeb.Web.Controllers;


public class SellersController : Controller
{
    private readonly IRegisterSellerUseCase _registerUseCase;
    private readonly IGetAllSellerUseCase _getAllUseCase;
    private readonly IGetAllDepartmentUseCase _getAllDepartmentsUseCase;

    public SellersController(
        IRegisterSellerUseCase registerSellerUseCase,
        IGetAllSellerUseCase getAllSellerUseCase,
        IGetAllDepartmentUseCase getAllDepartmentsUseCase)
    {
        _registerUseCase = registerSellerUseCase;
        _getAllUseCase = getAllSellerUseCase;
        _getAllDepartmentsUseCase = getAllDepartmentsUseCase;
    }

    public async Task<IActionResult> Create()
    {
        var departments = await _getAllDepartmentsUseCase.Execute();

        var viewModel = new SellerFormViewModel
        {
            Departments = departments
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SellerFormViewModel viewModel)
    {
        try
        {
            await _registerUseCase.Execute(viewModel.Seller);
            return RedirectToAction(nameof(Index));
        }
        catch (ErrorOnValidationException ex)
        {
            viewModel.Departments = await _getAllDepartmentsUseCase.Execute();
            ModelState.Clear();
            foreach (var error in ex.GetErrorMessages())
                ModelState.AddModelError(string.Empty, error);

            return View(viewModel);
        }

        
    }

    public async Task<IActionResult> Index()
    {
        var sellers = await _getAllUseCase.Execute();

        return View(sellers);
    }
}
