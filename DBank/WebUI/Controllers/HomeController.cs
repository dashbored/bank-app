using System;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stopwatch = Stopwatch.StartNew();
            var model = await _mediator.Send(new GetBankStatisticsQuery());
            stopwatch.Stop();
            Console.WriteLine($"\n\n ELAPSED TIME TO GET BANK STATISTICS: {stopwatch.ElapsedMilliseconds}\n\n");
            return View(model);
        }

    }
}
