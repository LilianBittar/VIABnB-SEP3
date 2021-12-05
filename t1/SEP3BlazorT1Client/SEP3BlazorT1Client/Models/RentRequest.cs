using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SEP3BlazorT1Client.Models
{
    public class RentRequest
    {
        [Required, Range(1, Int32.MaxValue, ErrorMessage = "Id cannot be 0 or negative")]
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required]
        [JsonProperty("startDate")]

        public DateTime StartDate { get; set; }
        [Required]
        [JsonProperty("endDate")]

        public DateTime EndDate { get; set; }
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Number of guests must be 1 or above")]
        [JsonProperty("numberOfGuests")]

        public int NumberOfGuests { get; set; }
        [Required]
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]

        public RentRequestStatus Status { get; set; }
        [Required]
        [JsonProperty("guest")]

        public Guest Guest { get; set; }

        [Required]
        [JsonProperty("residence")]
        public Residence Residence { get; set; }
        [Required]
        [JsonProperty("requestCreationDate")]
        public DateTime RequestCreationDate { get; set; }

        public decimal GetTotalPrice()
        {
            return (decimal) (GetRentPeriodInDays() * Residence.PricePerNight * NumberOfGuests); 
        }

        public int GetRentPeriodInDays()
        {
            return (EndDate - StartDate).Days;
        }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RentRequestStatus
    {
        // Changed the values even though to match graphql enums 
        NOTANSWERED,
        NOTAPPROVED,
        APPROVED
    }
}