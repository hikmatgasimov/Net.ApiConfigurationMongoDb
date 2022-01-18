using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RestApiWithMongoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiWithMongoDb.Dbmodels
{
    public class ObjectContext
    {
        public IConfiguration Configuration { get; set; }
        private IMongoDatabase _database = null;

        public ObjectContext(IOptions<Setting>settings)
        {
            Configuration = settings.Value.iConfigurationRoot;
            settings.Value.ConectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            settings.Value.Database = Configuration.GetSection("MongoConnection:Database").Value;

            var client = new MongoClient(settings.Value.ConectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }
        public IMongoCollection<Student> Students
        {
            get
            {
                return _database.GetCollection<Student>("Student");
            }
        }
        
    }
}
 