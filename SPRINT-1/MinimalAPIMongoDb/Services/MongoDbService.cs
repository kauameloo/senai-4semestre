using MongoDB.Driver;

namespace MinimalAPIMongoDB.Services
{
    public class MongoDbService
    {
        /// <summary>
        /// Armazenar a configuracao da aplicação
        /// </summary>
        private readonly IConfiguration _configuration;
        
        /// <summary>
        /// Armazena uma referência ao mongodb
        /// </summary>
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Contem a configuracao necessaria para acesso ao mongodb
        /// </summary>
        /// <param name="configuration">Objeto contendo toda a configuracao da aplicacao</param>
        public MongoDbService(IConfiguration configuration)
        {
            //Atribui a config recebida em _configuration
            _configuration = configuration;

            //Acessa a string de conexao 
            var connectionString = _configuration.GetConnectionString("DbConnection");

            //Transforma a string obtida em MongoUrl
            var mongoUrl = MongoUrl.Create(connectionString);

            //Cria um client
            var mongoClient = new MongoClient(mongoUrl);

            //Obtem a referencia ao mongodb
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);           
        }

        /// <summary>
        /// Propriedade para acessar o banco de dados => retorna os dados em _database
        /// </summary>
        public IMongoDatabase GetDatabase => _database;
    }
}
