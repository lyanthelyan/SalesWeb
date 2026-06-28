using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SalesWeb.Application.UseCases.Department.GetAll;
using SalesWeb.Application.UseCases.Seller.Delete;
using SalesWeb.Application.UseCases.Seller.GetAll;
using SalesWeb.Application.UseCases.Seller.GetById;
using SalesWeb.Application.UseCases.Seller.Register;
using SalesWeb.Communication.Requests;
using SalesWeb.Exceptions.ExceptionBase;
using SalesWeb.Web.Models;

namespace SalesWeb.Web.Controllers;


public class SellersController : Controller
{
    private readonly IRegisterSellerUseCase _registerUseCase;
    private readonly IDeleteSellerUseCase _deleteUseCase;
    private readonly IGetAllSellerUseCase _getAllUseCase;
    private readonly IGetAllDepartmentUseCase _getAllDepartmentsUseCase;
    private readonly IGetSellerByIdUseCase _getSellerByIdUseCase;

    public SellersController(
        IRegisterSellerUseCase registerSellerUseCase,
        IGetAllSellerUseCase getAllSellerUseCase,
        IGetAllDepartmentUseCase getAllDepartmentsUseCase,
        IDeleteSellerUseCase deleteUseCase,
        IGetSellerByIdUseCase getSellerByIdUseCase)
    {
        _registerUseCase = registerSellerUseCase;
        _getAllUseCase = getAllSellerUseCase;
        _getAllDepartmentsUseCase = getAllDepartmentsUseCase;
        _deleteUseCase = deleteUseCase;
        _getSellerByIdUseCase = getSellerByIdUseCase;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var sellers = await _getAllUseCase.Execute();

        return View(sellers);
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var departments = await _getAllDepartmentsUseCase.Execute();

        var viewModel = new SellerFormViewModel
        {
            Departments = departments
        };

        return View(viewModel);
    }
    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var seller = await _getSellerByIdUseCase.Execute(id);
        return View(seller);
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
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _deleteUseCase.Execute(id);
        return RedirectToAction(nameof(Index));
    }

    
}
