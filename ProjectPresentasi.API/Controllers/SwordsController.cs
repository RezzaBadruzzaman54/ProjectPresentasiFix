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
    public class SwordsController : ControllerBase
    {
        private readonly ISword _swords;
        private readonly IMapper _mapper;
        public SwordsController(ISword swords, IMapper mapper)
        {
            _swords = swords;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SwordReadDto>> Get()
        {
            //AutoMapper
            var results = await _swords.GetAll();
            var output = _mapper.Map<IEnumerable<SwordReadDto>>(results);
            return output;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SwordReadDto>> GetById(int id)
        {
            var result = await _swords.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<SwordReadDto>(result));

        }

        [HttpPost]
        public async Task<ActionResult> Post(SwordCreateDto swordCreateDto)
        {
            try
            {
                var newSword = _mapper.Map<Sword>(swordCreateDto);
                var result = await _swords.Insert(newSword);
                var swordDto = _mapper.Map<SwordReadDto>(result);
                return CreatedAtAction("GetById", new { id = result.Id }, swordDto);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SwordWithElement")]
        public async Task<ActionResult> PostSwordWithElement(SwordWithElementCreateDto swordWithElemenCreateDto)
        {
            try
            {
                var newSword = _mapper.Map<Sword>(swordWithElemenCreateDto);
                var result = await _swords.Insert(newSword);
                var swordDto = _mapper.Map<SwordReadDto>(result);
                return CreatedAtAction("GetSword", new { result.Id }, swordDto);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, SwordCreateDto swordCreateDto)
        {

            try
            {
                var updateSword = _mapper.Map<Sword>(swordCreateDto);
                var result = await _swords.Update(id, updateSword);
                var swordDto = _mapper.Map<SwordReadDto>(result);
                return Ok(swordDto);
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
                await _swords.Delete(id);
                return Ok($"Record {id} Deleted");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
