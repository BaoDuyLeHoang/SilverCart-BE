﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Commons.Exceptions;
public class FieldError
{
    public string Field { get; set; }
    public string Message { get; set; }
}
