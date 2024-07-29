using Microsoft.AspNetCore.Mvc;
using MinimalAPIMongoDB.Domains;
using MinimalAPIMongoDB.Services;
using MongoDB.Driver;

namespace MinimalAPIMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : Controller
    {
        private readonly IMongoCollection<Order> _order;

        public OrderController(MongoDbService mongoDbService)
        {
            _order = mongoDbService.GetDatabase.GetCollection<Order>("order");
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                var orders = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPost]
        public ActionResult Post(Order order)
        {
            try
            {
                _order.InsertOne(order);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            try
            {
                var orderBuscado = _order.Find(u => u.Id == id).FirstOrDefault();

                return orderBuscado is not null ? Ok(orderBuscado) : NotFound();
            }
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));
            }
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            try
            {
                var orderBuscado = _order.FindOneAndDelete(c => c.Id == id);

                return Ok();
            }
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Order c)
        {
            try
            {
                //buscar por id (filtro)
                var filter = Builders<Order>.Filter.Eq(x => x.Id, c.Id);

                if (filter != null)
                {
                    //substituindo o objeto buscado pelo novo objeto
                    await _order.ReplaceOneAsync(filter, c);
                    return Ok();
                }

                return NotFound();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}