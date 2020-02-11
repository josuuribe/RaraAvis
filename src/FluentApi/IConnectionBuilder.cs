using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApi
{
    public interface IConnectionBuilder
    {
        IConnectionBuilder WithServer(
            string name = "",
            int? port = null,
            Version? version = null);
    }
}
