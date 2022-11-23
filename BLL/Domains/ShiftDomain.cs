using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domains
{
    public class ShiftDomain
    {
        public readonly ShiftRepository _shiftRepository;

        public ShiftDomain(ShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        public Shift Insert(Shift shift)
        {
            return _shiftRepository.Insert(shift);
        }

        public Shift Update(Shift shift)
        {
            return _shiftRepository.Update(shift);
        }

        public Shift Delete(int id)
        {
            return _shiftRepository.Delete(id);
        }

        public List<Shift> GetAll()
        {
            return _shiftRepository.GetAll(); 
        }

        public Shift GetById(int id)
        {
            return _shiftRepository.GetById(id);
        }
    }
}
