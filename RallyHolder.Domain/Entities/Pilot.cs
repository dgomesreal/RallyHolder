namespace RallyHolder.Domain.Entities
{
    public class Pilot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; } //Not recommended for big projects

        public bool Validate()
        {
            if (string.IsNullOrEmpty(Name))
                return false;

            return true;
        }
    }
}
