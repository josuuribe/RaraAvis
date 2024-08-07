using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpToDate.Helpers
{
    [Experimental("DiagID", UrlFormat = "https://example.org/{0}")]
    public class GenericCustomAttribute<T> : Attribute { }
}
