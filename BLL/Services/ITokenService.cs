﻿using BLL.DTO;
using DAL.Models;
using Ecommerce.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ITokenService
    {
       string CreateToken(ApplicationUser user);
    }
}
