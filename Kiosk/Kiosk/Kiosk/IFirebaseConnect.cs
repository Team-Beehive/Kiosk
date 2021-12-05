using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk
{
    public interface IFirebaseConnect
    {
        Task<MajorData> GetMajor(string Major);

        Task<LinkedList<string>> GetMajorsList();
    }
}
