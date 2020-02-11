using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApi
{
    public class DatabaseBuilder :
        IDatabaseBuilder,
        IUserBuilder,
        IRoleBuilder,
        IRightBuilder,
        IGroupBuilder,
        ICredentialBuilder
    {
        internal readonly Database Database = null;
        private List<Right> rights = null;
        private List<Login> logins = null;
        private List<Group> groups = null;
        private Role role = null;
        private Login login = null;
        private Group group = null;

        private static IDatabaseBuilder databaseBuilder = null;

        public static IDatabaseBuilder Create()
        {
            databaseBuilder = new DatabaseBuilder();
            return databaseBuilder;
        }

        private DatabaseBuilder()
        {
            Database = new Database();
            Database.Users = new List<Login>();
        }

        public IGroupBuilder AddGroups()
        {
            Database.Groups = new List<List<Group>>();

            return this;
        }

        public IUserBuilder AddGroup(string name = "")
        {
            groups = new List<Group>();
            group = new Group();
            group.Name = name;
            logins = new List<Login>();
            group.Logins = logins;

            groups.Add(group);
            Database.Groups.Add(groups);
            return this;
        }

        public ICredentialBuilder AddUser()
        {
            login = new Login();
            logins.Add(login);

            group.Logins.Add(login);
            return this;
        }

        public ICredentialBuilder AddLogin()
        {
            login = new Login();

            Database.Users.Add(login);
            return this;
        }

        public IConnectionBuilder WithServer(
            string name = "",
            int? port = null,
            Version? version = null)
        {
            Database.Server = new Server();
            Database.Server.Name = name;
            Database.Server.Port = port;
            Database.Server.Version = version;
            return this;
        }

        public IRoleBuilder WithCredential(
            string username, 
            string password)
        {
            login.Username = username;
            login.Password = password;

            return this;
        }

        public IRightBuilder AndRole(
            string database
            )
        {
            rights = new List<Right>();
            role = new Role()
            {
                Database = database,
                Rights = rights
            };
            login.Role = role;
            return this;
        }

        public IRightBuilder AddRight(
            string right
            )
        {
            rights.Add(new Right()
            {
                Permission = Enum.Parse<Permission>(right.ToUpper())
            });
            return this;
        }

        public string Save()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

            return JsonConvert.SerializeObject(Database, settings);
        }
    }
}
