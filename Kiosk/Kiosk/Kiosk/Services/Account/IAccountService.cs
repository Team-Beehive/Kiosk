using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk
{
    public interface IAccountService
    {
        Task<string> LoginWithEmailPassword(string email, string password);

    }
}
