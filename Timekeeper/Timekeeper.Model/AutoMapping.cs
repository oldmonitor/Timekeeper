using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timekeeper.Model.TeamManagement;
using Timekeeping.Entity.Entities;

namespace Timekeeper.Model
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserListRecordModel>().ForMember(dest=>dest.PhotoUrl, opt=>
            {
                opt.MapFrom(src => src.UserPhotoes.FirstOrDefault(p => p.IsMain == true).PhotoUrl);
            }).ReverseMap();
            CreateMap<User, UserProfileDetailModel>().ForMember(dest => dest.PhotoUrl, opt =>
            {
                opt.MapFrom(src => src.UserPhotoes.FirstOrDefault(p => p.IsMain == true).PhotoUrl);
            }).ReverseMap();
            CreateMap<UserPhoto, UserPhotoModel>().ReverseMap();


            

        }
    }
}
