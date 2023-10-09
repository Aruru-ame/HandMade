using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HandMade.Server.Data;
using HandMade.Shared.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandMade.Server.Controllers
{
    [Route("api/WorksSearch")]
    [ApiController]
    public class WorksSearchController : ControllerBase
    {
        private readonly AppDbContext worklist;

        public WorksSearchController(AppDbContext worklist)
        {
            this.worklist = worklist;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorksSearch>>> Get(
                [FromQuery] string? maincategory,
                [FromQuery] string? subcategory,
                [FromQuery] string? mainmaterial,
                [FromQuery] string? submaterial,
                [FromQuery] int? worktime,
                [FromQuery] int? workcost,
                [FromQuery] bool? easyLevel,
                [FromQuery] bool? normalLevel,
                [FromQuery] bool? hardLevel,
                [FromQuery] bool? veryhardLevel)
        {
            var result = Searchworks(
                maincategory
                , subcategory
                , mainmaterial
                , submaterial
                , worktime
                , workcost
                , easyLevel
                , normalLevel
                , hardLevel
                , veryhardLevel
                );
            return result.ToList();
        }

        private IEnumerable<WorksSearch> Searchworks(
            string? maincategory
            , string? subcategory
            , string? mainmaterial
            , string? submaterial
            , int? worktime
            , int? workcost
            , bool? easyLevel
            , bool? normalLevel
            , bool? hardLevel
            , bool? veryhardLevel)
        {
            // 全件取得
            var query = this.worklist.WorksSearch;

            if (!String.IsNullOrEmpty(maincategory))
            {
                query.Where(e => e.MainCategory == maincategory);
            }

            if (!String.IsNullOrEmpty(subcategory))
            {
                query.Where(e => e.SubCategory == subcategory);
            }

            if (!String.IsNullOrEmpty(mainmaterial))
            {
                query.Where(e => e.MainMaterial == mainmaterial);
            }

            if (!String.IsNullOrEmpty(submaterial))
            {
                query.Where(e => e.SubMaterial == submaterial);
            }

            if (!String.IsNullOrEmpty(worktime.ToString()))
            {
                query.Where(e => e.WorkTime == worktime);
            }

            if (!String.IsNullOrEmpty(workcost.ToString()))
            {
                query.Where(e => e.WorkCost == workcost);
            }

            if (easyLevel == true)
            {
                query.Where(e => e.EasyLevel == easyLevel);
            }

            if (normalLevel == true)
            {
                query.Where(e => e.NormalLevel == normalLevel);
            }

            if (hardLevel == true)
            {
                query.Where(e => e.HardLevel == hardLevel);
            }

            if (veryhardLevel == true)
            {
                query.Where(e => e.VeryHardLevel == veryhardLevel);
            }

            return query.ToList();
        }


    }
}