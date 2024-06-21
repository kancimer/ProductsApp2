using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApp2.Data;
using ProductsApp2.Models.Domains;
using ProductsApp2.Models.DTOs;
using ProductsApp2.Models.Repositories;

namespace ProductsApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsAppDbContext dbContext;
        private readonly IProductsRepository productsRepository;
        private readonly IMapper mapper;

        public ProductsController(ProductsAppDbContext dbContext,
            IProductsRepository productsRepository
            , IMapper mapper)
        {
            this.dbContext = dbContext;
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAsc,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
        {

            var productsDomain = await productsRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAsc ?? true, pageNumber, pageSize);
            var productsDto = mapper.Map<List<ProductsDto>>(productsDomain);

            return Ok(productsDto);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            
            var productsDomain = await productsRepository.GetByIdAsync(id);
            if (productsDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ProductsDto>(productsDomain));

        }
        [HttpPost]
        //[Authorize(Roles = "Writer")]
        
        public async Task<IActionResult> Create([FromBody] AddProductDto addProductDto)
        {

            var productsDomainModel = mapper.Map<Products>(addProductDto);

            productsDomainModel = await productsRepository.CreateAsync(productsDomainModel);

            var productsDto = mapper.Map<ProductsDto>(productsDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = productsDto.Id }, productsDto);



        }

        [HttpPut]
        [Route("{id:Guid}")]
        
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductDto updateProductDto)
        {


            //map dto to domain model
            var productsDomainModel = mapper.Map<Products>(updateProductDto);
            //check if region exists
            productsDomainModel = await productsRepository.UpdateAsync(id, productsDomainModel);
            if (productsDomainModel == null)
            {
                return NotFound();
            }


            //convert domain model to dto

            return Ok(mapper.Map<ProductsDto>(productsDomainModel));//always pass dto to client, never domain model



        }
        //delete
        [HttpDelete]
        //[Authorize(Roles = "Writer")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var productsDomainModel = await productsRepository.DeleteAsync(id);
            if (productsDomainModel == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map<ProductsDto>(productsDomainModel));
        }


    }
}
