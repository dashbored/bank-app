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
        
        public async Task<IActionResult> Image(int id)
        {
            var query = new GetCustomerQuery
            {
                Id = id
            };

            var model = await _mediator.Send(query);
            return View("Index", model);
        }

        public async Task<IActionResult> List()
        {
            var model = await _mediator.Send(new GetCustomersListQuery());
            return View(model);
        }

        public async Task<IActionResult> CustomerList(int pageNumber = 1, string query = null)
        {
            var model = await _mediator.Send(new GetCustomersListQuery(pageNumber, query));
            return PartialView("_CustomerListPartial", model);
        }

        public async Task<IActionResult> NextPage(int pageNumber = 1)
        {
            var model = await _mediator.Send(new GetCustomersListQuery(pageNumber));
            return PartialView("_CustomerListPartial", model);
        }
    }
}