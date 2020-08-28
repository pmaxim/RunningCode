using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebUi.Models;
using IMapper = AutoMapper.IMapper;

namespace WebUi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminUsersController : ControllerBase
    {
        private readonly IUserRepository _repoUser;
        private readonly IMapper _mapper;

        public AdminUsersController(IUserRepository repoUser,
            IMapper mapper)
        {
            _repoUser = repoUser;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<List<UserView>> GetTable()
        {
            var m = new List<UserView>();
            var list = await _repoUser.Users.AsNoTracking()
                .ToListAsync();
            if(list.Count == 0) return m;

            m.AddRange(list.Select(p => _mapper.Map<UserView>(p)));
            return m;
        }

        [HttpPost("[action]")]
        public async Task<List<UserView>> UpdateUser(UserView user)
        {
            if (user.Id == 0)
            {
                var u = _mapper.Map<User>(user);
                u.IsActive = true;
                u.OpenTime = DateTime.Now;
                _repoUser.Create(u);
            }
            else
            {
                var u = await _repoUser.GetAsync(user.Id);
                u.Password = user.Password;
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.Phone = user.Phone;
                u.Email = user.Email;
                u.Gender = user.Gender;
                u.Date = user.Date;
            }
            await _repoUser.SaveChangesAsync();
            return await GetTable();
        }
    }
}
