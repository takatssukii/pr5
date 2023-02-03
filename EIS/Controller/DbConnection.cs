using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIS.Controller
{
    internal class DbConnection
    {
        private static Model.EISEntities2 _model;

        public static Model.EISEntities2 GetContext()
        {
            if (_model == null)
            {
                _model = new Model.EISEntities2();
            }
            return _model;
        }
    }
}
