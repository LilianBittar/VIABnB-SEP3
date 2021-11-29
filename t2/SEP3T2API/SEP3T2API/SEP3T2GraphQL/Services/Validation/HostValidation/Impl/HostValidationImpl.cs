using System;
using System.Linq;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation.HostValidation.Impl
{
    public class HostValidationImpl : IHostValidation
    {
        public bool IsValidEmail(string email)
        {
            if (email != null && !email.Trim().EndsWith(".") && email.Contains("."))
            {
                //some form of inbuilt mail validation
                var addr = new System.Net.Mail.MailAddress(email);

                if (addr.Address == email)
                {
                    return true;
                }
            }

            throw new FormatException("Invalid email");
        }

        public bool IsValidFirstname(string firstname)
        {
            if (firstname != null && IsLettersOnly(firstname))
            {
                return true;
            }

            throw new ArgumentException("Invalid firstname");
        }

        public bool IsValidLastname(string lastname)
        {
            if (lastname != null && IsLettersOnly(lastname))
            {
                return true;
            }

            throw new ArgumentException("Invalid lastname");
        }

        public bool IsValidPassword(string passWord)
        {
            int validConditions = 0;
            if (passWord == null)
            {
                throw new ArgumentException("invalid password");
            }

            if (passWord.Length < 8)
            {
                throw new ArgumentException("password must at least be a length of 8 characters");
            }


            foreach (char c in passWord)
            {
                if (passWord.Any(char.IsLower))
                {
                    validConditions++;
                    break;
                }

                throw new ArgumentException("password must contain at least one lowercase letter");
            }

            foreach (char c in passWord)
            {
                if (passWord.Any(char.IsUpper))
                {
                    validConditions++;
                    break;
                }

                throw new ArgumentException("password must contain at least one uppercase letter");
            }
            
            foreach (char c in passWord)
            {
                if (passWord.Any(char.IsDigit))
                {
                    validConditions++;
                    break;
                }

                throw new ArgumentException("password must contain at least one number");
            }

            if (validConditions == 3)
            {
                return true;
            }

            throw new ArgumentException("password invalid");
        }


        public bool IsValidPhoneNumber(string phoneNumber)
        {
            if (phoneNumber != null && !phoneNumber.Any(char.IsLetter) && !phoneNumber.Any(char.IsSymbol))
            {
                return true;
            }

            throw new ArgumentException("invalid phone number");
        }

        public bool IsValidCprNumber(string cpr)
        {
            if (cpr==null)
            {
                throw new ArgumentException("cpr number required");
            }

            if (cpr.Any(char.IsLetter))
            {
                throw new ArgumentException("cpr number can only contain numbers");
            }
            if (cpr.Contains('-') && cpr.Length!=11)
            {
                throw new ArgumentException("Invalid cpr number Length");
            }

            if (!cpr.Contains('-') && cpr.Length!=10)
            {
                throw new ArgumentException("Invalid cpr number Length");
            }

            return true;
        }

        public bool IsValidHost(Host host)
        {
            if (IsValidEmail(host.Email) && IsValidFirstname(host.FirstName) && IsValidLastname(host.LastName) &&
                IsValidPassword(host.Password) && IsValidPhoneNumber(host.PhoneNumber) && IsValidCprNumber(host.Cpr))
            {
                return true;
            }

            throw new ArgumentException("Invalid host");
        }

        public bool IsLettersOnly(string arg)
        {
            if (arg.All(char.IsLetter))
            {
                return true;
            }

            throw new ArgumentException($"Invalid string: {arg}");
        }
    }
}