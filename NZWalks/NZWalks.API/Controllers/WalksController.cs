using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await _walkRepository.GetAllAsync();
            return Ok(_mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDto>(walkDomainModel));
        }


        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map Dto to Domain Model
            var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDto);
            await _walkRepository.CreateAsync(walkDomainModel);
            return CreatedAtAction(nameof(GetWalkById), new { id = walkDomainModel.Id }, _mapper.Map<WalkDto>(walkDomainModel));

        }

        [HttpPut("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDomainModel = _mapper.Map<Walk>(updateWalkRequestDto);
            walkDomainModel = await _walkRepository.UpdateAsync(id, walkDomainModel);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepository.DeleteAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDto>(walkDomainModel));
        }
    }
}
