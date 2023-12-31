﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Model
{
    public class UserModel
    {
        public string CreatedBy { get; set; }
        public int RowNum { get; set; }
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string UserFullName { get; set; }
    }
    public class UserResponseModelViewModel
    {
        public UserModel usermodel { get; set; }
        public ResponseStatusModel response { get; set; }
        public List<UserModel> usermodellist { get; set; }
    }
}
