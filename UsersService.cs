using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract12_TRPO
{
    public class UsersService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        public ObservableCollection<User> Users { get; set; } = new();

        public UsersService()
        {
            GetAll();
        }

        public void GetAll()
        {
            var list = _db.Users.ToList();
            Users.Clear();

            foreach (var item in list)
                Users.Add(item);
        }

        public void Add(User user)
        {
            if (_db.Users.Any(x => x.Login.ToLower() == user.Login.ToLower()))
                throw new Exception("Логин уже существует");

            if (_db.Users.Any(x => x.Email == user.Email))
                throw new Exception("Email уже существует");

            _db.Users.Add(user);
            Commit();
            Users.Add(user);
        }

        public void Remove(User user)
        {
            _db.Users.Remove(user);
            Commit();
            Users.Remove(user);
        }

        public int Commit() => _db.SaveChanges();
    }
}
