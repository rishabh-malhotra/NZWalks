using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await _regionRepository.GetAllAsync();

            return Ok(_mapper.Map<List<RegionDto>>(regionsDomain));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            var regionDomain = await _regionRepository.GetByIdAsync(id);

            if(regionDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(regionDomain));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map or Convert Dto to Domain Model
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);

            // Use Domain Model to create Region
            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);

            // Map Domain Model back to DTO
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDomainModel.Id }, regionDto);

        }

        [HttpPut("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDto);

            // Check if region exists
            regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(regionDomainModel));

        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var regionDomainModel = await _regionRepository.DeleteAsync(id);
            if(regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}
