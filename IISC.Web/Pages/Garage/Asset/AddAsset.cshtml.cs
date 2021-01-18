using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.AppDbContext;
using Garage.Core.Models;
using Garage.Core.ViewModel;
using IISC.Web.Pages.Garage.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace IISC.Web.Pages.Garage.Asset
{
    public class AddAssetModel : PageModel
    {
        public static string constr = Environment.GetEnvironmentVariable("GarageDbConn");
        private readonly GarageDbContext _context;

        public AddAssetModel(GarageDbContext context)
        {
            this._context = context;
        }

        [BindProperty]
        public Hdr_Asset AssetHeader { get; set; }

        [BindProperty]
        public InsuranceViewModel InsuranceVM { get; set; }
        public List<AssetTypeViewModel> AssetDisplayList { get; set; }
        public List<FuelTypeViewModel> FueltypeList { get; set; }
        public List<CategoryViewModel> CategoryDisplayList { get; set; }
        public List<MakeViewModel> MakeTypeList { get; set; }
        public List<CarModelViewModel> ModelTypeList { get; set; }
        public List<ColorViewModel> ColorTypeList { get; set; }

        public SelectList AssetDisplay()
        {
            AssetDisplayList = PopulateAssetType();
            SelectList assetResult = new SelectList(AssetDisplayList, "ID", "AssetType");
            return assetResult;
        }

        private static List<AssetTypeViewModel> PopulateAssetType()
        {
            List<AssetTypeViewModel> assetType = new List<AssetTypeViewModel>();
            assetType.Add(new AssetTypeViewModel
            {
                ID = "0",
                AssetType = "--Select--"
            });

            using (SqlConnection con = new SqlConnection(constr))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "SELECT ID,AssetType FROM Adm_AssetType";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            assetType.Add(new AssetTypeViewModel
                            {
                                ID = sdr[0].ToString(),
                                AssetType = sdr[1].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return assetType;
        }

        private static List<FuelTypeViewModel> populateFuelType()
        {
            List<FuelTypeViewModel> fuelList = new List<FuelTypeViewModel>();
            fuelList.Add(new FuelTypeViewModel
            {
                ID = 0,
                FuelType = "--Select--"
            });
            using (SqlConnection con = new SqlConnection(constr))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                string query = "SELECT ID,FuelName FROM Adm_FuelType";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            fuelList.Add(new FuelTypeViewModel
                            {
                                ID = int.Parse(sdr[0].ToString()),
                                FuelType = sdr[1].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return fuelList;
        }

        public SelectList FuelDisplay()
        {
            FueltypeList = populateFuelType();
            SelectList a = new SelectList(FueltypeList, "ID", "FuelType");

            return a;
        }

        public SelectList CategoryDisplay()
        {

            CategoryDisplayList = PopulateCategoryType();
            SelectList a = new SelectList(CategoryDisplayList, "ID", "CategoryName");
            return a;
        }

        private static List<CategoryViewModel> PopulateCategoryType()
        {
            List<CategoryViewModel> category = new List<CategoryViewModel>();
            category.Add(new CategoryViewModel
            {
                ID = 0,
                CategoryName = "--Select--"
            });
            using (SqlConnection con = new SqlConnection(constr))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                String query = "SELECT ID,CategoryName FROM Adm_AssetCategory";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            category.Add(new CategoryViewModel
                            {

                                ID = int.Parse(sdr[0].ToString()),
                                CategoryName = sdr[1].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return category;
        }

        private static List<MakeViewModel> PopulateMake()
        {
            List<MakeViewModel> status = new List<MakeViewModel>();
            status.Add(new MakeViewModel
            {
                ID = 0,
                Make = "--Select--"
            });

            using (SqlConnection con = new SqlConnection(constr))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "SELECt ID,Make FROM Adm_Make";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            status.Add(new MakeViewModel

                            {
                                ID = int.Parse(sdr[0].ToString()),
                                Make = sdr[1].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return status;
        }

        private static List<CarModelViewModel> PopulateModel()
        {
            List<CarModelViewModel> status = new List<CarModelViewModel>();
            status.Add(new CarModelViewModel
            {
                ID = 0,
                ModelName = "--Select--"
            });

            using (SqlConnection con = new SqlConnection(constr))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "SELECT ID,ModelName FROM Adm_Model";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            status.Add(new CarModelViewModel
                            {
                                ID = int.Parse(sdr[0].ToString()),
                                ModelName = sdr[1].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return status;
        }

        private static List<ColorViewModel> PopulateColor()
        {
            List<ColorViewModel> status = new List<ColorViewModel>();
            status.Add(new ColorViewModel
            {
                ID = 0,
                Color = "--Select--"
            });

            using (SqlConnection con = new SqlConnection(constr))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                String query = "SELECT ID,color FROM Adm_Color";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            status.Add(new ColorViewModel
                            {
                                ID = int.Parse(sdr[0].ToString()),
                                Color = sdr[1].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return status;
        }
        public List<StatusViewModel> StatusTypeList { get; set; }

        public SelectList MakeDisplay()
        {
            MakeTypeList = PopulateMake();
            SelectList makeList = new SelectList(MakeTypeList, "ID", "Make");
            return makeList;
        }

        public SelectList ModelDisplay()
        {
            ModelTypeList = PopulateModel();
            SelectList modelList = new SelectList(ModelTypeList, "ID", "ModelName");
            return modelList;
        }

        public SelectList ColorDisplay()
        {
            ColorTypeList = PopulateColor();
            SelectList colorList = new SelectList(ColorTypeList, "ID", "Color");
            return colorList;
        }

        private static List<StatusViewModel> populateStatus()
        {
            List<StatusViewModel> status = new List<StatusViewModel>();
            status.Add(new StatusViewModel
            {
                ID = 0,
                Status = "--Select--"
            });

            using (SqlConnection con = new SqlConnection(constr))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                String query = "SELECT ID,status FROM Adm_Status";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            status.Add(new StatusViewModel
                            {
                                ID = int.Parse(sdr[0].ToString()),
                                Status = sdr[1].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return status;
        }

        public SelectList StatusDisplay()
        {
            StatusTypeList = populateStatus();
            SelectList statusList = new SelectList(StatusTypeList, "ID", "status");
            return statusList;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Initialize and Post data
            AssetHeader.AssetStatus = 1;
            AssetHeader.CreatedBy = User.Identity.Name;
            AssetHeader.CreatedOn = DateTime.Now;
            AssetHeader.CurrentMileage = AssetHeader.InitialMileage;

            _context.Hdr_Asset.Add(AssetHeader);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Garage/Asset/Index");
        }
    }
}
