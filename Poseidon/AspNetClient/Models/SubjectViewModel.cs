using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetClient.Models
{
    public class SubjectViewModel
    {
        public Subject subject { get; private set; }
        public SubjectViewModel(Subject subject)
        {
            this.subject = subject;
        }
    }
}
