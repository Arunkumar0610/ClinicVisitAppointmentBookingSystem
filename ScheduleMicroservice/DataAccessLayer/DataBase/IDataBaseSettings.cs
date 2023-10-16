using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataBase
{
    public interface IDataBaseSettings
    {
        public string ClinicCollectionName { get; set; }
        public string ClinicCollectionName1 { get; set; }
        public string ClinicCollectionName2 { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
