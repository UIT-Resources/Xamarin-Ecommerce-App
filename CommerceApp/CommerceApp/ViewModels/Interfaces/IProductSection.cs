using System;
using System.Collections.Generic;
using System.Text;
using CommerceApp.Models;

namespace CommerceApp.ViewModels.Interfaces
{
    public interface IProductSection
    {
        Category category { get; set; }
        Product products { get; set; }
    }
}
