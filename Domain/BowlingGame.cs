namespace Domain;
public class BowlingGame
{
    public Guid Id { get; set; }
    public string PlayerName { get; set; }
    public int Score { get; set; }
    public ICollection<Frame> Frames { get; set; }
}
