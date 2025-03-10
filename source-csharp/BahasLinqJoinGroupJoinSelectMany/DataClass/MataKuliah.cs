using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BahasLinqJoinGroupJoinSelectMany.DataClass
{
    public class MataKuliah
    {
        public int KuliahId { get; set; }
        public string NamaMataKuliah { get; set; } = string.Empty;
        public int SksTiapSemester { get; set; }
    }
}
