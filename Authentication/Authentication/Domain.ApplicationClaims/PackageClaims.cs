using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApplicationClaims
{

    public abstract class BaseClaims {
        public Guid Id { get; set; }
    }

    public class PackageClaims:BaseClaims
    {
        public string Claim { get; set; }

    }

    public class OrganisationClaims:BaseClaims { 
    
    }

    public class ProfileClaims:BaseClaims { }


}
