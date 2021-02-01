using System;
using System.Collections.Generic;
using System.Linq;
using Fab.Api.Domain;
using Fab.Api.Infra;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Fab.Api.Utils
{
    public static class Seeder
    {
        public static void SeedParent(string jsonData,
            IServiceProvider serviceProvider) {
            
            List<Loan> loans =
                JsonConvert.DeserializeObject<List<Loan>>(
                    jsonData);
            using (
                var serviceScope = serviceProvider
                    .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope
                    .ServiceProvider.GetService<FabContext>();
                if (!context.Loans.Any()) {
                    context.AddRange(loans);
                    context.SaveChanges();
                }
            }
        }
        public static void SeedChild(string jsonData,
            IServiceProvider serviceProvider) {
            
            List<Installment> installments =
                JsonConvert.DeserializeObject<List<Installment>>(
                    jsonData);
            using (
                var serviceScope = serviceProvider
                    .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope
                    .ServiceProvider.GetService<FabContext>();
                if (!context.Installments.Any()) {
                    context.AddRange(installments);
                    context.SaveChanges();
                }
            }
        }
    }
}