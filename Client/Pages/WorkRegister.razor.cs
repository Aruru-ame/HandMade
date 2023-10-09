using HandMade.Shared.Models;
using Microsoft.AspNetCore.Components;
using HandMade.Shared;
using Microsoft.AspNetCore.Components.Forms;

namespace HandMade.Client.Pages
{
    public partial class WorkRegister : ComponentBase
    {
        [Inject]
        protected NavigationManager NavManager { get; set; }

        public WorksSearch Works = new WorksSearch();

        protected string workname = string.Empty;

        protected string workcategory = string.Empty;

        protected string subworkcategory = string.Empty;

        protected string mainmaterial = string.Empty;

        protected string submaterial = string.Empty;

        protected int? worktime = null;

        protected int? workcost = null;

        protected string Level = string.Empty;

        protected string comment = string.Empty;

        private IReadOnlyList<IBrowserFile>? selectedfile;
        private ElementReference fileInput;


        protected override async Task OnInitializedAsync()
        {
        }

        // 画像選択
        protected void HandleFileChange(InputFileChangeEventArgs e)
        {
             selectedfile = e.GetMultipleFiles();
        }

        // 作品登録
        // 画像保存処理は、まだできていない。
        async void WorkSubmit()
        {
           // 登録前に確認メッセージを表示する。

           SharedService.Workname =   this.workname ;
           SharedService.workcategory =   this.workcategory ;
           SharedService.subworkcategory =   this.subworkcategory ;
           SharedService.mainmaterial =   this.mainmaterial ;
           SharedService.submaterial =   this.submaterial ; 
           SharedService.worktime =   this.worktime ; 
           SharedService.workcost =   this.workcost ; 
           SharedService.Level =   this.Level ; 
           SharedService.comment =   this.comment ; 
                                 
           NavManager.NavigateTo($"/worksubmit", false);

        }
    }
}