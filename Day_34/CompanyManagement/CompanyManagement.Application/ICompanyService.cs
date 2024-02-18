namespace CompanyManagement.Application
{
    public interface ICompanyService
    {
        public IEnumerable<Company> GetCompanies();
        public Company GetCompanyById(int id);
        public bool Delete(int id);
        public bool AddCompany();
    }
}
