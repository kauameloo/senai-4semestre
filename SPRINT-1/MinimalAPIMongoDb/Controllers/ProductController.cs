using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalAPIMongoDB.Domains;
using MinimalAPIMongoDB.Services;
using MongoDB.Driver;

namespace MinimalAPIMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IMongoCollection<Product> _product;

        public ProductController(MongoDbService mongoDbService)
        {
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            try
            {
                var products = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            try
            {
                _product.InsertOne(product);
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
                //var produtoBuscado = new Product();
                var produtoBuscado = _product.Find(p => p.Id == id).FirstOrDefault();

                return produtoBuscado is not null? Ok(produtoBuscado) : NotFound();
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
                //var produtoBuscado = new Product();
                var produtoBuscado = _product.FindOneAndDelete(p => p.Id == id);

                return Ok();
            }
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));
            }
        }


        /// <summary>
        /// A FAZEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEER
        /// </summary>
        /// <param name="id"></param>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update(Product p)
        {
            try
            {
                //var product = await _product.Find(x => x.Id == p.Id).FirstOrDefaultAsync();

                //buscar por id (filtro)
                var filter = Builders<Product>.Filter.Eq(x => x.Id, p.Id);

                if (filter != null)
                {
                    //substituindo o objeto buscado pelo novo objeto
                    await _product.ReplaceOneAsync(filter, p);
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
