using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductClass
{
    internal class Product
    {
        private int PrivateProductId;
        private string PrivateName;
        private DateTime PrivateMfgDate;
        private int PrivateWarranty;
        private decimal PrivatePrice;
        private int PrivateStock;
        private decimal PrivateDiscount;
        private int PrivateGST;

        public int ProductId
        {
            get
            {
                return PrivateProductId;
            }
            set
            {
                if (value > 0)
                    PrivateProductId = value;
                else
                    throw new Exception("Invalid Employee ID");
            }
        }
              

        public string ProductName
        {
            get { return PrivateName; }
            set
            {
                if (value.Length>3)
                {
                    PrivateName = value;
                }
                else
                {
                    throw new Exception("Invalid Name");
                }
            }
        }

        public DateTime MfgDate
        {
            get { return PrivateMfgDate; }
            set
            {
                if (value <= DateTime.Now)
                {
                    PrivateMfgDate = value;
                }
                else
                {
                    throw new Exception("Invalid Date");
                }
            }
        }

        public int Warranty
        {
            get { return PrivateWarranty; }
            set { PrivateWarranty = value; }
        }

        public decimal Price
        {
            get { return PrivatePrice; }
            set
            {
                if (value > 0)
                {
                    PrivatePrice = value;
                }
                else
                {
                    throw new Exception("Invalid Price");
                }
            }
        }

        public int Stock
        {
            get { return PrivateStock; }
            set
            {
                if (value >= 0)
                {
                    PrivateStock = value;
                }
                else
                {
                    throw new Exception("Invalid Stock");
                }
            }
        }

        public int GST
        {
            get { return PrivateGST; }
            set
            {
                List<int> AllowedGstValues = new List<int>([5,12,18,28]);
                if (AllowedGstValues.Contains(value))
                {
                    PrivateGST = value;
                }
                else
                {
                    throw new Exception("Invalid GST Value");
                }
            }
        }

        public decimal Discount
        {
            get { return PrivateDiscount; }
            set
            {
                if (value >= 0 && value <= 30)
                {
                    PrivateDiscount = value;
                }
                else
                {
                    throw new Exception("Invalid Discount");
                }
            }
        }

        private decimal TaxPrice, DiscountPrice;
        public string Display()
        {
            TaxPrice = Price * (1 + GST / 100);
            DiscountPrice = TaxPrice * (1-Discount/100);

            StringBuilder Details = new StringBuilder();
            Details.Append("Id: " + ProductId + "\n");
            Details.Append("Name: " + ProductName + "\n");
            Details.Append("Manufacturing Date: " + MfgDate.ToShortDateString() + "\n");
            Details.Append("Warranty: " + Warranty + " months\n");
            Details.Append("Tax Price: " + TaxPrice.ToString() + "\n");
            Details.Append("Stock: " + Stock + "\n");
            Details.Append("Discount Price: " + DiscountPrice.ToString() + "\n");

            return Details.ToString();
        }


    }


}
