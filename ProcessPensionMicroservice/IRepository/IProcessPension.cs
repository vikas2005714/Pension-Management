using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPensionMicroservice
{
    public interface IProcessPension
    {
        public ApiResult CalculatePension(long AadharNo);
    }
}
