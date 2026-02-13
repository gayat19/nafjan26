using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementModelsLibrary
{
    public class Patient : IComparable<Patient>, IEquatable<Patient>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Collection<Appointment>? Appointments { get; set; }

        public int CompareTo(Patient? other)
        {
            return other != null ? Id.CompareTo(other.Id) : 1;
        }

        public bool Equals(Patient? other)
        {
            return other != null && Id == other.Id;
        }
        override public string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Phone: {Phone} , Status: {Status}";
        }
    }
}
