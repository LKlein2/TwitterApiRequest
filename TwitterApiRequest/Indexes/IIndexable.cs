using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterApiRequest.Indexes
{
    public interface IIndexable
    {
        string GetKey();
        long GetPos();
    }
}
