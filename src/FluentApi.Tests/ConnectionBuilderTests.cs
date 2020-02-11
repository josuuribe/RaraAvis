using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FluentApi.Tests
{
    public class ConnectionBuilderTests
    {
        [Fact]
        public void CreateBuilder_WithValidServerData_ReturnsValidJson()
        {
            IConnectionBuilder connectionBuilder = DatabaseBuilder
                .Create()
                .WithServer(
                    name: "server",
                    port: 8000,
                    version: new Version("0.0.0.1"));
            var json = connectionBuilder.Save();

            var obj = JsonConvert.DeserializeObject<Database>(json);

            Assert.Equal("server", obj.Server.Name);
            Assert.Equal(8000, obj.Server.Port);
            Assert.Equal("0.0.0.1", obj.Server.Version.ToString());
        }
    }
}
