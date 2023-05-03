using Microsoft.AspNetCore.Mvc;

namespace StudentVisaWebApp.Components;

public class VisaStatistics : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return this.View();
    }
}
