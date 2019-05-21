using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBank.Application.Customers.Queries.GetCustomer;
using DBank.Application.Customers.Queries.GetCustomersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DBank.WebUI.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> CustomerImage(GetCustomerQuery query)
        {
            var model = await _mediator.Send(query);
            return PartialView("_CustomerImageDetail", model);
        }

        public async Task<IActionResult> List()
        {
            var model = await _mediator.Send(new GetCustomersListQuery());
            return View(model);
        }
    }
}