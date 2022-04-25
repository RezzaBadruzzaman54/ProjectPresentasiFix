using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPresentasi.API.Dtos;
using ProjectPresentasi.Data.Interfaces;
using ProjectPresentasi.Domain;

namespace ProjectPresentasi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        private readonly ISamurai _samurais;
        private readonly IMapper _mapper;
        //private readonly ISword _sword;

        public SamuraisController(ISamurai samurais, IMapper mapper, ISword sword)
        {
            _samurais = samurais;
            _mapper = mapper;
            //_sword = sword;
        }

        [HttpGet]
        public async Task<IEnumerable<SamuraiReadDto>> Get()
        {
            //AutoMapper
            var results = await _samurais.GetAll();
            var output = _mapper.Map<IEnumerable<SamuraiReadDto>>(results);
            return output;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SamuraiReadDto>> GetById(int id)
        {
            var result = await _samurais.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<SamuraiReadDto>(result));

        }

        [HttpPost]
        public async Task<ActionResult> Post(SamuraiCreateDto samuraiCreateDto)
        {
            try
            {
                var newSamurai = _mapper.Map<Samurai>(samuraiCreateDto);
                var result = await _samurais.Insert(newSamurai);
                var samuraiDto = _mapper.Map<SamuraiReadDto>(result);
                return CreatedAtAction("GetById", new { id = result.Id }, samuraiDto);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, SamuraiCreateDto samuraiCreateDto)
        {

            try
            {
                var updateSamurai = _mapper.Map<Samurai>(samuraiCreateDto);
                var result = await _samurais.Update(id, updateSamurai);
                var samuraiDto = _mapper.Map<SamuraiReadDto>(result);
                return Ok(samuraiDto);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _samurais.Delete(id);
                return Ok($"Record {id} Deleted");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SamuraiWithSword")]
        public async Task<ActionResult> CreateSamuraiWithSwords(SamuraiWithSwordCreateDto samuraiWithSwordCreateDto)
        {
            try
            {
                var newSamurai = _mapper.Map<Samurai>(samuraiWithSwordCreateDto);
                var result = await _samurais.Insert(newSamurai);

                //int idsamurai = result.Id;
                //var newSword = _mapper.Map<Sword>(samuraiWithSwordCreateDto.Swords);
                //List<Sword> newpedang = new();
                //foreach(var pedang in samuraiWithSwordCreateDto.Swords)
                //{
                //    Sword pdg = new();
                //    pdg.SamuraiId=idsamurai;
                //    pdg.Name = pedang.Name;
                //    pdg.ProductionYear = pedang.ProductionYear;
                //    pdg.Weight = pedang.Weight;

                //    var hasil=_sword.Insert(pdg);
                //    //newpedang.Add(pdg);

                //}

                var samuraiDto = _mapper.Map<SamuraiReadDto>(result);
                return CreatedAtAction("GetById", new { id = result.Id }, samuraiDto);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Sword/{id}")]
        public async Task<ActionResult<SamuraiWithSwordReadDto>> GetSamuraiWithSwordById(int id)
        {
            var result = await _samurais.GetSamuraiWithSwordById(id);
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<SamuraiWithSwordReadDto>(result));

        }

        [HttpGet("SwordAndElement/{id}")]
        public async Task<ActionResult<SamuraiWithSwordAndElementReadDto>> GetSamuraiWithSwordAndElementById(int id)
        {
            var result = await _samurais.GetSamuraiWithSwordAndElementById(id);
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<SamuraiWithSwordAndElementReadDto>(result));

        }
    }
}
