namespace Domain;
public class BowlingGame
{
    public int Id { get; set; }
    public ICollection<Frame> Frames { get; set; }
}
