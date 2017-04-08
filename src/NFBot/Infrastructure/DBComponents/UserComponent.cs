
﻿using NFBot.Models.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFBot.Infrastructure.DBComponents
{
    public class UserComponent
    {
        private SqliteDbRepository _repository;

        public UserComponent()
        {
            _repository = new SqliteDbRepository();
        }

        public void CreateUser(User user)
        {
            if (user == null) throw new ArgumentNullException("user");
            _repository.InsertUser(user.UserId, user.City, user.CurrentTestId);
        }

        public void SetupCurrentTest(int userId, int testId)
        {
            List<User> users = GetAllUsers();
            var currentUser = users.First(u => u.UserId == userId);

            if (currentUser != null)
                _repository.UpdateUser(currentUser.UserId, currentUser.City, currentUser.CurrentTestId);
        }

        public List<User> GetAllUsers()
        {
            return _repository.GetUsers();
        }

        public bool CheckUser(int userId)
        {
            var users = _repository.GetUsers();

            if (users != null)
            {
                return users.Exists(u => u.UserId == userId);
            }

            return false;
        }
    }
}