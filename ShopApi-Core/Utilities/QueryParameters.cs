using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApi_Core.Utilities
{
    public class QueryParameters
    {
        const int _maxSize = 100;
        private int _size = 50;

        public int Page { get; set; }

        public int Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = Math.Min(_maxSize, value);
            }
        }

    }
}
