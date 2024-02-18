using CompanyManagement.Application.Exceptions;

namespace CompanyManagement.Application
{
    public class CompanyService : ICompanyService
    {
        private List<Company> Companies { get; set; }

        public CompanyService()
        {
            Companies = new()
            {
                new Company(1, "TBC"),
                new Company(2, "BOG"),
                new Company(3, "KFC"),
                new Company(4, "UGT"),
                new Company(5, "NBC"),
            };
        }

        public IEnumerable<Company> GetCompanies() => Companies;

        public Company GetCompanyById(int id)
        {
            var company = Companies.SingleOrDefault(company => company.CompanyID == id);

            return company == null ? throw new CompanyNotFoundException() : company;
        }

        public bool Delete(int id) => Companies.Remove(GetCompanyById(id));

        public bool AddCompany() => throw new UnauthorizedUserException();
    }
}
