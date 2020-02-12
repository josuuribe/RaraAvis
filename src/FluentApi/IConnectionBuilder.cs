using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApi
{
    public interface IConnectionBuilder
    {
    /// <summary>
    /// This method sets which server is going to be used to connect to database.
    /// </summary>
    /// <param name="name">Server name or IP, by default localhost.</param>
    /// <param name="port">Por to connect to server, by default 669.</param>
    /// <param name="version">Driver version to use, by default the last one available.</param>
    IConnectionBuilder WithServer(
        string name = "localhost",
        int? port = 669,
        Version? version = null);
    }
}
