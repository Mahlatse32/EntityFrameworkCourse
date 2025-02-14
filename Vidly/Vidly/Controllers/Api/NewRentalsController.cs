﻿using System;
using System.Linq;
using System.Web.Http;
using Vidly.DataAccessLayer;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.Api
{

    public class NewRentalsController : ApiController
    {
        private VidlyContext _context;

        public NewRentalsController()
        {
            _context = new VidlyContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id));

            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }


    }
}