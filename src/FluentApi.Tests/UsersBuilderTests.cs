using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Dynamic;
using Xunit;

namespace FluentApi.Tests
{
    public class UsersBuilderTests
    {
        [Fact]
        public void CreateBuilder_WithCompleteUser_ReturnsValidJson()
        {
            IUsersBuilder builder = DatabaseBuilder
                .Create()
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
            string json = builder.Save();

            var obj = JsonConvert.DeserializeObject<Database>(json);

            Assert.Single(obj.Users);
            Assert.Equal("login", obj.Users[0].Username.ToString());
            Assert.Equal("password", obj.Users[0].Password.ToString());
        }

        [Fact]
        public void CreateBuilder_WithValidUsersDataAndPermissions_ReturnsValidJson()
        {
            IUsersBuilder builder = DatabaseBuilder
                .Create()
                .AddLogin()
                .WithCredential(
                    username: "login1",
                    password: "password1")
                .AndRole(
                    database: "acme1")
                .AddRight(
                    permission: "read")
                .AddLogin()
                .WithCredential(
                    username: "login2",
                    password: "password2")
                .AndRole(
                    database: "acme2")
                .AddRight(
                    permission: "read")
                .AddRight(
                    permission: "write");
            string json = builder.Save();

            var obj = JsonConvert.DeserializeObject<Database>(json);

            Assert.Equal(2, obj.Users.Count);
            Assert.Equal("login1", obj.Users[0].Username.ToString());
            Assert.Equal("password1", obj.Users[0].Password.ToString());
            Assert.Single(obj.Users[0].Role.Rights);
            Assert.Equal(Permission.READ, obj.Users[0].Role.Rights[0].Permission);
            Assert.Equal("login2", obj.Users[1].Username.ToString());
            Assert.Equal("password2", obj.Users[1].Password.ToString());
            Assert.Equal(2, obj.Users[1].Role.Rights.Count);
            Assert.Equal(Permission.READ, obj.Users[1].Role.Rights[0].Permission);
            Assert.Equal(Permission.WRITE, obj.Users[1].Role.Rights[1].Permission);
        }

        [Fact]
        public void CreateBuilder_AddGroup_ReturnsValidJson()
        {
            IUsersBuilder builder = DatabaseBuilder
                .Create()
                .AddGroups()
                .AddGroup(
                    name: "acme1"
                )
                .AddUser()
                .WithCredential(
                    username: "acme1",
                    password: "acme_pass1"
                )
                .AndRole(
                    database: "acme1")
                .AddRight("read")
                .AddRight("write")
                .AddGroup(
                    name: "acme2"
                )
                .AddUser()
                .WithCredential(
                    username: "acme2",
                    password: "acme_pass2"
                )
                .AndRole(
                    database: "acme2")
                .AddRight("write");
            string json = builder.Save();

            var obj = JsonConvert.DeserializeObject<Database>(json);

            Assert.Equal(2, obj.Groups.Count);
            Assert.Equal("acme1", obj.Groups[0][0].Name);
            Assert.Equal("acme1", obj.Groups[0][0].Logins[0].Username);
            Assert.Equal("acme_pass1", obj.Groups[0][0].Logins[0].Password);
            Assert.Equal(2, obj.Groups[0][0].Logins[0].Role.Rights.Count);
            Assert.Equal("acme1", obj.Groups[0][0].Logins[0].Role.Database);
            Assert.Equal(Permission.READ, obj.Groups[0][0].Logins[0].Role.Rights[0].Permission);
            Assert.Equal(Permission.WRITE, obj.Groups[0][0].Logins[0].Role.Rights[1].Permission);

            Assert.Equal("acme2", obj.Groups[1][0].Name);
            Assert.Equal("acme2", obj.Groups[1][0].Logins[0].Username);
            Assert.Equal("acme_pass2", obj.Groups[1][0].Logins[0].Password);
            Assert.Single(obj.Groups[1][0].Logins[0].Role.Rights);
            Assert.Equal("acme2", obj.Groups[1][0].Logins[0].Role.Database);
            Assert.Equal(Permission.WRITE, obj.Groups[1][0].Logins[0].Role.Rights[0].Permission);
        }
    }
}
