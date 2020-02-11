using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FluentApi.Tests
{
    public class DatabaseBuilderTests
    {
        [Fact]
        public void DatabaseBuilder_WithValidData_ReturnsValidJson()
        {
            IDatabaseBuilder databaseBuilder = DatabaseBuilder.Create();
            databaseBuilder
                .AddLogin()
                .WithCredential(
                    username: "login",
                    password: "password")
                .AndRole(
                    database: "acme")
                .AddRight(
                    permission: "read")
                .AddRight(
                    permission: "write");
            databaseBuilder
                .WithServer(
                    name: "server",
                    port: 8000,
                    version: new Version("0.0.0.1"));
            var json = databaseBuilder.Save();

            var obj = JsonConvert.DeserializeObject<Database>(json);

            Assert.Equal("server", obj.Server.Name);
            Assert.Equal("0.0.0.1", obj.Server.Version.ToString());
            Assert.Single(obj.Users);
            Assert.Equal("login", obj.Users[0].Username.ToString());
            Assert.Equal("password", obj.Users[0].Password.ToString());
        }
    }
}
