namespace ProjectPresentasi.API.Dtos
{
    public class SwordWithElementReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public double Weight { get; set; }
        public List<ElementReadDto> Elements { get; set; } = new List<ElementReadDto>();
    }
}
