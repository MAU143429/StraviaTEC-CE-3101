﻿using Microsoft.AspNetCore.Mvc;
using StraviaAPI.Data;
using StraviaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly SQLDB _SqlDb;

        public GroupController(SQLDB sqlDb)
        {
            _SqlDb = sqlDb;
        }

        // GET: <GroupController>
        [HttpGet]
        public Task<IEnumerable<Group>> Get() 
            => _SqlDb.GetAllGroups();

        // GET api/<GroupController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GroupController>
        [HttpPost]
        public Task Create(GroupInput input)
        {
            return _SqlDb.CreateGroup(input);
        }
    }
}