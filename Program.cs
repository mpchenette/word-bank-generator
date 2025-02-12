var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
app.UseStaticFiles(); // Pfdfc
app.UseDefaultFiles(); // P012c

var words = new[]
{
    "apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "honeydew", "kiwi", "lemon"
};

app.MapGet("/wordbank", (string? startsWith, int? length, bool? isPlural, string? contains, string? category, bool? excludeProperNouns, string? origin, int? numberOfWords) =>
{
    var filteredWords = words.AsEnumerable();

    if (!string.IsNullOrEmpty(startsWith))
    {
        filteredWords = filteredWords.Where(word => word.StartsWith(startsWith, StringComparison.OrdinalIgnoreCase));
    }

    if (length.HasValue)
    {
        filteredWords = filteredWords.Where(word => word.Length == length.Value);
    }

    if (isPlural.HasValue)
    {
        filteredWords = filteredWords.Where(word => isPlural.Value ? word.EndsWith("s") : !word.EndsWith("s"));
    }

    if (!string.IsNullOrEmpty(contains))
    {
        filteredWords = filteredWords.Where(word => word.Contains(contains, StringComparison.OrdinalIgnoreCase));
    }

    if (!string.IsNullOrEmpty(category))
    {
        // Implement category filtering logic here
    }

    if (excludeProperNouns.HasValue && excludeProperNouns.Value)
    {
        // Implement proper noun exclusion logic here
    }

    if (!string.IsNullOrEmpty(origin))
    {
        // Implement origin filtering logic here
    }

    if (numberOfWords.HasValue)
    {
        filteredWords = filteredWords.Take(numberOfWords.Value);
    }

    return filteredWords.ToArray();
})
.WithName("GetWordBank");

app.Run();
