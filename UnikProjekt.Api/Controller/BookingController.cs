using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Application.Commands;
using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Queries;
using UnikProjekt.Application.Queries.DTOs;
using UnikProjekt.Infrastructure.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnikProjekt.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingQueries _bookingQueries;
        private readonly IBookingCommand _bookingCommand;

        public BookingController(IBookingQueries bookingQueries, IBookingCommand bookingCommand)
        {
            _bookingQueries = bookingQueries;
            _bookingCommand = bookingCommand;
        }

        // GET: api/<BookingController>
        [HttpGet]
        public ActionResult<IEnumerable<BookingDto>> Get()
        {
            var result = _bookingQueries.GetAllBookings();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET api/<BookingController>/5
        [HttpGet("{id:guid}", Name = "GetBookingById")]
        public ActionResult<BookingDto> GetBookingById(Guid id)
        {
            var result = _bookingQueries.GetBookingById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id:guid}", Name = "GetBookingByUser")]
        public ActionResult<BookingDto> GetBookingByUser(Guid userId)
        {
            var result = _bookingQueries.GetBookingByUser(userId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/<BookingController>
        [HttpPost(Name = "CreateBooking")]
        public IActionResult Post([FromBody] CreateBookingDto createBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookingToCreate = new CreateBookingDto
            {
                UserId = createBookingDto.UserId,
                DateBooked = createBookingDto.DateBooked,
                Items = createBookingDto.Items,
            };

            var bookingId = _bookingCommand.CreateBooking(bookingToCreate);

            if (bookingId == Guid.Empty)
            {
                return NotFound();
            }
            //Http Status code '201 Created'
            return CreatedAtAction("CreateBooking", new { Id = bookingId }, bookingToCreate);
        }

        // PUT api/<BookingController>/5
        [HttpPut(Name = "UpdateBooking")]
        public IActionResult Put([FromBody] UpdateBookingDto updateBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookingToUpdate = new UpdateBookingDto
            {
                Id = updateBookingDto.Id,
                UserId = updateBookingDto.UserId,
                DateBooked = updateBookingDto.DateBooked,
                Items = updateBookingDto.Items,
                RowVersion = updateBookingDto.RowVersion
            };

            var bookingId = _bookingCommand.UpdateBooking(bookingToUpdate);

            if (bookingId == Guid.Empty)
            {
                return NotFound();
            }
            //Http Status code '201 Created'
            return CreatedAtAction("UpdateBooking", new { Id = bookingId }, bookingToUpdate);
        }

        [HttpPut(Name = "DeleteSelectedBookingLines")]
        public IActionResult DeleteSelectedBookingLines([FromBody] UpdateBookingDto updateBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookingToUpdate = new UpdateBookingDto
            {
                Id = updateBookingDto.Id,
                UserId = updateBookingDto.UserId,
                DateBooked = updateBookingDto.DateBooked,
                Items = updateBookingDto.Items,
                RowVersion = updateBookingDto.RowVersion
            };

            var bookingId = _bookingCommand.DeleteSelectedBookingLines(bookingToUpdate);

            if (bookingId == Guid.Empty)
            {
                return NotFound();
            }
            //Http Status code '201 Created'
            return CreatedAtAction("DeleteSelectedBookingLines", new { Id = bookingId }, bookingToUpdate);
        }
    }
}
