using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandMade.Shared.Models
{
    public class WorksSearch
    {
        [Key]
        public Guid WorksId { get; set; }

        public string? WorksName { get; set; } = null;

        public string? MainCategory { get; set; } = null;

        public string? SubCategory { get; set; } = null;

        public string? MainMaterial { get; set; } = null;

        public string? SubMaterial { get; set; } = null;

        public bool? EasyLevel { get; set; } = false;

        public bool? NormalLevel { get; set; } = false;

        public bool? HardLevel { get; set; } = false;

        public bool? VeryHardLevel { get; set; } = false;

        public int? WorkTime { get; set; } = null;

        public int? WorkCost { get; set; } = null;
    }
}