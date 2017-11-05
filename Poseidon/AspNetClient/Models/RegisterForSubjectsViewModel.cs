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
            if (subjects != null)
                Subjects = subjects;
            else
                Subjects = new List<Subject>();
        }   


    }
}
