using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesAppModels.Models;

namespace MoviesApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase {

        private readonly DataContext bookingContext;
        public BookingController(DataContext context) {
            bookingContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookings>>>  Index() {
            return await bookingContext.Bookings.ToListAsync();

        }
        [HttpPost]
        public async Task<ActionResult<Bookings>> AddBooking(Bookings bookings) {
            bookingContext.Bookings.Add(bookings);
            return RedirectToAction("Index");
            bookingContext.SaveChanges();
           // return CreatedAtAction("GetBooking", new { id = bookings.id }, bookings);
        }


    }
}
