using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUnderstandingApp.Models
{
    public class Doctor : IComparable<Doctor>, IEquatable<Doctor>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SpecialityId { get; set; }

        public Speciality? Speciality { get; set; }
        public int Experience { get; set; }
        public Collection<Appointment>? Appointments { get; set; }

        public int CompareTo(Doctor? other)
        {
            return other != null ? Id.CompareTo(other.Id) : 1;
        }

        public bool Equals(Doctor? other)
        {
            return other != null && Id == other.Id;
        }

        override public string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Speciality: {Speciality?.Name}, Experience: {Experience} years";
        }
    }
}
