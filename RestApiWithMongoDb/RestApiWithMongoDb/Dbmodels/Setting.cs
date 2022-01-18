using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiWithMongoDb.Dbmodels
{
    public class Setting
    {
        public string ConectionString;
        public string Database;
        public IConfigurationRoot iConfigurationRoot;

    }
}
