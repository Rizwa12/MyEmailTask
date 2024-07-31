using EmailSendTask.Model;
using EmailSendTask.Repository.Contract;
using EmailSendTask.Repository.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("EmailSetting"));

var isFake = builder.Configuration.GetSection("EmailSetting").Get<EmailSetting>().isFake.Value;
if (isFake)
{
    builder.Services.AddTransient<IEmailService,ActualEmailService>();
}
else
{
    builder.Services.AddTransient<IEmailService, FakeEmailService>();
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
