using AmaryllisTestProject.BLL.DTO;
using AmaryllisTestProject.BLL.Interfaces;
using AmaryllisTestProject.DAL.Entities;
using AmaryllisTestProject.DAL.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmaryllisTestProject.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(OrderDTO item)
        {
            if (item != null)
            {
                var order = _mapper.Map<OrderDTO, Order>(item);
                await _orderRepository.CreateAsync(order);
            }
            else throw new Exception("Данные не заполнены");
        }

        public async Task DeleteAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            var listOrders = await _orderRepository.GetAllAsync();
            var listOrderDTOs = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(listOrders);
            return listOrderDTOs;
        }

        public async Task<OrderDTO> GetByIdAsync(int id)
        {
            var order = await _orderRepository.FindByIdAsync(id);
            var orderDTO = _mapper.Map<Order, OrderDTO>(order);
            return orderDTO;
        }

        public async Task Update(OrderDTO item)
        {
            var sourceOrder = await _orderRepository.FindByIdAsync(item.Id);

            if (sourceOrder != null)
            {
                sourceOrder.CarId = item.CarId;
                sourceOrder.UserId = item.UserId;
                sourceOrder.Comment = item.Comment;
                sourceOrder.StartContractDateTime = item.StartContractDateTime;
                sourceOrder.FinishedContractDateTime = item.FinishedContractDateTime;

                _orderRepository.Update(sourceOrder);
            }
            else throw new Exception("Такой записи нет");
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync(DateTime? startDate = null, DateTime? finishedDate = null, string userFirstName = null, string userLastName = null)
        {
            var list = await _orderRepository.GetAllAsync(p =>
            (!startDate.HasValue || p.StartContractDateTime == startDate)
            && (!finishedDate.HasValue || p.FinishedContractDateTime == finishedDate)
            && (userFirstName == null || p.User.FirstName.Contains(userFirstName))
            && (userLastName == null || p.User.LastName.Contains(userLastName)));
            var map = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(list);
            return map;
        }
    }
}
