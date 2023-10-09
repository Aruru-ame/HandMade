using HandMade.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Net.Http.Json;

namespace HandMade.Client.Pages
{
    public partial class WorkSubmit : ComponentBase
    {
        static readonly HttpClient httpClient = new HttpClient();

        public WorksSearch Works = new WorksSearch();

        protected override async Task OnInitializedAsync()
        {
        }

        // 作品登録ボタン押下
        async void Submit()
        {
            Works = new WorksSearch
            {
                WorksId = Guid.NewGuid(),
                WorksName = this.SharedService.Workname,
                MainCategory = this.SharedService.workcategory,
                SubCategory = this.SharedService.subworkcategory,
                MainMaterial = this.SharedService.mainmaterial,
                SubMaterial = this.SharedService.subworkcategory,
                WorkTime = this.SharedService.worktime,
                WorkCost = this.SharedService.workcost,
            };

            var works = await Http.PostAsJsonAsync($"api/WorksSubmit", Works);

        }
    }
}