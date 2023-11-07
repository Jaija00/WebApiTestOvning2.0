namespace WebApiTestÖvning2._0.Model
{
    public class Felanmälan
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
