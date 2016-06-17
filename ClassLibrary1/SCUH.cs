using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCUH
{
    public class SCUH
    {
        private static readonly SCUH _instance = new SCUH();

        private SCUH()
        {
            //TODO - initiate connects
        }

        public static SCUH Instance
        {
            get { return _instance; }
        }
    }
}
