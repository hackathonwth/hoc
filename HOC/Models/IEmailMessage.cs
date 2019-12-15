using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HOC.Models
{
    public interface IEmailMessage
    {
        string subject { get; set; }
        string messageBody { get; set; }
    }
}
