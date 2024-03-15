using BLL.DTO;
using DAL.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using DAL;

namespace BLL.Services
{
    public class ProvideHelpService
    {
        public static ProvideHelpDTO AddProvideHelp(ProvideHelpDTO provideHelp)
        {
            if (provideHelp == null)
            {
                throw new ArgumentNullException(nameof(provideHelp));
            }
            provideHelp.HelpDate = DateTime.UtcNow;


            var data = MapperClass.MapperProvideHelp();
            var mapped = data.Map<ProvideHelp>(provideHelp);
            var provideHelpRepo = DataAccessFactory.ProvideHelpData().Create(mapped);
            var data2 = MapperClass.MapperProvideHelp();
            var mapped2 = data2.Map<ProvideHelpDTO>(provideHelpRepo);

            return mapped2;
        }


    }
}