﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestBoard.Api.Interfaces
{
    public interface IRead<T>
    {
        T Get(string id);
        List<T> All();
    }
}
