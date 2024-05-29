using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Web.Models;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.Services;

namespace UnikProjekt.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingService _bookingService;
        private readonly BookingItemService _bookingItemService;
        private readonly ILogger<BookingController> _logger;

        public BookingController(BookingService bookingService, BookingItemService bookingItemService, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _bookingItemService = bookingItemService;
            _logger = logger;
        }

        // GET: BookingController
        public async Task<IActionResult> Index()
        {
            var booking = await _bookingService.GetAllBookingsAsync();
            return View(booking);
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateBookingViewModel();
            viewModel.BookingItems = await _bookingItemService.GetAllBookingItemsAsync();
            return View(viewModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookingViewModel createBookingViewModel)
        {

            try
            {

                var createBookingDto = new CreateBookingDto
                {
                    UserId = createBookingViewModel.UserId,
                    DateBooked = DateTime.Now,
                    Items = new List<CreateBookingLineDto>
            {
                new CreateBookingLineDto
                {
                    BookingItemId = createBookingViewModel.SelectedBookingItemId,
                    BookingStart = createBookingViewModel.BookingStart,
                    BookingEnd = createBookingViewModel.BookingEnd,
                }
            }
                };

                var bookingId = await _bookingService.CreateBookingAsync(createBookingDto);

                if (bookingId != Guid.Empty)
                {

                    _logger.LogInformation("Booking created successfully with ID: {BookingId} in {ActionName}", bookingId, nameof(Create));
                    return View(createBookingViewModel);
                }
                else
                {
                    _logger.LogWarning("Booking item couldn't be created in {ActionName}", nameof(Create));
                    ModelState.AddModelError("", "Fejl opstod under oprettelse af bookingen.");
                    return View(createBookingViewModel);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred in {ActionName}: {ErrorMessage}", nameof(Create), ex.Message);
                ModelState.AddModelError("", "Der opstod en uventet fejl: " + ex.Message);
                return View(createBookingViewModel);
            }
        }
    }
}


