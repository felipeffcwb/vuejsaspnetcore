using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Helpers
{
    public enum RegisterErrors
    {
        AlreadyRegistered,
        NameHasEmpty,
        EmailHasEmpty,
        JobHasEmpty,
        Success
    }
}
