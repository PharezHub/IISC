using API.Core.Models;
using IISC.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IISC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderRepository orderRepository;

        public PurchaseOrderController(IPurchaseOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        // GET: api/<PurchaseOrderController>
        //[HttpGet("/AllOrders")]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<PurchaseOrderController>/5
        [HttpGet("/Orders/{PurchaseOrder},{Stockcode}")]
        public async Task<IActionResult> GetPO(string PurchaseOrder, string Stockcode)
        {
            return Ok( await orderRepository.GetPoDetail(PurchaseOrder, Stockcode));
        }

        // POST api/<PurchaseOrderController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<PurchaseOrderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<PurchaseOrderController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
