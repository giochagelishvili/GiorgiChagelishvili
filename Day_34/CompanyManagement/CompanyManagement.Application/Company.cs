namespace CompanyManagement.Application
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }

        public Company(int companyID, string companyName)
        {
            CompanyID = companyID;
            CompanyName = companyName;
        }
    }
}
