using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Pages
{
    public class TextSizeBase : ComponentBase
    {
        private int size = 25;
        protected string sizeNotatie { get; set; } = "25px";

        protected void MakeBigger()
        {
            size+= 5;
            size = Math.Clamp(size, 5, 100);
            sizeNotatie= size.ToString() + "px";
        }
        protected void MakeSmaller()
        {
            size-=5;
            size = Math.Clamp(size, 5, 100);
            sizeNotatie = size.ToString() + "px";
        }
    }
}
