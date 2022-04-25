namespace ProjectPresentasi.API.Dtos
{
    public class SamuraiWithSwordReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SwordReadDto> Swords { get; set; } = new List<SwordReadDto>();
    }
}
