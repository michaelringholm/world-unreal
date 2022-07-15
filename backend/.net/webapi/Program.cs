using System.Net;
using com.opusmagus.wu.simple;

var builder = WebApplication.CreateBuilder(args);

/*builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
    options.HttpsPort = 5001;
});*/
/*if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddHttpsRedirection(options =>
    {
        options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
        options.HttpsPort = 5001;
    });
}*/
if (builder.Environment.IsDevelopment()) builder.WebHost.UseUrls("https://localhost:5001/");
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var game=new Game();
game.StartGame();
builder.Services.AddSingleton<Game>(game);
var app = builder.Build();
if (app.Environment.IsDevelopment()) app.UseExceptionHandler("/error-dev");
else app.UseExceptionHandler("/error");

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
