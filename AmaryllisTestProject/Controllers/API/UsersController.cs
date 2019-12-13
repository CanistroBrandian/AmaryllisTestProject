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
using AutoMapper;
using AmaryllisTestProject.BLL.Interfaces;
using AmaryllisTestProject.BLL.DTO;

namespace AmaryllisTestProject.WEB.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UsersController(
            IMapper mapper,
            IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<UserDTO>, IEnumerable<UserModel>>(users));
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDTO, UserModel>(user));
        }

        // PUT: api/Users/5
        [HttpPut]
        public async Task<IActionResult> PutUser(UserModel model)
        {
            await _userService.UpdateAsync(_mapper.Map<UserModel, UserDTO>(model));
            return Ok();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserModel model)
        {
            var newUser = await _userService.CreateAsync(_mapper.Map<UserModel, UserDTO>(model));
            return CreatedAtAction("GetUser", new { id = newUser.Id }, newUser);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
