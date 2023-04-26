using KeyAsValueObjectDemo.SharedKernel;
using KeyAsValueObjectDemo.ValueObjects;

namespace KeyAsValueObjectDemo;

public class ContractVersion:BaseEntity
{
    public ContractVersionId Id { get; private set; }
    public ContractId ContractId { get; private set; }
    public string WorkingTitle { get; private set; }
    public DateTime DateCreated { get; private set; }

    public ContractVersion(ContractId contractId, string title)
    {
        Id = new ContractVersionId(Guid.NewGuid());
        WorkingTitle = title;
        ContractId = contractId;

    }
    private ContractVersion()
    {
        
    }
}

