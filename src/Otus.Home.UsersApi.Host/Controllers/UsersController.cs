using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Otus.Home.UsersApi.Core.Abstractions.Repositories;
using Otus.Home.UsersApi.Core.Domain.Administration;
using Otus.Home.UsersApi.Host.Models;

namespace Otus.Home.UsersApi.Host.Controllers
{
    /// <summary>
    /// Пользователи
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController
        : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<UserShortResponse>>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            var response = _mapper.Map<IEnumerable<User>, IList<UserShortResponse>>(users);

            return Ok(response);
        }
        
        /// <summary>
        /// Получение пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            var response = _mapper.Map<User, UserResponse>(user);

            return Ok(response);
        }
        
        /// <summary>
        /// создание нового пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserResponse>> CreateUserAsync(CreateOrEditUserRequest request)
        {
            var newId = Guid.NewGuid();

            var newUser = new User()
            {
                Id = newId,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            await _userRepository.AddAsync(newUser);

            return Ok();
        }
        
        /// <summary>
        /// Обновить данные пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditUserAsync(Guid id, CreateOrEditUserRequest request)
        {
            var user = await _userRepository.GetByIdAsync(id);
            await _userRepository.UpdateAsync(user);

            return Ok();
        }
        
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            //TODO Протестировать удаление
            try
            {
                var customer = await _userRepository.GetByIdAsync(id);
                if (customer != null)
                {
                    await _userRepository.DeleteAsync(customer);
                    return Ok();
                }

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Произошла ошибка при удалении");
            }
           
        }
    }
}