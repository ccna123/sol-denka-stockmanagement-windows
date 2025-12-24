using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Models
{
    public sealed class UnitOption
    {
        public int? Id { get; init; } // null = 未選択
        public string Code { get; init; } = "";
    }
}

