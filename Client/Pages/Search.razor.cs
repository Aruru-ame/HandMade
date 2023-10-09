using System.Net.Http.Json;
using HandMade.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace HandMade.Client.Pages
{
    public partial class Search : ComponentBase
    {
        static readonly HttpClient httpClient = new HttpClient();

        public List<WorksSearch> WorksSearch =new List<WorksSearch>{};

        protected bool[] checklist { get; set; } = new bool[4];

        protected string subcategory = "";

        protected string maincategory = "";

        protected string mainmaterial = "";

        protected string submaterial = "";
        
        protected int? workcostFrom = null;

        protected int? workcostTo = null;

        protected int? worktimeFrom = null;

        protected int? worktimeTo = null;

        protected bool easyLevel= false;

        protected bool normalLevel= false;

        protected bool hardLevel= false;

        protected bool veryhardLevel= false;

        protected override async Task OnInitializedAsync()
        {
        }

        async void OnClick()
        {

            WorksSearch list = new WorksSearch
            {
                MainCategory = this.maincategory,
                SubCategory = this.subcategory,
                MainMaterial = this.mainmaterial,
                SubMaterial = this.submaterial,
                EasyLevel = this.easyLevel,
                NormalLevel = this.normalLevel,               
                HardLevel = this.hardLevel,
                VeryHardLevel = this.veryhardLevel,  
            };

            System.Console.WriteLine(maincategory);
            System.Console.WriteLine(this.subcategory);
                        System.Console.WriteLine(this.mainmaterial);
            var works = await Http.GetFromJsonAsync<List<WorksSearch>>
                         ($"api/WorksSearch?maincategory = {this.maincategory}" +
                          $"& subcategory = {this.subcategory} & mainmaterial = {this.mainmaterial}" +
                          $"& easyLevel = {this.easyLevel} & normalLevel = {this.normalLevel}" +
                          $"& hardLevel = {this.hardLevel} + veryhardLevel = {this.veryhardLevel}");
            this.WorksSearch = works;
            this.StateHasChanged();
        }
    }
}