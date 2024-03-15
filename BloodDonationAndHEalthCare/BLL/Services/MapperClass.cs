using AutoMapper;
using AutoMapper.QueryableExtensions.Impl;
using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using System.Runtime.InteropServices;

namespace BLL.Services
{
    public static class MapperClass
    {
        public static IMapper Mapped()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserAdminDTO, UserAdmin>();
                c.CreateMap<UserAdmin, UserAdminDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;
        }
        public static IMapper MappedUser()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();

                c.CreateMap<User, UserDTO>();

                c.CreateMap<User,UserDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;
        }

        public static IMapper MappedDonation()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Donation, DonationDTO>();
                c.CreateMap<DonationDTO, Donation>();
            });

            var mapper = new Mapper(cfg);
            return mapper;
        }
        public static IMapper MapperPost()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PostDTO, Post>();
                c.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;

        }

        public static IMapper MapperHelpPost()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<HelpPostDTO, HelpPost>();
                c.CreateMap<HelpPost, HelpPostDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;

        }

        public static IMapper MapperFile()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FileDTO, File>();
                c.CreateMap<File, FileDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper;

        }
       
        public static IMapper MappedBloodDonationCampaign()

        {

            var cfg = new MapperConfiguration(c =>

            {

                c.CreateMap<BloodDonationCampaign, BloodDonationCampaignDTO>();

                c.CreateMap<BloodDonationCampaignDTO, BloodDonationCampaign>();

            });

            var mapper = new Mapper(cfg);

            return mapper;

        }
        public static IMapper MapperCompleteDonation()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CompleteDonationDTO, CompleteDonation>();
                c.CreateMap<CompleteDonation, CompleteDonationDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;

        }

        public static IMapper MapperProvideHelp()

        {

            var cfg = new MapperConfiguration(c =>

            {

                c.CreateMap<ProvideHelp, ProvideHelpDTO>();



                c.CreateMap<ProvideHelpDTO, ProvideHelp>();

            });

            var mapper = new Mapper(cfg);

            return mapper;

        }
    }

}
