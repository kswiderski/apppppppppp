using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Customers;
namespace WebApplication1.Controllers;

public class CustomerController : Controller
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerService _customerService;

    public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Customers()
    {
        var customers = await _customerService.GetAsync();
        ViewData["Customers"] = customers;
        
        return View();
    }
    
    [HttpGet]
    public IActionResult CreateCustomer()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Customer customer)
    {
        await _customerService.AddAsync(customer);
        return RedirectToAction("Customers", "Customer");
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        if (customer == null)
        {
            return RedirectToAction("Customers");
        }

        return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _customerService.DeleteAsync(id);
        return RedirectToAction("Customers", "Customer");
    }
}