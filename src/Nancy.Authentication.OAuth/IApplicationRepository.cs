﻿namespace Nancy.Authentication.OAuth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Responsible for retrieving information about the <see cref="Application"/> that is being authorized
    /// </summary>
    public interface IApplicationRepository
    {
        Application GetApplication(string clientId);
    }

    public class DefaultApplicationRepository : IApplicationRepository
    {
        private readonly List<Application> applications;

        public DefaultApplicationRepository()
        {
            this.applications = new List<Application>
            {
                new Application
                {
                    ClientId = "NancyApp", 
                    Description = "This is a Nancy application", 
                    Name = "NancyApp"
                },

                new Application
                {
                    ClientId = "Facebook", 
                    Description = "Facebook the social media site", 
                    Name = "Facebook"
                }
            };
        }

        public Application GetApplication(string clientId)
        {
            return this.applications.Where(x => x.ClientId.Equals(clientId, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
        }
    }

    public class Application
    {
        public string ClientId { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string Secret { get; set; }
    }
}