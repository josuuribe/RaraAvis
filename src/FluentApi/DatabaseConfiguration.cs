using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FluentApi
{
    class Database
    {
        public List<List<Group>> Groups { get; set; }
        public List<Login> Users { get; set; }
        public Server Server { get; set; }
    }

    class Group
    {
        public string Name { get; set; }
        public List<Login> Logins { get; set; }
    }

    internal class DatabaseConfiguration
    {
        public int MaxUsers { get; set; }
        public string ConnectionString { get; set; }
    }

    internal class Role
    {
        public string Database;
        public List<Right> Rights;
    }

    internal class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }

    internal class Server
    {
        public string Name { get; set; }
        public int? Port { get; set; }
        public Version Version { get; set; }
    }

    enum Permission { READ, WRITE }

    internal class Right
    {
        public Permission Permission { get; set; }
    }
}
