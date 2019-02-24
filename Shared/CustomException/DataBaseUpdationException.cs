using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CustomException
{
   public class DataBaseUpdationException : Exception
    {
        public DataBaseUpdationException(string message)
      : base(message)
        {
        }
    }
}
