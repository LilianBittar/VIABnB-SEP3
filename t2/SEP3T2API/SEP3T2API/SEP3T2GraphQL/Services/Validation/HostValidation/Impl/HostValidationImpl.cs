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

            throw new ArgumentException("Invalid email");
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
            if (passWord == null) return false;
            int validConditions = 0;
            foreach (char c in passWord)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }

                throw new Exception("password must contain at least one lowercase letter");
            }

            foreach (char c in passWord)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }

                throw new Exception("password must contain at least one uppercase letter");
            }

            if (validConditions == 0) return false;
            foreach (char c in passWord)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }

                throw new Exception("password must contain at least one number");
            }

            if (validConditions == 3)
            {
                return true;
            }

            throw new Exception("password invalid");
        }


        public bool IsValidPhoneNumber(string phoneNumber)
        {
            bool result = phoneNumber.Any(x => !char.IsLetter(x));
            if (phoneNumber != null && result)
            {
                return true;
            }

            return false;
        }

        public bool IsValidHost(Host host)
        {
            if (IsValidEmail(host.Email) && IsValidFirstname(host.FirstName) && IsValidLastname(host.LastName) &&
                IsValidPassword(host.Password) && IsValidPhoneNumber(host.PhoneNumber))
            {
                return true;
            }

            throw new Exception("Invalid host");
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