namespace ProjectPresentasi.API.Dtos
{
    public class SwordWithElementCreateDto
    {
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public double Weight { get; set; }
        public List<ElementCreateDto> Elements { get; set; } = new List<ElementCreateDto>();
    }
}
