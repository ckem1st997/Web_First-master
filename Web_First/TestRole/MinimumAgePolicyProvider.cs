using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_First.TestRole
{
    internal class MinimumAgePolicyProvider : IAuthorizationPolicyProvider
    {
        const string POLICY_PREFIX = "MinimumAge";

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync()
        {
            throw new NotImplementedException();
        }

        // Policies are looked up by string name, so expect 'parameters' (like age)
        // to be embedded in the policy names. This is abstracted away from developers
        // by the more strongly-typed attributes derived from AuthorizeAttribute
        // (like [MinimumAgeAuthorize()] in this sample)
        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase) &&
                int.TryParse(policyName.Substring(POLICY_PREFIX.Length), out var age))
            {
                var policy = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme);
                policy.AddRequirements(new MinimumAgeRequirement(age));
                return Task.FromResult(policy.Build());
            }

            return Task.FromResult<AuthorizationPolicy>(null);
        }
    }
}
