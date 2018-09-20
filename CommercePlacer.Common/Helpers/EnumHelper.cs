using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercePlacer.Common.Helpers
{
    public class EnumHelper
    {
        public static List<SelectListItem> GetValuesForWeb(Type type)
        {
            List<SelectListItem> toReturn = new List<SelectListItem>();
            foreach( var val in Enum.GetValues(type))
             {
                toReturn.Add(new SelectListItem(val.ToString(), val.ToString()));
            }
            return toReturn;
        }

    }
}
