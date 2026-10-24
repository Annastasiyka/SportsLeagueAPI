using Microsoft.EntityFrameworkCore;
using SportsLeagueAPI.Data;
using SportsLeagueAPI.Repositories; // Додано для репозиторіїв

var builder = WebApplication.CreateBuilder(args);

// 1. Додаємо базові сервіси контролерів
builder.Services.AddControllers();

// 2. Налаштовуємо Swagger для візуального інтерфейсу тестування API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Підключаємо базу даних (шлях братиметься з appsettings.json)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 4. Реєструємо наші репозиторії
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

// БУДУЄМО ДОДАТОК (Після цього додавати builder.Services не можна!)
var app = builder.Build();

// 5. Налаштовуємо HTTP конвеєр
if (app.Environment.IsDevelopment())
{
    // Вмикаємо візуальну сторінку Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();