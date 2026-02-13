using EFUnderstandingApp.Contexts;
using EFUnderstandingApp.Models;

namespace EFUnderstandingApp;

class Program
{
    public static void Main(string[] args)
    {
        ClinicContext context = new ClinicContext();
        //Speciality speciality = new Speciality {  Name = "Cardiology" };
        //context.Specialities.Add(speciality);
        //Console.WriteLine("The state of the new speciality "+context.Entry(speciality).State);

        //var doctors = context.Doctors.ToList();
        //foreach (var doctor in doctors)
        //    Console.WriteLine(doctor);
        //doctors[0].Experience = 15;
        //context.Doctors.Update(doctors[0]);
        //Console.WriteLine("The state of the doctor: " + context.Entry(doctors[0]).State);


        // context.SaveChanges();
        //Console.WriteLine("The state of the doctor: " + context.Entry(doctors[0]).State);

        var speciality = context.Specialities.FirstOrDefault(s => s.Id == 4);
        Console.WriteLine(speciality);
        context.Specialities.Remove(speciality);
        Console.WriteLine("The state of the speciality is " + context.Entry(speciality).State);
        context.SaveChanges();
        Console.WriteLine("The state of the speciality is " + context.Entry(speciality).State);

    }
}
