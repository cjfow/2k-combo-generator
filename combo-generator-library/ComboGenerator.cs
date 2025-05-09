namespace combo_generator_library;

public class ComboGenerator
{
    private readonly List<Move> _allMoves;
    private readonly Random _rand = new();

    public ComboGenerator(List<Move> availableMoves)
    {
        // if availableMoves is not null, set _allMoves to it, if it is null, throw exception
        _allMoves = availableMoves ?? throw new ArgumentNullException($"No available moves: {nameof(availableMoves)}");
    }

    public List<Move> GenerateCombo(int comboLength, Difficulty maxDifficulty)
    {
        List<Move> currentCombo = [];

        Position currentPosition = Position.Standing;
        Direction currentDirection = Direction.TowardsHoop;

        for (int i = 0; i < comboLength; i++)
        {
            // filter da moves and find moves whos start positions match the current postion of the combo
            var validMoves = _allMoves.Where(m =>
                m.StartDirection == currentDirection &&
                m.StartPosition == currentPosition &&
                m.MoveDifficulty <= maxDifficulty
                ).ToList();

            if (validMoves.Count == 0)
            {
                Console.WriteLine("Error finding moves.");
                break;
            }

            Move chosenMove = validMoves[_rand.Next(validMoves.Count)];

            currentCombo.Add(chosenMove);

            currentPosition = chosenMove.EndPosition;
            currentDirection = chosenMove.EndDirection;
        }

        return currentCombo;
    }
}
