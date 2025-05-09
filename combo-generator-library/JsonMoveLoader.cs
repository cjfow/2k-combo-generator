using System.Text.Json;

namespace combo_generator_library;

public class JsonMoveLoader
{
    public async Task<List<Move>> LoadMovesAsync(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return [];
        }

        var jsonExtractor = await File.ReadAllTextAsync(filePath);

        return JsonSerializer.Deserialize<List<Move>>(jsonExtractor) ?? [];
    }
}
