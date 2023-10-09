using HandMade.Shared.Models;

namespace HandMade.Shared
{
    public class SharedService
    {
        public string Workname { get; set; } = string.Empty;

        public string workcategory { get; set; } = string.Empty;

        public string subworkcategory { get; set; } = string.Empty;

        public string mainmaterial { get; set; } = string.Empty;

        public string submaterial { get; set; } = string.Empty;

        public int? worktime { get; set; } = null;

        public int? workcost { get; set; } = null;

        public string Level { get; set; } = string.Empty;

        public string comment { get; set; } = string.Empty;
        
    }
}