using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApi
{
    public static class DatabaseExtensions
    {
        public static string Save(this IUsersBuilder usersBuilder)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

            return JsonConvert.SerializeObject((usersBuilder as DatabaseBuilder).Database, settings);
        }

        public static string Save(this IConnectionBuilder databaseBuilder)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

            return JsonConvert.SerializeObject((databaseBuilder as DatabaseBuilder).Database, settings);
        }
    }
}
