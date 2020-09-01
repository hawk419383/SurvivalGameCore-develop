using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurvivalGameCoreAPI.ViewModels
{
    public class APIResult<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Exception { get; set; }
        public T Data { get; set; }
    }
}
