using System;
using System.Linq;

namespace SEP3T2GraphQL.Services.Validation.GuestValidation
{
    public class GuestValidation : IGuestValidation
    {
        public bool IsValidStudentNumber(int studentNumber)
        {
            if (studentNumber > 100000 && studentNumber < 999999)
            {
                return true;
            }
            throw new ArgumentException("Invalid student number");
        }
    }
}