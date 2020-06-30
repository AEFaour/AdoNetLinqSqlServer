using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppRequetesLinq.Model;

namespace WpfAppRequetesLinq.viewModel
{
    class ClassRequetesLinq : IDisposable
    {
        private static BBVideotheque2Entities dtc;

        public ClassRequetesLinq()
        {
            if (dtc == null)
            {
                dtc = new BBVideotheque2Entities();
            }
        }

        #region Methods

        #endregion

        public void Dispose()
        {
            dtc.Dispose();
        }
    }
}
