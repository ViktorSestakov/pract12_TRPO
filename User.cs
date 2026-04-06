using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace pract12_TRPO
{
    public class User : ObservableObject, IDataErrorInfo
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _login;
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private DateTime _createdAt = DateTime.Now;
        public DateTime CreatedAt
        {
            get => _createdAt;
            set => SetProperty(ref _createdAt, value);
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Login):
                        if (string.IsNullOrWhiteSpace(Login) || Login.Length < 5)
                            return "Минимум 5 символов";
                        break;

                    case nameof(Email):
                        if (!Email.Contains("@"))
                            return "Некорректный email";
                        break;

                    case nameof(Password):
                        if (!Regex.IsMatch(Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
                            return "Пароль слабый";
                        break;

                    case nameof(CreatedAt):
                        if (CreatedAt < DateTime.Now.Date)
                            return "Дата не может быть в прошлом";
                        break;
                }

                return null;
            }
        }
    }
}
