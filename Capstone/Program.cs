using Data.IRepositories;
using DataAccess;
using DomainServices.IServices;
using DomainServices.Services;
using ErrorHandling;
using Microsoft.EntityFrameworkCore;
using Repositories.IRepositories;
using Repositories.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// SQL Server Connection
builder.Services.AddDbContext<CatDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("CapstoneConnection")));
builder.Services.AddDbContext<CatDiseaseHistoryDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("CapstoneConnection")));
builder.Services.AddDbContext<CatTestingDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("CapstoneConnection")));
builder.Services.AddDbContext<CatVaccinationDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("CapstoneConnection")));
builder.Services.AddDbContext<DogDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("CapstoneConnection")));
builder.Services.AddDbContext<DogDiseaseHistoryDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("CapstoneConnection")));
builder.Services.AddDbContext<DogTestingDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("CapstoneConnection")));
builder.Services.AddDbContext<DogVaccinationDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("CapstoneConnection")));
builder.Services.AddDbContext<ShelterDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("CapstoneConnection")));
builder.Services.AddDbContext<UserDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("CapstoneConnection")));
builder.Services.AddDbContext<DonationDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("CapstoneConnection")));
builder.Services.AddDbContext<FollowDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("CapstoneConnection")));

builder.Services.AddControllers();

// Defining Repositories
builder.Services.AddScoped<ICatRepository, CatRepository>();
builder.Services.AddScoped<ICatDiseaseHistoryRepository, CatDiseaseHistoryRepository>();
builder.Services.AddScoped<ICatTestingRepository, CatTestingRepository>();
builder.Services.AddScoped<ICatVaccinationRepository, CatVaccinationRepository>();
builder.Services.AddScoped<IDogRepository, DogRepository>();
builder.Services.AddScoped<IDogDiseaseHistoryRepository, DogDiseaseHistoryRepository>();
builder.Services.AddScoped<IDogTestingRepository, DogTestingRepository>();
builder.Services.AddScoped<IDogVaccinationRepository, DogVaccinationRepository>();
builder.Services.AddScoped<IShelterRepository, ShelterRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<IFollowRepository, FollowRepository>();



// Defining Domain Services
builder.Services.AddScoped<ICatServices, CatServices>();
builder.Services.AddScoped<ICatDiseaseHistoryServices, CatDiseaseHistoryServices>();
builder.Services.AddScoped<ICatTestingServices, CatTestingServices>();
builder.Services.AddScoped<ICatVaccinationServices, CatVaccinationServices>();
builder.Services.AddScoped<IDogServices, DogServices>();
builder.Services.AddScoped<IDogDiseaseHistoryServices, DogDiseaseHistoryServices>();
builder.Services.AddScoped<IDogTestingServices, DogTestingServices>();
builder.Services.AddScoped<IDogVaccinationServices, DogVaccinationServices>();
builder.Services.AddScoped<IShelterServices, ShelterServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IDonationServices, DonationServices>();
builder.Services.AddScoped<IFollowServices, FollowServices>();


builder.Services.AddTransient<ErrorHandlingMiddleware>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
