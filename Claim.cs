namespace ContractMonthlyClaimSystem
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public int LecturerId { get; set; }
        public double HoursWorked { get; set; }
        public double HourlyRate { get; set; }
        public required string SupportingDocuments { get; set; }
        public required string Status { get; set; }  // Pending, Approved, Rejected
        public DateTime SubmittedDate { get; set; }
        public double TotalAmount => HoursWorked * HourlyRate;

        public required Lecturer Lecturer { get; set; }
    }
}