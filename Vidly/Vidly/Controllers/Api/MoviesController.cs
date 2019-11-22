using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DataAccessLayer;
using AutoMapper;
using Vidly.DTO;
using Vidly.App_Start;
using Vidly.Models;
using System.Data.Entity.Validation;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        #region Constructor

        public MoviesController()
        {
            _dbContext = new VidlyContext();
            _mapper = new Mapper(config);
        }

        #endregion

        #region properties

        private VidlyContext _dbContext;

        MapperConfiguration config = new MapperConfiguration(cfg => 
        cfg.AddProfile<MappingProfile>());

        private IMapper _mapper;

        #endregion

        #region Methods

        public IHttpActionResult GetMovies()
        {
            return Ok(_dbContext.Movies.ProjectToList<MovieDto>(config));
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(_mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);

            _dbContext.Movies.Add(movie);

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

            }
            //_dbContext.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);
        }

        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var MovieInDb = _dbContext.Movies.SingleOrDefault(x => x.Id == id);

            if (MovieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _mapper.Map(movieDto, MovieInDb);

            _dbContext.SaveChanges();
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieDb = _dbContext.Movies.SingleOrDefault(x => x.Id == id);

            if (movieDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dbContext.Movies.Remove(movieDb);
            _dbContext.SaveChanges();
        }

        #endregion
    }
}
