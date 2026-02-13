using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUnderstandingApp.Models
{
    public class Speciality : IComparable<Speciality>, IEquatable<Speciality>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Doctor>? Doctors { get; set; }

        public int CompareTo(Speciality? other)
        {
            return other != null ? Id.CompareTo(other.Id) : 1;
        }

        public bool Equals(Speciality? other)
        {
            return other != null && Id == other.Id;
        }
        override public string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }
}
