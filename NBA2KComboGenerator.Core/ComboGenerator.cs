namespace NBA2KComboGenerator.Core;

public class ComboGenerator
{
    private readonly List<Move> _allMoves;
    private readonly Random _rand = new();

    private ComboGenerator(List<Move> availableMoves)
    {
        _allMoves = availableMoves;
    }

    public static ComboGenerator Create(List<Move>? availableMoves)
    {
        if (availableMoves is null || availableMoves.Count == 0)
        {
            throw new ArgumentNullException(nameof(availableMoves), "availableMoves is null or zero.");
        }

        return new ComboGenerator(availableMoves);
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
