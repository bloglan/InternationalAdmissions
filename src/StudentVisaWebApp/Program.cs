using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentVisaWebApp;
using StudentVisaWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

app.Run();

public partial class Program { }