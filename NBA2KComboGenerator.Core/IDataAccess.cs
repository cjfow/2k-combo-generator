namespace NBA2KComboGenerator.Core;

public interface IDataAccess
{
    Task<List<Move>> LoadMovesAsync(string path);
}
