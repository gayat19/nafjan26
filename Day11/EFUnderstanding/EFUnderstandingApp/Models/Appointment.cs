using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUnderstandingApp.Models
{
    public class Appointment : IComparable<Appointment>, IEquatable<Appointment>
    {
        [Key]
        public int AppointmnetNumber { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmnetDate { get; set; }
        public string Status { get; set; } = string.Empty;
        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }

        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }

        public int CompareTo(Appointment? other)
        {
            return other != null ? AppointmnetNumber.CompareTo(other.AppointmnetNumber) : 1;
        }

        public bool Equals(Appointment? other)
        {
           return other != null && AppointmnetNumber == other.AppointmnetNumber;
        }
        override public string ToString()
        {
            return $"Appointmnet Number: {AppointmnetNumber}, Doctor: {Doctor?.Name}, Patient: {Patient?.Name}, Date: {AppointmnetDate}, Status: {Status}";
        }
    }
}
