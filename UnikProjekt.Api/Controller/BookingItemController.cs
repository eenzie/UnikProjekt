using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Application.Commands;
using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Queries;
using UnikProjekt.Application.Queries.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnikProjekt.Api.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class BookingItemController : ControllerBase
    {
        private readonly IBookingItemQueries _bookingItemQueries;
        private readonly IBookingItemCommand _bookingItemCommand;

        public BookingItemController(IBookingItemQueries bookingItemQueries, IBookingItemCommand bookingItemCommand)
        {
            _bookingItemQueries = bookingItemQueries;
            _bookingItemCommand = bookingItemCommand;
        }

        // GET: <BookingItemController>
        [HttpGet(Name = "GetAllBookingItems")]
        public ActionResult<IEnumerable<BookingItemDto>> GetAllBookingItems()
        {
            var result = _bookingItemQueries.GetAllBookingItems();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET <BookingItemController>/5
        [HttpGet("{id:guid}", Name = "GetBookingItemById")]
        public ActionResult<BookingItemDto> GetBookingItemById(Guid id)
        {
            var result = _bookingItemQueries.GetBookingItemById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{name}", Name = "GetBookingItemByName")]
        public IActionResult GetBookingItemByName(string name)
        {
            var result = _bookingItemQueries.GetBookingItemByName(name);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST <BookingItemController>
        [HttpPost(Name = "CreateBookingItem")]
        public IActionResult CreateBookingItem([FromBody] CreateBookingItemDto createBookingItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookingItemToCreate = new CreateBookingItemDto
            {
                ServiceName = createBookingItemDto.ServiceName,
                Price = createBookingItemDto.Price,
                Deposit = createBookingItemDto.Deposit,
                IntervalStart = createBookingItemDto.IntervalStart,
                IntervalEnd = createBookingItemDto.IntervalEnd,
                BookingTimeInMinutes = createBookingItemDto.BookingTimeInMinutes
            };

            var bookingItemId = _bookingItemCommand.CreateBookingItem(bookingItemToCreate);

            if (bookingItemId == Guid.Empty)
            {
                return NotFound();
            }
            //Http Status code '201 Created'
            return CreatedAtAction("CreateBookingItem", new { Id = bookingItemId }, bookingItemToCreate);
        }

        // PUT <BookingItemController>/5
        [HttpPut(Name = "UpdateBookingItem")]
        public IActionResult UpdateBookingItem([FromBody] UpdateBookingItemDto updateBookingItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookingItemToUpdate = new UpdateBookingItemDto
            {
                Id = updateBookingItemDto.Id,
                ServiceName = updateBookingItemDto.ServiceName,
                Price = updateBookingItemDto.Price,
                Deposit = updateBookingItemDto.Deposit,
                IntervalStart = updateBookingItemDto.IntervalStart,
                IntervalEnd = updateBookingItemDto.IntervalEnd,
                BookingTimeInMinutes = updateBookingItemDto.BookingTimeInMinutes,
                RowVersion = updateBookingItemDto.RowVersion,
            };

            var bookingItemId = _bookingItemCommand.UpdateBookingItem(bookingItemToUpdate);

            if (bookingItemId == Guid.Empty)
            {
                return NotFound();
            }
            //Http Status code '201 Created'
            return CreatedAtAction("UpdateBookingItem", new { Id = bookingItemId }, bookingItemToUpdate);
        }
    }
}
