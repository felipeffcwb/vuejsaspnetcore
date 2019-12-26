using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DAO;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly RegisterDAO _registerDAO;

        public RegisterController(RegisterDAO registerDAO)
        {
            _registerDAO = registerDAO;
        }


        // GET: api/Register
        [HttpGet]
        public List<Registers> Get()
        {
            return _registerDAO.ListAllOfRegistereds();
        }

        // GET: api/Register/5
        [HttpGet("{id}", Name = "Get")]
        public Registers Get(int id)
        {
            return _registerDAO.SearchRegisterById(id);
        }

        // POST: api/Register
        [HttpPost]
        public int Post([FromBody] Registers register)
        {
            return VerifyIsNullOrEmpty(register);
        }

        private int VerifyIsNullOrEmpty(Registers register)
        {
            if (String.IsNullOrEmpty(register.Email))
            {
                return (int)Helpers.RegisterErrors.EmailHasEmpty;
            }
            else if (String.IsNullOrEmpty(register.Name))
            {
                return (int)Helpers.RegisterErrors.NameHasEmpty;
            }
            else if (String.IsNullOrEmpty(register.Job))
            {
                return (int)Helpers.RegisterErrors.JobHasEmpty;
            }

            if (VerifiIfExist(register))
            {
                _registerDAO.InsertPeople(register);
                return (int)Helpers.RegisterErrors.Success;
            }
            else
            {
                return (int)Helpers.RegisterErrors.AlreadyRegistered;
            }
        }

        private bool VerifiIfExist(Registers register)
        {
            return _registerDAO.VerifyIfExist(register);
        }

        // PUT: api/Register/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Registers register)   
        {
            if (id == 1)
            {
                return false;
            }

            if (register != null && id == register.RegisterId)
            {
                return _registerDAO.UpdateRegister(register);
            }
            return false;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete([FromRoute] int id)
        {
            if (id == 1)
            {
                return 2;
            }
            if (_registerDAO.DeleteUsers(id))
            {
                return (int)Helpers.DeleteErrors.Success;
            }
            return (int)Helpers.DeleteErrors.ErrorDelete;
        }
    }
}
