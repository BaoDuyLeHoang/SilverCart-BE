﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures
{
    public static class AssemblyReference
    {
        public static readonly Assembly Executing = Assembly.GetExecutingAssembly();
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
