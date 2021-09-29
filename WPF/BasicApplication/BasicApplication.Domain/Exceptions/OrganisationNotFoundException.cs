using System;

namespace BasicApplication.Domain.Exceptions
{
    public class OrganisationNotFoundException : Exception
    {
        private readonly string _organisationName;
        public OrganisationNotFoundException(string organisationName)
        {
            _organisationName = organisationName;
        }

        public OrganisationNotFoundException(string organisationName,string message) : base(message)
        {
            _organisationName = organisationName;
        }

        public OrganisationNotFoundException(string organisationName,string message, Exception innerException) : base(message, innerException)
        {
            _organisationName = organisationName;
        }
    }
}
