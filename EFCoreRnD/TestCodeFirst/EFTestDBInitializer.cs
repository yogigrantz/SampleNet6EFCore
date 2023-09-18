using Microsoft.EntityFrameworkCore;

namespace TestEFCore.Test;

public class EFTestDBInitializer
{
    private readonly ModelBuilder _mb;
    public EFTestDBInitializer(ModelBuilder mb)
    {
        _mb = mb;
    }

    public void Seed()
    {
        Client p1 = new Client()
        {
            ClientId = 1,
            Name = "James McCarthy",
            Phone = "323-555-1212",
            Email = "client@mailinator.com",
            CompanyName = "Microsoft Inc."
        };
        Candidate c1 = new Candidate()
        {
            Bio = "Software Developer",
            CandidateId = 1,
            BioHeader = "Principal Software Developer",
            CompanyName = "Microsoft",
            Name = "John Doe",
            SSN = "4422231231"
        };

        _mb?.Entity<Client>().HasData(p1);
        _mb?.Entity<Candidate>().HasData(c1);
    }
}
