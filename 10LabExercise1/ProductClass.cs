using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10LabExercise1
{
    public class ProductClass
    {
        private int _Quantity;
        private double _SellingPrice;
        private string _ProductName, _Category, _ManufacturingDate, _ExpirationDate, _Description;

        public ProductClass(string productName, string category, string mfgDate, string expDate, double price, int quantity, string description)
        {
            this._Quantity = quantity;
            this._SellingPrice = price;
            this._ProductName = productName;
            this._Category = category;
            this._ManufacturingDate = mfgDate;
            this._ExpirationDate = expDate;
            this._Description = description;
        }

        public string productName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this._ProductName = value;
            }
        }

        public string category
        {
            get
            {
                return this._Category;
            }
            set
            {
                this._Category = value;
            }
        }

        public string manufacturingDate
        {
            get
            {
                return this._ManufacturingDate;
            }
            set
            {
                this._ManufacturingDate = value;
            }
        }

        public string expirationDate
        {
            get
            {
                return this._ExpirationDate;
            }
            set
            {
                this._ExpirationDate = value;
            }
        }

        public string description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }

        public int quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                this._Quantity = value;
            }
        }

        public double sellingPrice
        {
            get
            {
                return this._SellingPrice;
            }
            set
            {
                this._SellingPrice = value;
            }
        }
    }

    public class StringFormatException : Exception
    {
        public StringFormatException(string message) : base(message) { }
    }

    public class NumberFormatException : Exception
    {
        public NumberFormatException(string message) : base(message) { }
    }

    public class CurrencyFormatException : Exception
    {
        public CurrencyFormatException(string message) : base(message) { }
    }
}