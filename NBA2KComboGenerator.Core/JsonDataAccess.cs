using System.Text.Json;

namespace NBA2KComboGenerator.Core;

public class JsonDataAccess
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
