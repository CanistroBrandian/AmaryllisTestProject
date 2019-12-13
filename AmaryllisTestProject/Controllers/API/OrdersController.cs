using AmaryllisTestProject.BLL.DTO;
using AmaryllisTestProject.BLL.Interfaces;
using AmaryllisTestProject.DAL.Entities;
using AmaryllisTestProject.WEB.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmaryllisTestProject.WEB.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetOrders()
        {
            var listOrdersDTO = await _orderService.GetAllAsync();
            var listOrdersView = _mapper.Map<IEnumerable<OrderDTO>, IEnumerable<OrderViewModel>>(listOrdersDTO).ToList();
            return listOrdersView;
        }
       

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderViewModel>> GetOrder(int id)
        {
            var orderDTO = await _orderService.GetByIdAsync(id);
           var orderView = _mapper.Map<OrderDTO, OrderViewModel>(orderDTO);
            if (orderView == null)
            {
                return NotFound();
            }

            return orderView;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderViewModel order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var orderDTO = _mapper.Map<OrderViewModel, OrderDTO>(order);                  
                    await _orderService.Update(orderDTO);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

            }
            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderViewModel order)
        {
           var orderDTO = _mapper.Map<OrderViewModel, OrderDTO>(order);
            await _orderService.CreateAsync(orderDTO);

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderViewModel>> DeleteOrder(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

           await _orderService.DeleteAsync(id);
            var orderView =_mapper.Map<OrderDTO, OrderViewModel>(order);
            return orderView;
        }


/*        [HttpGet("filter/{startContractDateTime}")]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetOrderByFilterStartContract(string startContractDateTime)
        {
            var orderDTO = await _orderService.FilterbyStartData(startContractDateTime);
            var orderView = _mapper.Map<IEnumerable<OrderDTO>, IEnumerable<OrderViewModel>>(orderDTO).ToList();
            if (orderView == null)
            {
                return NotFound();
            }

            return orderView;
        }*/

    }
}
