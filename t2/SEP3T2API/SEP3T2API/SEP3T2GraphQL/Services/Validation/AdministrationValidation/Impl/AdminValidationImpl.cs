using System;

namespace SEP3T2GraphQL.Services.Validation.AdministrationValidation.Impl
{
    public class AdminValidationImpl : IAdminValidation
    {
        public bool IsValidId(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid ID");
            }

            return true;
        }

        public bool IsValidStatus(string status)
        {
            if (!status.Equals("Approved") || !status.Equals("NotApproved") || !status.Equals("NotAnswered"))
            {
                throw new ArgumentException("Invalid status");
            }

            return true;
        }
    }
}