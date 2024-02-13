using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi
{
    public class Admin : Personne
    {
        public string MotDePasse { get; set; }
        public string UserName { get; set; }
    }
}
