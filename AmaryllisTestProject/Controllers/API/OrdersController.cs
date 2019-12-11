using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AmaryllisTestProject.DAL.EF;
using AmaryllisTestProject.DAL.Entities;
using AmaryllisTestProject.WEB.Models;
using AmaryllisTestProject.BLL.DTO;
using AmaryllisTestProject.BLL.Interfaces;
using AutoMapper;

namespace AmaryllisTestProject.WEB.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly EFContext _context;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(EFContext context, IOrderService orderService, IMapper mapper)
        {
            _context = context;
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
        [Route("api/[controller]/filter")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetOrdersFilter(OrderViewModel item)
        {
            var orderDTO = _mapper.Map<OrderViewModel, OrderDTO>(item);
            var filterList = await _orderService.Filter(orderDTO);
            var view = _mapper.Map<IEnumerable<OrderDTO>, IEnumerable<OrderViewModel>>(filterList).ToList();
            return view;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
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
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
