﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DiveLogBook.Shared.Models.DiveInfo
{
    public class DiveDropdownData
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Value { get; set; }
    }
}
