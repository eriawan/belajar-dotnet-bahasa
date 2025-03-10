using BahasLinqJoinGroupJoinSelectMany.DataClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BahasLinqJoinGroupJoinSelectMany
{
    public class ComparerMahasiswa : IComparer<Mahasiswa>
    {
        public int Compare(Mahasiswa? x, Mahasiswa? y)
        {
            // urutan sorting: nama depan, nama belakang, kota, tanggal lahir
            if ((x != null) && (y != null))
            {
                if ((x.NamaDepan == y.NamaDepan) && (x.NamaBelakang == y.NamaBelakang) &&
                    (x.KotaId == y.KotaId) && (x.TglLahir.HasValue) && (y.TglLahir.HasValue) && 
                    (x.TglLahir == y.TglLahir))
                {
                    return 0;
                }
                if (x.NamaDepan != y.NamaDepan)
                {
                    return x.NamaDepan.CompareTo(y.NamaDepan);
                }
                if (x.NamaBelakang != y.NamaBelakang)
                {
                    return x.NamaBelakang.CompareTo(y.NamaBelakang);
                }
                if (x.KotaId != y.KotaId)
                {
                    return x.KotaId.CompareTo(y.KotaId);
                }
                if ((x.TglLahir.HasValue) && (y.TglLahir.HasValue) && (x.TglLahir != y.TglLahir))
                {
                    return x.TglLahir.Value.CompareTo(y.TglLahir.Value);
                }
                else
                {
                    var defaultComparer = Comparer<Mahasiswa>.Default;
                    return defaultComparer.Compare(x, y);
                }
            }
            else
            {
                var defaultComparer = Comparer<Mahasiswa>.Default;
                return defaultComparer.Compare(x, y);
            }
        }
    }
}
