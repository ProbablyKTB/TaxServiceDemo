using System;
using System.Collections.Generic;

namespace TaxServiceDemo
{
    public class ApiProfiles
    {
        private Dictionary<string, ApiProfile> _profiles;

        public ApiProfiles()
        {
            _profiles = new Dictionary<string, ApiProfile>(StringComparer.InvariantCultureIgnoreCase);
        }

        public ApiProfile this[string name] { get => Get(name); set => _profiles[name] = value; }

        public void Add(string name, ApiProfile profile) => _profiles.Add(name, profile);
        public ApiProfile Get(string name) => _profiles.GetValueOrDefault(name ?? "", null);
    }
    public class ApiProfile
    {
        public string ApiKey { get; set; }
        public Dictionary<string, string> Endpoints { get; set; }

        public ApiProfile()
        {
            Endpoints = new Dictionary<string, string>();
        }
    }
}