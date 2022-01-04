using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.ProductForms
{
    using Main;

    class Product
    {
        private int _productBarcode;
        private bool _isWeight;
        private string _productName = "";
        private double _productPrice = 0.0f;
        private int _productAmount = 0;
        private double _productWeight = 0;

        public int ProductBarcode { get => _productBarcode; }
        public bool IsWeight { get => _isWeight; }
        public string ProductName { get => _productName; }
        public double ProductPrice { get => _productPrice; }
        public int ProductAmount { get => _productAmount; set => _productAmount = value; }
        public double ProductWeight { get => _productWeight; set => _productWeight = value; }

        public Product(int barcode)
        {
            _productBarcode = barcode;
            _isWeight = DBHelper.GetProductIsWeight(barcode);
            _productName = DBHelper.GetProductName(barcode);
            _productPrice = DBHelper.GetProductPrice(barcode);
        }
    }
}
