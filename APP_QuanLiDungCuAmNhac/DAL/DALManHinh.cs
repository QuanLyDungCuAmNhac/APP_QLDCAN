using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DALManHinh
    {
        public QL_DCANDataContext qldc = new QL_DCANDataContext();
        public DALManHinh() { }
        public List<DM_ManHinh> LoadMH()
        {
            return qldc.DM_ManHinhs.Select(mh=>mh).ToList<DM_ManHinh>();
        }
    }
}
