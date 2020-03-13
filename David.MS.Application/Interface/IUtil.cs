using System;
using System.Collections.Generic;
using System.Text;

namespace David.MS.Application.Interface
{
    public interface IUtil
    {
        T GetXml<T>(string uri);
    }
}
