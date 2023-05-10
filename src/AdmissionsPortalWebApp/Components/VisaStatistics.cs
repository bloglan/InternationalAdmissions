using Microsoft.AspNetCore.Mvc;

namespace AdmissionsPortalWebApp.Components;

public class VisaStatistics : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return this.View();
    }
}
