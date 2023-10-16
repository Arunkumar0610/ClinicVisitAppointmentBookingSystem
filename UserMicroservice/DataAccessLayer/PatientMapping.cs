using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using MongoDB.Bson.Serialization;

namespace DataAccessLayer
{
    public class PatientMapping
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Patient>(cm =>
            {
                cm.AutoMap();
                cm.MapMember(p => p.DateOfBirth).SetSerializer(new CustomDateSerializer());
            });
        }
    }
}
