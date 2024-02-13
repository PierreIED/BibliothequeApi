using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi.Interfaces
{
    public interface IAuthenticationService
    {
        string GenerateToken(Admin user);
    }
}
