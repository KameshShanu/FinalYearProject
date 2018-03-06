using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataHelper.Exceptions
{
   public class LeapRunnerException: Exception
    {
        public LeapRunnerException() { }
        public LeapRunnerException(string message) : base(message) { }
        public LeapRunnerException(string message, LeapRunnerException inner) : base(message, inner) { }
        protected LeapRunnerException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
