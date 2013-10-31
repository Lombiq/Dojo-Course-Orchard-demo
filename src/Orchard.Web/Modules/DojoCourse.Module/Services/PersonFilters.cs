using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoCourse.Module.Services
{
    public interface IPersonFilter : IDependency
    {
        string FilterBiography(string biography);
    }


    public class BadwordPersonFilter : IPersonFilter
    {
        public string FilterBiography(string biography)
        {
            return biography.Replace("damn", "cute");
        }
    }


    public class ShortBiographyPersonFilter : IPersonFilter
    {
        public string FilterBiography(string biography)
        {
            if (biography.Length < 10)
            {
                return "This person has a short biography.";
            }

            return biography;
        }
    }
}