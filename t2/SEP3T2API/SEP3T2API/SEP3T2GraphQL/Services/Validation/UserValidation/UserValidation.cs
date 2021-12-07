using System;
using System.Linq;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Validation.UserValidation
{
    public class UserValidation
    {
        private IUserRepository _repository;

        public UserValidation(IUserRepository repository)
        {
            _repository = repository;
        }

        private async Task<bool> IsValidEmail(string email)
        {
            var user = await _repository.GetUserByEmailAsync(email);
            if (user == null)
            {
                if (email != null && !email.Trim().EndsWith(".") && email.Contains("."))
                {
                    //some form of inbuilt mail validation
                    var addr = new System.Net.Mail.MailAddress(email);

                    if (addr.Address != email)
                    {
                        throw new FormatException("Invalid email");
                       
                    }
                    return true;
                }

                throw new FormatException("email not formatted correctly");
            }
            throw new ArgumentException("User already exists");
        }

        private static bool IsValidFirstname(string firstname)
        {
            if (firstname != null && IsLettersOnly(firstname))
            {
                return true;
            }

            throw new ArgumentException("Invalid firstname");
        }

        private static bool IsValidLastname(string lastname)
        {
            if (lastname != null && IsLettersOnly(lastname))
            {
                return true;
            }

            throw new ArgumentException("Invalid lastname");
        }

        private static bool IsValidPassword(string passWord)
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


        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (phoneNumber != null && phoneNumber.All(char.IsDigit))
            {
                return true;
            }

            throw new ArgumentException("invalid phone number");
        }

        public async Task<bool> IsValidUser(User user)
        {
            if (await IsValidEmail(user.Email) && IsValidFirstname(user.FirstName) && IsValidLastname(user.LastName) &&
                IsValidPassword(user.Password) && IsValidPhoneNumber(user.PhoneNumber))
            {
                return true;
            }
            throw new ArgumentException("Invalid host");
        }

        private static bool IsLettersOnly(string arg)
        {
            if (arg.All(char.IsLetter))
            {
                return true;
            }
            return false;
        }
    }
}