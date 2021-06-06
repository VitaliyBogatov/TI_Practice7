using System;
using System.Collections.Generic;
using System.Text;

namespace TelenorSupport.Model
{
    public interface IDto<T>
    {
        T GetData(string line);
    }
}
