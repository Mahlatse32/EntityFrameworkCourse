using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.App_Start;
using Vidly.DataAccessLayer;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
    
        #region constructors

        public CustomersController()
        {
            _dbContext = new VidlyContext();
            _mapper = new Mapper(config);
        }

        #endregion

        #region properties

        private VidlyContext _dbContext;

        private IMapper _mapper;

        MapperConfiguration config = new MapperConfiguration(cfg => {
            cfg.AddProfile<MappingProfile>();
        });

        #endregion

        #region Methods

        //GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _dbContext.Customers
                .Include(c => c.MembershipType)
                .ProjectToList<CustomerDto>(config);
            return Ok(customerDtos);
        }

        //GET /api/customers/id
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id); ;

            if (customer == null)
                return NotFound();

            var customerDto = _mapper.Map<Customer, CustomerDto>(customer);

            return Ok(customerDto);
        }

        //Post /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _dbContext.Customers.SingleOrDefault(x => x.Id == id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _mapper.Map(customerDto, customerInDB);

            _dbContext.SaveChanges();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = _dbContext.Customers.SingleOrDefault(x => x.Id == id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dbContext.Customers.Remove(customerInDB);
            _dbContext.SaveChanges();
        }

        #endregion


    }
}
