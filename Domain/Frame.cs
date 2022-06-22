using System;

namespace Domain;
public class Frame
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public int BowlingGameId { get; set; }
    public virtual BowlingGame BowlingGame { get; set; }
    public int FrameNumber { get; set; }
    public int FirstRoll { get; set; }
    public int SecondRoll { get; set; }
    public int ThirdRoll { get; set; }
}
