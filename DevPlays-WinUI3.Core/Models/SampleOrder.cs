using System;
using System.Collections.Generic;

namespace DevPlays_WinUI3.Core.Models
{
    // Remove this class once your pages/features are using your data.
    // This is used by the SampleDataService.
    // It is the model class we use to display data on pages like Grid, Chart, and  ListDetails.
    public class SampleOrder
    {
        public long OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime ShippedDate { get; set; }

        public string ShipperName { get; set; }

        public string ShipperPhone { get; set; }

        public double Freight { get; set; }

        public string Company { get; set; }

        public string ShipTo { get; set; }

        public double OrderTotal { get; set; }

        public string Status { get; set; }

        public char Symbol => (char)SymbolCode;

        public int SymbolCode { get; set; }

        public string SymbolName { get; set; }

        public string Name { get; set; }

        public string Descriptions { get; set; }

        public string NavigatedToName { get; set; }
        public ICollection<SampleOrderDetail> Details { get; set; }

        public override string ToString()
        {
            return $"{Company} {Status}";
        }

        public string ShortDescription => $"Order ID: {OrderID}";
    }
}
