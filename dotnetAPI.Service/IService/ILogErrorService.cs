using dotnetAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetAPI.Service.IService
{
    public interface ILogErrorService
    {
        void Create(LogError error);
    }
}
