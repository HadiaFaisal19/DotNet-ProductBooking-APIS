using Admin.Data;
using Admin.Models;
using Admin.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public BookingController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllBookings()
        {
           

            return Ok(dbContext.Bookings.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetBookingById(Guid id)
        {
            var booking = dbContext.Bookings
       .Include(b => b.Products) // Include products related to the booking
       .FirstOrDefault(b => b.Id == id);

            booking = dbContext.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost]

        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var BookingEntity = new Booking()
            {
                CustomerName = createBookingDto.CustomerName,
                CustomerContact = createBookingDto.CustomerContact,
                ReferenceName = createBookingDto.ReferenceName,
                ReferenceContact = createBookingDto.ReferenceContact,
                StartDate = createBookingDto.StartDate,
                EndDate = createBookingDto.EndDate,
                StartShift = createBookingDto.StartShift,
                EndShift = createBookingDto.EndShift,
                Status = createBookingDto.Status,
                Total = createBookingDto.Total,
                Discount = createBookingDto.Discount,
                TotalBill = createBookingDto.TotalBill,
                Products = createBookingDto.ProductIds.Select(productId => dbContext.Products.Find(productId)).ToList()

            };
            dbContext.Bookings.Add(BookingEntity);
            dbContext.SaveChanges();

            return Ok(BookingEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public IActionResult UpdateBooking(Guid id, UpdateBookingDto updateBookingDto)
        {
            var booking = dbContext.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            booking.CustomerName = updateBookingDto.CustomerName;
            booking.CustomerContact = updateBookingDto.CustomerContact;
            booking.ReferenceName = updateBookingDto.ReferenceName;
            booking.ReferenceContact = updateBookingDto.ReferenceContact;
            booking.StartDate = updateBookingDto.StartDate;
            booking.EndDate = updateBookingDto.EndDate;
            booking.StartShift = updateBookingDto.StartShift;
            booking.EndShift = updateBookingDto.EndShift;
            booking.Status = updateBookingDto.Status;
            booking.Total = updateBookingDto.Total;
            booking.Discount = updateBookingDto.Discount;
            booking.TotalBill = updateBookingDto.TotalBill;

           //booking.Products=updateBookingDto.ProductIds;
            dbContext.SaveChanges();
            return Ok(booking);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult CancelBooking(Guid id)
        {
            var booking = dbContext.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }


            dbContext.Bookings.Remove(booking);
            dbContext.SaveChanges();
            return Ok(booking);

        }
    }
}
