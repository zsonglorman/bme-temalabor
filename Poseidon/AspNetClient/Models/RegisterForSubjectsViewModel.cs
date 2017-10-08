using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;

namespace AspNetClient.Models
{
    public class RegisterForSubjectsViewModel
    {

        public IList<Interfaces.Subject> Subjects { get; private set; }

        public RegisterForSubjectsViewModel(List<Subject> subjects)
        {
            Subjects = subjects;
        }


    }
}
