using System.Diagnostics;
using System.Threading.Tasks;
using DBank.Application.Bank.Queries.GetBankStatistics;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DBank.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _mediator.Send(new GetBankStatisticsQuery());
            return View(model);
        }

    }
}
