using System.Security.Claims;

namespace ContractMonthlyClaimSystem
{
    public class Lecturer
    {
        public required int LecturerId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required ICollection<Claim> Claims { get; set; }
    }
}
