using Abp.Configuration;

namespace WebPortal.Timing.Dto
{
    public class GetTimezoneComboboxItemsInput
    {
        public SettingScopes DefaultTimezoneScope;

        public string SelectedTimezoneId { get; set; }
    }
}
