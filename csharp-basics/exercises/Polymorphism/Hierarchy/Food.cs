﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hierarchy
{
    abstract class Food
    {
        public int foodQuantity { get; set; }

        public Food(int foodQuantity)
        {
            this.foodQuantity = foodQuantity;
        }
    }
}
