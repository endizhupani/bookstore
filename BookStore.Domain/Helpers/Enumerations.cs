using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Helpers
{
    public enum Operator
    {
        Like = 1,
        LessThan = 2,
        EqualOrLessThan = 3,
        GreaterThan = 4,
        EqualOrGreaterThan = 5,
        Equal = 6,
        NotEqual = 7,
        StartsWith = 8,
        EndsWith = 9
    }
}
