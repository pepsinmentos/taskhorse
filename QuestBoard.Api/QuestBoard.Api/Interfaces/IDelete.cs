﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestBoard.Api.Interfaces
{
    public interface IDelete<T>
    {
        T Delete(string id);
    }
}
