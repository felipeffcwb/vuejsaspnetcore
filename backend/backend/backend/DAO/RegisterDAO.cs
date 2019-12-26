using backend.data;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DAO
{
    public class RegisterDAO
    {
        private readonly ApplicationDbContext _context;

        public RegisterDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        internal bool InsertPeople(Registers register)
        {
            _context.registers.Add(register);
            _context.SaveChanges();
            return true;
        }

        internal bool VerifyIfExist(Registers register)
        {
            try
            {
                return _context.registers.FirstOrDefault(x => x.Email.Equals(register.Email) && x.Job.Equals(register.Job) && x.Status) == null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Registers> ListAllOfRegistereds()
        {
            try
            {
                return _context.registers.Where(x => x.Status).ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal bool DeleteUsers(int id)
        {
            try
            {
                Registers register = new Registers();
                register = SearchRegisterById(id);
                if (register != null)
                {
                    register.Status = false;
                    _context.Entry(register).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal Registers SearchRegisterById(int id)
        {
            try
            {
                return _context.registers.FirstOrDefault(x => x.RegisterId.Equals(id) && x.Status);
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal bool UpdateRegister(Registers register)
        {
            try
            {
                _context.Entry(register).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
                
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
