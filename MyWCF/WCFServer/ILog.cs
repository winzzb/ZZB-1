﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    interface ILog
    {
        bool Log(LogInfo info);
    }

    
}