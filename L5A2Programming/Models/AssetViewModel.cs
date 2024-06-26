﻿//Asset view model
using Microsoft.AspNetCore.Mvc.Rendering;

namespace L5A2Programming.Models
{
    public class AssetViewModel
    {
        public AssetModel Asset { get; set; }

        //For dropdown creation
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Institution { get; set; }
        public IEnumerable<SelectListItem> Room { get; set; }
    }
}