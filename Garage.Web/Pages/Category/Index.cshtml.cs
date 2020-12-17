using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Garage.Web.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryRepository categoryRepository;

        public IndexModel(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void OnGet()
        {
        }
    }
}
