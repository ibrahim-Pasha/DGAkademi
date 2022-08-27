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
    public class SeriesController : ControllerBase
    {
        DgContext _Context;
        public SeriesController(DgContext context)
        {
            _Context = context;
        }

        [Authorize(Roles = "Manager")]
        [HttpPost("Add")]

        public IActionResult Add(Series series)
        {
            return AddSeries(series);
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Series series, [FromHeader] int id)
        {
            return UpdateSeries(series, id);
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("Delete{id}")]
        public IActionResult Delete(int id)
        {
            return DeleteSeries(id);
        }

        [Authorize]
        [HttpGet("getAll")]
        public List<Series> GetAllseries() => _Context.Set<Series>().ToList();

        [Authorize]
        [HttpGet("GetBy{id}")]
        public IActionResult Get(int id)
        {
            return GetSeriesById(id);
        }

        [Authorize]
        [HttpGet("GetPopular")]
        public List<Series> GetPopular()
        {
            return _Context.Set<Series>().Where(M => M.Popular == true).ToList();
        }
        /*****Methods******/

        /// <summary>
        /// To Add new Series
        /// </summary>
        /// <param name="series">Required Series data</param>
        /// <returns></returns>
        private IActionResult AddSeries(Series series)
        {
            SeriesValidator SV = new SeriesValidator();
            ValidationResult result = SV.Validate(series);
            if (result.IsValid)
            {
                var addedEntity = _Context.Entry(series);
                addedEntity.State = EntityState.Added;
                _Context.SaveChanges();
                return Ok(series);
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
        /// To get Series by Id
        /// </summary>
        /// <param name="id">Required int Id to select Series</param>
        /// <returns></returns>
        private IActionResult GetSeriesById(int id)
        {
            var series = _Context.Set<Series>().Where(m => m.Id == id);
            if (series.Any())
            {
                return Ok(series.SingleOrDefault());
            }
            return BadRequest("Not found");
        }
        /// <summary>
        ///  To Delete Series
        /// </summary>
        /// <param name="id">Required int Id to select</param>
        /// <returns></returns>
        private IActionResult DeleteSeries(int id)
        {
            var series = _Context.Set<Series>().Where(m => m.Id == id);
            if (series.Any())
            {
                var DelEntity = _Context.Entry(series.SingleOrDefault());
                DelEntity.State = EntityState.Deleted;
                _Context.SaveChanges();
                return Ok("deleted");
            }
            return BadRequest("Series not found to delete");
        }
        /// <summary>
        /// TO Update Series
        /// </summary>
        /// <param name="series">Required Series data</param>
        /// <param name="id">Required int Id to select</param>
        /// <returns></returns>
        private IActionResult UpdateSeries(Series series, int id)
        {
            var Series = _Context.Series.Where(m => m.Id == id);
            if (Series.Any())
            {
                var _series = Series.SingleOrDefault();
                SeriesValidator MV = new SeriesValidator();
                ValidationResult result = MV.Validate(series);
                if (result.IsValid)
                {
                    _series.Name = series.Name;
                    _series.Type = series.Type;
                    _series.Producer = series.Producer;
                    _series.Popular = series.Popular;
                    _series.Duration = series.Duration;
                    _series.Description = series.Description;
                    _Context.SaveChanges();
                    return Ok("Series Updated");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        return BadRequest(item.PropertyName + " : " + item.ErrorMessage);
                    }
                }
            }
            return BadRequest("Series not found to Update");
        }
    }
}
