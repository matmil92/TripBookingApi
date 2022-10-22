﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripBookingApi.Domain.Entities
{
    public class Country
    {
        public Country()
        {
            CountryName = "";
            Trips = new List<Trip>();
        }

        public Country(int id, string countryName)
        {
            Id = id;
            CountryName = countryName;
            Trips = new List<Trip>();
        }

        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }
        public List<Trip> Trips { get; set; }

    }
}
