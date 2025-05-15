using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Features.Events.Query.GetAll;
using SocialNetwork.Models;
using SocialNetwork.Models.Events;

namespace SocialNetwork.Controllers
{
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;
        private readonly IMediator _mediator;

        public EventController(ILogger<EventController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(string dateFilter)
        {
            DateOnly? calculatedStartDate = null;
            DateOnly? calculatedEndDate = null;

            var today = DateOnly.FromDateTime(DateTime.Today);

            switch (dateFilter)
            {
                case "today":
                    calculatedStartDate = today;
                    calculatedEndDate = today;
                    break;
                case "tomorrow":
                    calculatedStartDate = today.AddDays(1);
                    calculatedEndDate = today.AddDays(1);
                    break;
                case "thisWeek":
                    calculatedStartDate = today.AddDays(-(int)today.DayOfWeek);
                    calculatedEndDate = calculatedStartDate.Value.AddDays(6);
                    break;
                case "thisWeekend":
                    calculatedStartDate = today.AddDays(-(int)today.DayOfWeek + 5);
                    calculatedEndDate = calculatedStartDate.Value.AddDays(1);
                    break;
                case "nextWeek":
                    calculatedStartDate = today.AddDays(-(int)today.DayOfWeek + 7);
                    calculatedEndDate = calculatedStartDate.Value.AddDays(6);
                    break;
            }

            var query = new GetAllQuery(calculatedStartDate, calculatedEndDate);
            var viewModel = new EventVM
            {
                Events = await _mediator.Send(query)
            };

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
