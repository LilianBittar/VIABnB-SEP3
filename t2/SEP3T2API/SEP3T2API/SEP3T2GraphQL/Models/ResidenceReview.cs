﻿namespace SEP3T2GraphQL.Models
{
    public class ResidenceReview
    {
        public double Rating { get; set; }
        public string ReviewText { get; set; }
        public Guest Guest { get; set; }
    }
}