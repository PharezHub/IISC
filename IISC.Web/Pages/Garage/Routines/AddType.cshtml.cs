using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Routines
{
    [Authorize(Roles = "admin,asset,maintenance")]
    public class AddTypeModel : BasePageModel
    {
        private readonly ITransaction transaction;

        public AddTypeModel(ITransaction transaction)
        {
            this.transaction = transaction;
        }

        [BindProperty]
        public Adm_MaintenanceType MaintenanceType { get; set; }
        public IEnumerable<Adm_MaintenanceType> MaintenanceList { get; set; }
        
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            MaintenanceList = await transaction.GetMaintenanceType();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (transaction.ValidateMaintenance(MaintenanceType))
                {
                    ErrorMessage = $"Maintenance name *{MaintenanceType.MaintenanceName.Trim()}* already exist!!!";
                }
                else
                {
                    await transaction.AddMaintenanceType(MaintenanceType);

                    //Show Message
                    Notify("Maintenance type added successfully");

                    return RedirectToPage("/Garage/Routines/AddType");
                }
            }

            // Rebind data list
            MaintenanceList = await transaction.GetMaintenanceType();
            return Page();
        }
    }
}
