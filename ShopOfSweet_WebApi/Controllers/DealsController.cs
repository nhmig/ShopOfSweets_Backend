using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopOfSweet_WebApi.Data;
using ShopOfSweet_WebApi.DTOs;
using ShopOfSweet_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOfSweet_WebApi.Controllers
{
    [Route("api/deals")]
    [ApiController]
    public class DealsController : Controller
    {
        private readonly IDealRepository _repository;
        private readonly IMapper _mapper;

        public DealsController(IDealRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        [HttpGet("{id}", Name = "GetDealById")]
        public ActionResult<DealReadDto> GetDealById(int id)
        {
            var dealItems = _repository.GetDealById(id);
            if (dealItems != null)
            {
                return Ok(_mapper.Map<DealReadDto>(dealItems));
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<DealReadDto>> GetAllDeals()
        {
            var dealItems = _repository.GetAllDeals();
            return Ok(_mapper.Map<IEnumerable<DealReadDto>>(dealItems));
        }


        [HttpGet("filtered")]
        public ActionResult<IEnumerable<DealReadDto>> GetDealByFilter([FromBody] DealQueryReadDto query)
        {

            var dealItems = _repository.GetDealByFilter(query.fromDt, query.toDt, query.transaction, query.product);

            if (dealItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<DealReadDto>>(dealItems));
            }
            return NotFound();
        }


        [HttpPost]
        public ActionResult<DealCreateDto> CreateDeal(DealCreateDto dealCreateDto)
        {
            var dealModel = _mapper.Map<Deals>(dealCreateDto);
            _repository.CreateDeal(dealModel);
            _repository.SaveChanges();

            var dealReadDto = _mapper.Map<DealReadDto>(dealModel);
            return CreatedAtRoute(nameof(GetDealById), new { Id = dealReadDto.Id }, dealReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDeal(int id)
        {
            var dealModelFromRepo = _repository.GetDealById(id);
            if (dealModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteDeal(dealModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
