using BahasLinqJoinGroupJoinSelectMany.DataClass;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BahasLinqJoinGroupJoinSelectMany
{
    /// <summary>
    /// Implementasi IEqualityComparer untuk distinct kota yang ada pada collection mahasiswa.
    /// </summary>
    class EqualityComparerKotaInSimpleJoinMhsMstKota : IEqualityComparer<SimpleJoinMhsMstKota>
    {
        public bool Equals(SimpleJoinMhsMstKota? x, SimpleJoinMhsMstKota? y)
        {
            bool equalityResult = false;
            if ((x != null) && (y != null) && (x.KotaId == y.KotaId))
            {
                equalityResult = true;
            }
            return equalityResult;
        }

        public int GetHashCode([DisallowNull] SimpleJoinMhsMstKota obj)
        {
            return obj.Kota.GetHashCode();
        }
    }
}
