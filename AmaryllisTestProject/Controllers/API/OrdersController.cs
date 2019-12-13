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
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrders()
        {
            var listOrdersDTO = await _orderService.GetAllAsync();
            var listOrdersView = _mapper.Map<IEnumerable<OrderDTO>, IEnumerable<OrderModel>>(listOrdersDTO).ToList();
            return listOrdersView;
        }
       

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> GetOrder(int id)
        {
            var orderDTO = await _orderService.GetByIdAsync(id);
           var orderView = _mapper.Map<OrderDTO, OrderModel>(orderDTO);
            if (orderView == null)
            {
                return NotFound();
            }

            return orderView;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderModel order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var orderDTO = _mapper.Map<OrderModel, OrderDTO>(order);                  
                    await _orderService.UpdateAsync(orderDTO);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

            }
            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderModel order)
        {
           var orderDTO = _mapper.Map<OrderModel, OrderDTO>(order);
            await _orderService.CreateAsync(orderDTO);

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderModel>> DeleteOrder(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

           await _orderService.DeleteAsync(id);
            var orderView =_mapper.Map<OrderDTO, OrderModel>(order);
            return orderView;
        }


        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetFilteredOrders(DateTime? startDate = null, DateTime? finishedDate = null, string userFirstName = null, string userLastName = null)
        {
            var orderDTO = await _orderService.GetAllAsync(startDate, finishedDate, userFirstName, userLastName);
            var orderView = _mapper.Map<IEnumerable<OrderDTO>, IEnumerable<OrderModel>>(orderDTO).ToList();
            if (orderView == null)
            {
                return NotFound();
            }

            return orderView;
        }

    }
}
