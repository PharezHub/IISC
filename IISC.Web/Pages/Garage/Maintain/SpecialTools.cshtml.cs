using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Maintain
{
    [Authorize(Roles = "admin,asset,fuel,maintenance")]
    public class SpecialToolsModel : PageModel
    {
        private readonly ITransaction transaction;

        public SpecialToolsModel(ITransaction transaction)
        {
            this.transaction = transaction;
            TrnSpecialTools = new TrnSpecialTools();
        }

        [BindProperty]
        public TrnSpecialTools TrnSpecialTools { get; set; }

        public IEnumerable<TrnSpecialTools> SpecialToolsList { get; set; }

        public async Task<IActionResult> OnGet(int Id)
        {
            TrnSpecialTools.MaintenanceID = Id;

            SpecialToolsList = await transaction.GetSpecialTools(Id);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            TrnSpecialTools.TransactionDate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            await transaction.AddSpecialTools(TrnSpecialTools);

            return RedirectToPage("SpecialTools", new { id = TrnSpecialTools.MaintenanceID });
        }
    }
}
