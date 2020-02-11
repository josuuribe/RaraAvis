using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApi
{
    public interface IDatabaseBuilder : IConnectionBuilder, IUsersBuilder
    {
        string Save();
    }
}
