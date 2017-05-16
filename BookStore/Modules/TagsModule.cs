using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.UI.Modules
{
    public class TagsModule : NancyModule
    {
        public TagsModule() : base("/tags")
        {
            Get["/"] = p => View["index.cshtml"];
        }
    }
}
