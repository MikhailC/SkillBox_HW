using System;
using System.Collections.Generic;
using System.IO.Compression;
using Microsoft.VisualBasic.CompilerServices;

namespace Hw8
{
    public class Corporation
    {
        
        
        public  List<Department> Departments { get; set; } = new List<Department>();
        private static Corporation _corporation;


        public Department CurrentDepartment { get; set; }

    }

    }


