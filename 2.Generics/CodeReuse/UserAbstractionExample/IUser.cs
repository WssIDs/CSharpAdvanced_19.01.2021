﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReuse.UserAbstractionExample
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
