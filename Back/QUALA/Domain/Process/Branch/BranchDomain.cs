
namespace Domain.Process.Branch
{
    public sealed class BranchDomain
    {

        public BranchDomain(Guid id, int code, string description, string address, string identify, DateTime? created, Guid? currencyId, bool? active, string? currencyCode = "") {
            Id = id;
            Code = code;
            Description = description;
            Address = address;
            Identify = identify;
            Created = created;
            CurrencyId = currencyId;
            Active = active;
            CurrencyCode = currencyCode;
        }

        public Guid Id { get; set; }

        public int Code { get; set; }

        public string Description { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Identify { get; set; } = null!;

        public DateTime? Created { get; set; }

        public Guid? CurrencyId { get; set; }

        public bool? Active { get; set; }

        public string? CurrencyCode { get; set; } = null!;
    }
}
