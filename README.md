# KeyAsValueObject

This solution uses guard keys for the two entities (contract has contractid and contractversion has contractversionid).

The KeyAsValueObjectDemo project targetst EF COre 6 (6.0.13 explicitly) and .NET 6.

The DbContext includes the valueconversion mapping whose support was added for EF Core 7.

**dotnet ef dbcontext info** fails with a complaint that the dbcontext can't be built.

However, the integration tests that instantiate the dbcontext, store and retrieve data all work (not only not throwing an exception but passing).

This doesn't make sense that it should work in EF Core 6.


