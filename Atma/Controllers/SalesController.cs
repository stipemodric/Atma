using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atma.Core.Entities;
using Atma.DataAccess;
using Atma.DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Atma.Web.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private ISalesRepository _salesRepo;
        public SalesController(ISalesRepository salesRepo)
        {
            _salesRepo = salesRepo;
        }

        //// GET: api/<SalesController>
        //[HttpGet]
        //public async Task<int> GetSoldArticles()
        //{
        //    try
        //    {
        //        return await _salesRepo.GetSoldArticles();
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SalesController>
        [HttpPost]
        public async Task<IActionResult> Post(SalesAddViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseConstants.InvalidModelState);
            }

            try
            {
                var result = await _salesRepo.Add(viewModel);

                return Ok(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(int id, [FromBody] SalesUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                return await _salesRepo.Update(id, viewModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public Task<int> Delete(int id)
        {
            try
            {
                return _salesRepo.SoftDelete(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("get-revenue")]
        public async Task<ICollection<SalesGetViewModel>> GetRevenue()
        {
            try
            {
                return await _salesRepo.GetRevenue();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("get-sold")]
        public async Task<ICollection<SalesGetViewModel>> GetSoldArticles()
        {
            try
            {
                return await _salesRepo.GetSoldArticles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("get-stats")]
        public async Task<ICollection<SalesGetViewModel>> GetStats()
        {
            try
            {
                return await _salesRepo.GetStats();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
