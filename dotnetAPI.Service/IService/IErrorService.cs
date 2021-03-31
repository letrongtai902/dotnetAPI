using dotnetAPI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetAPI.Service.IService
{
    public interface IErrorService
    {
        void Create(Error error);
        void Commit();
    }
}
