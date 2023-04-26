using KeyAsValueObjectDemo.SharedKernel;
using KeyAsValueObjectDemo.ValueObjects;

namespace KeyAsValueObjectDemo;

public class Contract:BaseEntity
{
    private Contract() { }
    public Contract(string workingTitle)
    {
        Id = new ContractId(Guid.NewGuid());
        AddVersion(new ContractVersion(Id, workingTitle));
        ContractNumber = $"{Id.ToString()}_{workingTitle}";
    }
    public ContractId Id { get; private set; }
    public string ContractNumber { get; private set; }
    public IEnumerable<ContractVersion> Versions => _versions.ToList();
    private readonly List<ContractVersion> _versions = new List<ContractVersion>();
    private void AddVersion(ContractVersion version)
    {
        _versions.Add(version);
    }
}

