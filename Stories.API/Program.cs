using Microsoft.EntityFrameworkCore;
using Stories.Infrastructure.Data;
using Stories.Services.Services.Account;
using Stories.Services.Services.Story;
using Stories.Services.Services.Votes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IStoryService, StoryService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IVoteService, VoteService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
