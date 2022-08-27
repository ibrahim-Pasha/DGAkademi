using Entity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApi.DGDbContext;
using WebApi.ValidationRules;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        DgContext _Context;
        public MovieController(DgContext context)
        {
            _Context = context;
        }

        [Authorize(Roles = "Manager")]
        [HttpPost("Add")]
        public IActionResult Add(Movie movie)
        {
            return AddMovie(movie);
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Movie movie, [FromHeader] int id)
        {
            return UpdateMovie(movie, id);
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("Delete{id}")]
        public IActionResult Delete(int id)
        {
            return DeleteMovie(id);
        }

        [Authorize]
        [HttpGet("getAll")]
        public List<Movie> GetAllmovies() => _Context.Set<Movie>().ToList();

        [Authorize]
        [HttpGet("GetBy{id}")]
        public IActionResult Get(int id)
        {
            return GetBuId(id);
        }

        [Authorize]
        [HttpGet("GetPopular")]
        public List<Movie> GetPopular()
        {
            return _Context.Set<Movie>().Where(M => M.Popular == true).ToList();
        }

                             /********Methods********/
        /// <summary>
        /// To Add new Movie
        /// </summary>
        /// <param name="movie">Required movie data</param>
        /// <returns></returns>
        private IActionResult AddMovie(Movie movie)
        {
            MovieValidator MV = new MovieValidator();
            ValidationResult result = MV.Validate(movie);
            if (result.IsValid)
            {
                var addedEntity = _Context.Entry(movie);
                addedEntity.State = EntityState.Added;
                _Context.SaveChanges();
                return Ok(movie);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    return BadRequest(item.PropertyName + " : " + item.ErrorMessage);
                }
            }
            return Ok();
        }
        
        /// <summary>
        /// To Update Movie data
        /// </summary>
        /// <param name="movie">Required Movie data</param>
        /// <param name="id">Required int Id to select Movie</param>
        /// <returns></returns>
        private IActionResult UpdateMovie(Movie movie, int id)
        {
            var Movie = _Context.Movies.Where(m => m.Id == id);
            if (Movie.Any())
            {
                var _movie = Movie.SingleOrDefault();
                MovieValidator MV = new MovieValidator();
                ValidationResult result = MV.Validate(movie);
                if (result.IsValid)
                {
                    _movie.Name = movie.Name;
                    _movie.Type = movie.Type;
                    _movie.Producer = movie.Producer;
                    _movie.Popular = movie.Popular;
                    _movie.Duration = movie.Duration;
                    _movie.Description = movie.Description;
                    _Context.SaveChanges();
                    return Ok("Movie Updated");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        return BadRequest(item.PropertyName + " : " + item.ErrorMessage);
                    }
                }
            }
            return BadRequest("movie not found to Update");
        }
        /// <summary>
        /// To Delete Movie
        /// </summary>
        /// <param name="id">Required int Id to select Movie</param>
        /// <returns></returns>
        private IActionResult DeleteMovie(int id)
        {
            var movie = _Context.Set<Movie>().Where(m => m.Id == id);
            if (movie.Any())
            {
                var DelEntity = _Context.Entry(movie.SingleOrDefault());
                DelEntity.State = EntityState.Deleted;
                _Context.SaveChanges();
                return Ok("deleted");
            }
            return BadRequest("movie not found to delete");
        }
        /// <summary>
        /// To get Movie by Id
        /// </summary>
        /// <param name="id">Required int Id to select Movie</param>
        /// <returns></returns>
        private IActionResult GetBuId(int id)
        {
            var movie = _Context.Set<Movie>().Where(m => m.Id == id);
            if (movie.Any())
            {
                return Ok(movie.SingleOrDefault());
            }
            return BadRequest("Not found");
        }
    }

}
