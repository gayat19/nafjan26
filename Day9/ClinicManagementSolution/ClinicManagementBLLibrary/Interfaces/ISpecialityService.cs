using ClinicManagementModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementBLLibrary.Interfaces
{
    public interface ISpecialityService
    {
        /// <summary>
        /// Gets all specialities from the repository. If there are no specialities, it throws a NoItemsInCollectionException.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NoItemsInCollectionException"></exception>
        public List<Speciality> GetAllSpecialities();
        /// <summary>
        /// Retrieves the <see cref="Speciality"/> with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the speciality to retrieve. Must be a positive integer.</param>
        /// <returns>The <see cref="Speciality"/> with the specified identifier if found; otherwise, this method throws an
        /// exception.</returns>
        /// <exception cref="ItemNotFoundException">Thrown if a speciality with the specified <paramref name="id"/> does not exist.</exception>
        public Speciality? GetSpecialityById(int id);

        /// <summary>
        /// Gets the identifier of a speciality based on its name. This method retrieves all specialities from the repository and searches for a speciality with the specified name. If a speciality with the given name is found, its identifier is returned. If there are no specialities in the repository, a NoItemsInCollectionException is thrown. If no speciality with the specified name is found, an ItemNotFoundException is thrown.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NoItemsInCollectionException"></exception>
        /// <exception cref="ItemNotFoundException"></exception>
        public int? GetSpecialityByName(string name);
        /// <summary>
        /// Adds a new speciality to the system. This method checks for duplicate speciality names before adding a new speciality. If a speciality with the same name already exists, an exception is thrown. If the addition is successful, the method returns true; otherwise, it returns false.
        /// </summary>
        /// <param name="speciality"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool AddSpeciality(Speciality speciality);

    }
}
