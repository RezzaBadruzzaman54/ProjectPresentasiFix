namespace ProjectPresentasi.API.Dtos
{
    public class SamuraiWithSwordAndElementReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SwordWithElementReadDto> Swords { get; set; } = new List<SwordWithElementReadDto>();
        public List<ElementReadDto> Elements { get; set; } = new List<ElementReadDto>();
    }
}
