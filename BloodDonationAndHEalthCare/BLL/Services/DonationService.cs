using AutoMapper;
using BLL.DTO;
using BLL.DTOs;
using DAL;
using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace BLL.Services
{
    public class DonationService
    {
        public static DonationDTO CreateDonationRequest(DonationDTO donationDTO, string token)
        {

            var UserEmail = DataAccessFactory.TokenData().SearchUserIdByToken(token);
            var user = DataAccessFactory.UserData().ReadByEmail(UserEmail);
            donationDTO.UserId = user.UserId;
            if (donationDTO == null)
            {
                throw new ArgumentNullException(nameof(donationDTO));
            }

            var donation = MapperClass.MappedDonation().Map<Donation>(donationDTO);
            donation.CreatedAt = DateTime.UtcNow;

            var createdDonation = DataAccessFactory.DonationData().Create(donation);

            var mappedDonationDTO = MapperClass.MappedDonation().Map<DonationDTO>(createdDonation);

            return mappedDonationDTO;
        }

        public static List<DonationDTO> GetPendingDonationRequests()
        {
            var donationEntities = DataAccessFactory.DonationData().Read().Where(d => !d.IsApproved).AsQueryable();

            var mappedDonationDTOs = MapperClass.MappedDonation().ProjectTo<DonationDTO>(donationEntities).ToList();

            return mappedDonationDTOs;
        }

        public static bool ApproveDonationRequest(int donationId)
        {
            var donation = DataAccessFactory.DonationData().Read(donationId);

            if (donation != null && !donation.IsApproved)
            {
                donation.IsApproved = true;
                donation.ApprovedAt = DateTime.UtcNow;
                donation.IsPaid = true;

                var updatedDonation = DataAccessFactory.DonationData().Update(donation);

                return updatedDonation != null;
            }

            return false;
        }
        public static bool DeleteDonationRequest(int donationId)
        {
            var donation = DataAccessFactory.DonationData().Read(donationId);

            if (donation != null)
            {
                var isDeleted = DataAccessFactory.DonationData().Delete(donationId);
                return isDeleted;
            }

            return false;
        }
       



        public static List<DonationDTO> GetApprovedDonations() 
        {
            var getusers = DataAccessFactory.DonationData().ReadAccept();
            var data = MapperClass.MappedDonation();
            var mapper2 = data.Map<List<DonationDTO>>(getusers);

            return mapper2;
        }
        public static List<BloodDonationCampaignDTO> GetAllBloodDonationCampaigns()
        {
            var data = MapperClass.MappedBloodDonationCampaign();
            var getCampaigns = DataAccessFactory.BloodDonationCampaignData().Read();


            var currentDateTime = DateTime.UtcNow;
            var validCampaigns = getCampaigns.Where(c => c.EndDate >= currentDateTime).ToList();

            var mapped = data.Map<List<BloodDonationCampaignDTO>>(validCampaigns);

            return mapped;
        }







    }
}
