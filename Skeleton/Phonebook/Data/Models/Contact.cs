using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Data.Models
{
    public class Contact
    {
        [Recuired]
        public string Name { get; set; }

        [Recuired]
        public string Number { get; set; }
    }
}
