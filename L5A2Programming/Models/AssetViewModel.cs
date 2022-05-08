﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace L5A2Programming.Models
{
    public class AssetViewModel
    {
        public AssetModel Asset { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}