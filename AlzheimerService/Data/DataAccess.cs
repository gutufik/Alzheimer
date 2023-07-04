using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlzheimerService.Data
{
    public class DataAccess
    {
        public delegate void RefreshListDelegate();
        public static event RefreshListDelegate RefreshList;

        public static List<Patient> GetPatients()
        {
            return AlzheimerEntities.GetContext().Patients.ToList();
        }
        public static List<Request> GetRequests()
        {
            return AlzheimerEntities.GetContext().Requests.ToList();
        }
        public static List<User> GetUsers()
        {
            return AlzheimerEntities.GetContext().Users.ToList();
        }

        public static void SaveRequest(Request request)
        {
            if (request.Id == 0)
            {
                AlzheimerEntities.GetContext().Requests.Add(request);
            }
            AlzheimerEntities.GetContext().SaveChanges();
            RefreshList?.Invoke();
        }

        public static User GetUser(string login, string Password)
        {
            return AlzheimerEntities.GetContext().Users.FirstOrDefault(x => x.Login == login && x.Password == Password && x.RoleId == 2);
        }

        public static User GetFreeVolunteer()
        {
            var rnd = new Random();
            var volunteers = GetUsers().FindAll(x => x.Role.Name == "Волонтер" && !x.Requests.Any(y => y.Date.Date == DateTime.Today.Date));

            return volunteers[rnd.Next(0, volunteers.Count)];
        }
    }
}
