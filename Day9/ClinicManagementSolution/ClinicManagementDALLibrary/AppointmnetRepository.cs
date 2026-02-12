using ClinicManagementModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementDALLibrary
{
    public class AppointmentRepository : Repository<int, Appointment>
    {
        public override Appointment? Add(Appointment item)
        {
            int newId = GenerateId();
            item.AppointmnetNumber = newId;
            _items.Add(newId, item);
            return item;
        }

        private int GenerateId()
        {
            if (_items.Count == 0)
            {
                return 1;
            }
            List<int> keys = _items.Keys.ToList();
            keys.Sort();
            return keys[keys.Count - 1] + 1;
        }
    }
}
