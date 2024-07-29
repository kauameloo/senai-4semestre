using Microsoft.AspNetCore.Mvc;
using MinimalAPIMongoDB.Domains;
using MinimalAPIMongoDB.Services;
using MongoDB.Driver;

namespace MinimalAPIMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private readonly IMongoCollection<User> _user;

        public UserController(MongoDbService mongoDbService)
        {
            _user = mongoDbService.GetDatabase.GetCollection<User>("user");
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            try
            {
                var users = await _user.Find(FilterDefinition<User>.Empty).ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPost]
        public ActionResult Post(User user)
        {
            try
            {
                _user.InsertOne(user);
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
                var userBuscado = _user.Find(u => u.Id == id).FirstOrDefault();

                return userBuscado is not null ? Ok(userBuscado) : NotFound();
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
                var userBuscado = _user.FindOneAndDelete(u => u.Id == id);

                return Ok();
            }
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(User u)
        {
            try
            {
                //buscar por id (filtro)
                var filter = Builders<User>.Filter.Eq(x => x.Id, u.Id);

                if (filter != null)
                {
                    //substituindo o objeto buscado pelo novo objeto
                    await _user.ReplaceOneAsync(filter, u);
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
