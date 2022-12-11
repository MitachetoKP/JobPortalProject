namespace JobPortalProject.Core.Models.UserModels
{
    public class EmployeeListModel
    {
        public string OfferTitle { get; init; }

        public IEnumerable<EmployeeViewModel> Employees { get; set; } = new List<EmployeeViewModel>();
    }
}
