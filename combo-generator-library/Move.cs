namespace combo_generator_library;

public enum Direction { TowardsHoop, AwayFromHoop, SidewaysBallToBasket, SidewaysBallAway }

public enum Position { Standing, Walking, Running }

public enum Difficulty { Easy, Medium, Hard, Enoc }

public enum Hand { Right, Left }


public class Move
{
    public string? Name { get; set; }

    public Direction StartDirection { get; set; }
    public Direction EndDirection { get; set; }
    public Position StartPosition { get; set; }
    public Position EndPosition { get; set; }
    public Difficulty MoveDifficulty { get; set; }

    public float MoveDuration { get; set; }
    public byte MoveWeight { get; set; }
}
