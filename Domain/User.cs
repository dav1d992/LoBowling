namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public virtual ICollection<Frame> Frames { get; set; }
    }
}