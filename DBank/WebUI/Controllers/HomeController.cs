﻿using System.Diagnostics;
using System.Threading.Tasks;
using DBank.Application.Bank.Queries.GetBankStatistics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
