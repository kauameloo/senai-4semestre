using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalAPIMongoDB.Domains;
using MinimalAPIMongoDB.Services;
using MinimalAPIMongoDB.ViewModels;
using MongoDB.Driver;

namespace MinimalAPIMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _order;
        private readonly IMongoCollection<Client> _client;
        private readonly IMongoCollection<Product> _product;

        public OrderController(MongoDbService mongoDbService)
        {
            _order = mongoDbService.GetDatabase.GetCollection<Order>("order");
            _client = mongoDbService.GetDatabase.GetCollection<Client>("client");
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                var orders = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();

                foreach (var order in orders)
                {
                    if (order.ProductId != null)
                    {
                        var filter = Builders<Product>.Filter.In(p => p.Id, order.ProductId);

                        order.Products = await _product.Find(filter).ToListAsync();
                    }

                    if(order.ClientId != null)
                    {
                        order.Client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();
                    }
                }


                return Ok(orders);

                //Order order = new Order();
                //List<Product> products = await _product.Find(x => x.Id == order.Id).ToListAsync();


                //order.Products = products;

                //return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(string id)
        {
            try
            {
                var order = await _order.Find(x => x.Id == id).FirstOrDefaultAsync();

                if (order == null)
                {
                    return BadRequest("Pedido não encontrado.");
                }

                if (order.ProductId != null)
                {
                    var filter = Builders<Product>.Filter.In(x => x.Id, order.ProductId);

                    order.Products = await _product.Find(filter).ToListAsync();
                }

                if (order.ClientId != null)
                {
                    order.Client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post(OrderViewModel orderViewModel)
        {
            try
            {
                Order order = new Order();

                order.Id = orderViewModel.Id;
                order.Date = order.Date;
                order.Status = orderViewModel.Status;
                order.ProductId = orderViewModel.ProductId;
                order.ClientId = orderViewModel.ClientId;

                var client = await _client.Find(x => x.Id == orderViewModel.ClientId).FirstOrDefaultAsync();

                if (client == null)
                {
                    return NotFound("Cliente não existe!");
                }
                order.Client = client;

                await _order.InsertOneAsync(order);

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            try
            {
                _order.FindOneAndDelete(x => x.Id == id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Order order)
        {
            try
            {
                //buscar por id (filtro)
                var filter = Builders<Order>.Filter.Eq(x => x.Id, order.Id);

                if (filter != null)
                {
                    //substituindo o objeto buscado pelo novo objeto
                    await _order.ReplaceOneAsync(filter, order);

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