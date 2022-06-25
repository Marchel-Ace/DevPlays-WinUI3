using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DevPlays_WinUI3.Core.Contracts.Services;
using DevPlays_WinUI3.Core.Models;

namespace DevPlays_WinUI3.Core.Services
{
    // This class holds sample data used by some generated pages to show how they can be used.
    // TODO: The following classes have been created to display sample data. Delete these files once your app is using real data.
    // 1. Contracts/Services/ISampleDataService.cs
    // 2. Services/SampleDataService.cs
    // 3. Models/SampleCompany.cs
    // 4. Models/SampleOrder.cs
    // 5. Models/SampleOrderDetail.cs
    public class SampleDataService : ISampleDataService
    {
        private List<SampleOrder> _allOrders;

        public SampleDataService()
        {
        }

        private static IEnumerable<SampleOrder> AllOrders()
        {
            // The following is order summary data
            return new List<SampleOrder>()
            {
                new SampleOrder(){
                    Name = "Number Base Converter",
                    Descriptions = "Convert numbers from one base to another",
                    NavigatedToName = "0",
                },
                new SampleOrder(){
                    Name = "SQL Formatter",
                    Descriptions = "Format SQL queries",
                    NavigatedToName = "1",
                },
                new SampleOrder(){
                    Name = "XML Formatter",
                    Descriptions = "Format XML",
                    NavigatedToName = "2",

                },
                new SampleOrder(){
                    Name = "JSON Formatter",
                    Descriptions = "Format JSON",
                    NavigatedToName = "3",
                },
                new SampleOrder(){
                    Name = "Base 64 Encoder and Decoder",
                    Descriptions = "Encode and decode base 64",
                    NavigatedToName = "4",
                },
                new SampleOrder()
                {
                    Name = "GZip Tools",
                    Descriptions = "Compress and decompress GZip",
                    NavigatedToName = "5",
                },
                new SampleOrder()
                {
                    Name = "JWT Decoder",
                    Descriptions = "Decode JWT",
                    NavigatedToName = "6",
                },
                new SampleOrder()
                {
                    Name = "Text Diff",
                    Descriptions = "Compare two texts",
                    NavigatedToName = "7",
                },
                new SampleOrder()
                {
                    Name = "Regex Tester",
                    Descriptions = "Test regular expressions",
                    NavigatedToName = "8",
                },
                new SampleOrder()
                {
                    Name = "Hash Generator",
                    Descriptions = "Generate hashes",
                    NavigatedToName = "9",
                },
            };
        }

        private static IEnumerable<SampleCompany> AllCompanies()
        {
            return new List<SampleCompany>()
            {
                new SampleCompany(){}

            };
        }

        public async Task<IEnumerable<SampleOrder>> GetContentGridDataAsync()
        {
            if (_allOrders == null)
            {
                _allOrders = new List<SampleOrder>(AllOrders());
            }

            await Task.CompletedTask;
            return _allOrders;
        }
    }
}
