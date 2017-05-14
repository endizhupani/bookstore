using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace BookStore.UI.Modules
{
    public class BooksModule : NancyModule
    {
        public BooksModule() : base("/books")
        {
            Get["/"] = p => View["index.cshtml"];
        }
    }
}

