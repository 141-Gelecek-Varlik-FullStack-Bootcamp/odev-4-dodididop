﻿using System;
using AutoMapper;
using FutureAsset.DB.Entities.DatabaseContext;
using FutureAsset.Model;

namespace FutureAsset.Service.User
{
    public class UserService : IUserService
    {

        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Response<bool> Create(UserViewModel newUser)
        {
            try
            {
                var user = _mapper.Map<FutureAsset.DB.Entities.User>(newUser);

                user.CreateDate = DateTime.Now.Date;
                user.PhoneNumber = "2122342893";
                user.Email = "dido@gmail.com";
                user.IsActive = true;
                user.IsDeleted = false;
                user.Surname ="Cokyasa";
                user.Name = "Didem";
                using (var srv = new FutureAssetDBContext())
                {
                    srv.User.Add(user);
                    srv.SaveChanges();
                    return new Response<bool>(true);
                }
            }
            catch (Exception ex)
            {
                return new Response<bool>(false);
            }
        }
    }
}
