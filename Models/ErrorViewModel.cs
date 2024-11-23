namespace ContractMonthlyClaimSystem.Models
{
    //here I handle errors
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    } 
}
