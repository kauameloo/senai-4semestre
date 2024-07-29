using Microsoft.AspNetCore.Mvc;
using MinimalAPIMongoDB.Domains;
using MinimalAPIMongoDB.Services;
using MongoDB.Driver;

namespace MinimalAPIMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClientController : Controller
    {
        private readonly IMongoCollection<Client> _client;

        public ClientController(MongoDbService mongoDbService)
        {
            _client = mongoDbService.GetDatabase.GetCollection<Client>("client");
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> Get()
        {
            try
            {
                var clients = await _client.Find(FilterDefinition<Client>.Empty).ToListAsync();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPost]
        public ActionResult Post(Client client)
        {
            try
            {
                User user = new User();
                user.Id = client.UserId;
                _client.InsertOne(client);
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
                var clientBuscado = _client.Find(u => u.Id == id).FirstOrDefault();

                return clientBuscado is not null ? Ok(clientBuscado) : NotFound();
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
                var clientBuscado = _client.FindOneAndDelete(c => c.Id == id);

                return Ok();
            }
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Client c)
        {
            try
            {
                //buscar por id (filtro)
                var filter = Builders<Client>.Filter.Eq(x => x.Id, c.Id);

                if (filter != null)
                {
                    //substituindo o objeto buscado pelo novo objeto
                    await _client.ReplaceOneAsync(filter, c);
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
