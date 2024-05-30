using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Web.Models;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.Services;

namespace UnikProjekt.Web.Controllers
{
    public class BookingItemsController : Controller
    {
        private readonly BookingItemService _bookingItemService;
        private readonly ILogger<BookingItemsController> _logger;

        public BookingItemsController(BookingItemService bookingItemService, ILogger<BookingItemsController> logger)
        {
            _bookingItemService = bookingItemService;
            _logger = logger;
        }

        // GET: BookingsController
        public async Task<IActionResult> Index()
        {
            var bookingItems = await _bookingItemService.GetAllBookingItemsAsync();
            _logger.LogInformation("All booking items retrieved in {ActionName}", nameof(Index));
            return View(bookingItems);
        }

        //GET: BookingsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var bookingItems = await _bookingItemService.GetBookingItemByIdAsync(id);
            if (bookingItems == null)
            {
                return NotFound();
            }
            return View(bookingItems);
        }

        public async Task<IActionResult> Name(string name)
        {
            var bookingItem = await _bookingItemService.GetBookingItemByNameAsync(name);
            if (bookingItem == null)
            {
                return NotFound();
            }
            return View(bookingItem);
        }


        // GET: BookingsController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: BookingsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBookingItemDto createBookingItemDto)
        {

            if (ModelState.IsValid)
            {
                var bookingItem = await _bookingItemService.CreateBookingItemAsync(createBookingItemDto);
                if (bookingItem != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var bookingItemViewModel = new BookingItemViewModel
            {
                ServiceName = createBookingItemDto.ServiceName,
                Price = createBookingItemDto.Price,
                Deposit = createBookingItemDto.Deposit,
                IntervalStart = createBookingItemDto.IntervalStart,
                IntervalEnd = createBookingItemDto.IntervalEnd,
                BookingTimeInMinutes = createBookingItemDto.BookingTimeInMinutes,
            };

            return View(bookingItemViewModel);
        }

        // GET: BookingsController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var bookingItem = await _bookingItemService.GetBookingItemByIdAsync(id);
            if (bookingItem == null)
            {
                return NotFound();
            }

            var editBookingItemDto = new EditBookingItemDto
            {
                ServiceName = bookingItem.ServiceName,
                Price = bookingItem.Price,
                Deposit = bookingItem.Deposit,
                IntervalStart = bookingItem.IntervalStart,
                IntervalEnd = bookingItem.IntervalEnd,
                BookingTimeInMinutes = bookingItem.BookingTimeInMinutes,
                RowVersion = bookingItem.RowVersion,
            };

            return View(editBookingItemDto);
        }

        // POST: BookingsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditBookingItemDto editBookingItemDto)
        {
            try
            {
                var bookingItemId = await _bookingItemService.EditBookingItemAsync(id, editBookingItemDto);
                if (bookingItemId != Guid.Empty)
                {

                    _logger.LogInformation("Booking service er opdateret: {bookingItemId}", bookingItemId);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _logger.LogWarning("Kunne ikke opdatere booking service for ID: {Id}", id);
                    ModelState.AddModelError("", "Kunne ikke oprette opdatere en booking service.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Der opstod en uventet fejl ved opdatering af booking service med ID: {Id}", id);
                ModelState.AddModelError("", "Der opstod en uventet fejl: " + ex.Message);
            }

            return View(editBookingItemDto);
        }

    }
}
