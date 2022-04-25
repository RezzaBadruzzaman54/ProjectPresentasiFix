namespace ProjectPresentasi.API.Dtos
{
    public class SamuraiWithSwordCreateDto
    {
        public string Name { get; set; }
        public List<SamuraiSwordCreateDto> Swords { get; set; } = new List<SamuraiSwordCreateDto>();
    }
}
