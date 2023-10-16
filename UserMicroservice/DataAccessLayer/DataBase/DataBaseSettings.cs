using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataBase
{
    public class DataBaseSettings:IDataBaseSettings
    {
        public required string ClinicCollectionName { get; set; }
        public required string ConnectionString { get; set; }
        public required string DatabaseName { get; set; }
    }
}
