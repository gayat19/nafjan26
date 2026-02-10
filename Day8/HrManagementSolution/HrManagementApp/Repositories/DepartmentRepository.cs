using HrAppModelLibrary;
using HrManagementApp.Interfaces;


namespace HrManagementApp.Repositories
{
    public class DepartmentRepository : IRepository<int, Department>
    {
        List<Department> departments = new List<Department>();
        public bool Add(Department item)
        {
            int id = GenerateId();
            item.Id = id;
            departments.Add(item);
            return true;
        }

        private int GenerateId()
        {
            if (departments.Count == 0)
                return 1;
            else
            {
                departments.Sort();
                return departments.Count + 1;
            }

        }

        public bool Delete(int key)
        {
            var department = Get(key);
            if (department != null)
            {
                departments.Remove(department);
                return true;
            }
            return false;
        }

        public Department? Get(int key)
        {
            if (departments.Contains(new Department() { Id = key }))
            {
                int index = departments.IndexOf(new Department() { Id = key });
                return departments[index];
            }
            return null;
        }

        public IEnumerable<Department>? GetAll()
        {
            if (departments.Count > 0)
                return departments;
            return null;
        }

        public bool Update(int key, Department item)
        {
            var oldDepartment = Get(key);
            if (oldDepartment != null)
            {
                oldDepartment.Name = item.Name;
                return true;
            }
            return false;
        }
    }
}
