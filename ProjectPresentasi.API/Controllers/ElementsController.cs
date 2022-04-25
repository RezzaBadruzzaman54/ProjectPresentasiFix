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
    public class ElementsController : ControllerBase
    {
        private readonly IElement _elements;
        private readonly IMapper _mapper;
        public ElementsController(IElement elements, IMapper mapper)
        {
            _elements = elements;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ElementReadDto>> Get()
        {
            //AutoMapper
            var results = await _elements.GetAll();
            var output = _mapper.Map<IEnumerable<ElementReadDto>>(results);
            return output;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ElementReadDto>> GetById(int id)
        {
            var result = await _elements.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<ElementReadDto>(result));

        }

        [HttpPost]
        public async Task<ActionResult> Post(ElementCreateDto elementCreateDto)
        {
            try
            {
                var newElement = _mapper.Map<Element>(elementCreateDto);
                var result = await _elements.Insert(newElement);
                var elementDto = _mapper.Map<ElementReadDto>(result);
                return CreatedAtAction("GetById", new { id = result.Id }, elementDto);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ElementCreateDto ElementCreateDto)
        {

            try
            {
                var updateElement = _mapper.Map<Element>(ElementCreateDto);
                var result = await _elements.Update(id, updateElement);
                var elementDto = _mapper.Map<ElementReadDto>(result);
                return Ok(elementDto);
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
                await _elements.Delete(id);
                return Ok($"Record {id} Deleted");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
