﻿// <copyright file="GetCustomerAgreements.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Samples.Agreements
{
    using System;
    using System.Linq;
    using Models;
    using Models.Agreements;

    /// <summary>
    /// Showcases the retrieval of customer agreements.
    /// </summary>
    public class GetCustomerAgreements : BasePartnerScenario
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCustomerAgreements"/> class.
        /// </summary>
        /// <param name="context">The scenario context.</param>
        public GetCustomerAgreements(IScenarioContext context) : base("Get all customer agreements.", context)
        {
        }

        /// <summary>
        /// Executes the get customer agreements scenario.
        /// </summary>
        protected override void RunScenario()
        {
            var partnerOperations = this.Context.UserPartnerOperations;
            string selectedCustomerId = this.ObtainCustomerId("Enter the ID of the customer to create the agreement for");

            this.Context.ConsoleHelper.StartProgress("Retrieving customer's agreements");

            ResourceCollection<Agreement> customerAgreements = partnerOperations.Customers.ById(selectedCustomerId)
                .Agreements.Get();

            this.Context.ConsoleHelper.StopProgress();

            if (!customerAgreements.Items.Any())
            {
                Console.WriteLine("No Service requests found for the given customer.");
            }
            else
            {
                this.Context.ConsoleHelper.WriteObject(customerAgreements, "Customer agreements:");
            }
        }
    }
}
