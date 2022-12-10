﻿using System;

namespace SAASystem.Builder
{
    public class UserBuilder
    {
        private UserContextModel _userContextModel = new UserContextModel();
        public UserBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _userContextModel = new UserContextModel();
        }
        public void Set(UserContextModel userContextModel)
        {
            _userContextModel = userContextModel;
        }
        public UserBuilder SetAddress(string address)
        {
            _userContextModel.Address = address;
            return this;
        }

        public UserBuilder SetEmail(string email)
        {
            _userContextModel.Email = email;
            return this;
        }

        public UserBuilder SetGivenName(string givenName)
        {
            _userContextModel.GivenName = givenName;
            return this;
        }

        public UserBuilder SetPhoneNo(string phoneNo)
        {
            _userContextModel.PhoneNo = phoneNo;
            return this;
        }

        public UserBuilder SetSurname(string surname)
        {
            _userContextModel.Surname = surname;
            return this;
        }

        public UserBuilder SetUsername(string username)
        {
            _userContextModel.Username = username;
            return this;
        }
        public UserContextModel Build()
        {
            UserContextModel model = _userContextModel;
            Reset();
            return model;
        }
    }
}
