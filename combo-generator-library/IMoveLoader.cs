namespace combo_generator_library;

public interface IMoveLoader
{
    Task<List<Move>> LoadMovesAsync(string path);
}
