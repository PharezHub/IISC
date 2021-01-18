using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.AppDbContext;
using Garage.Core.Models;
using Garage.Core.Repository;
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
        private readonly IAssetRepository assetRepository;

        public AddAssetModel(GarageDbContext context, IAssetRepository assetRepository)
        {
            this._context = context;
            this.assetRepository = assetRepository;
        }

        [BindProperty]
        public Hdr_Asset AssetHeader { get; set; }

        [BindProperty]
        public Hdr_StatutoryRequirement  StatutoryRequirement { get; set; }
        [BindProperty]
        public InsuranceViewModel InsuranceVM { get; set; }
        
        [BindProperty]
        public FitnessViewModel FitnessVM { get; set; }

        [BindProperty]
        public RoadTaxViewModel RoadTaxVM { get; set; }
        public List<AssetTypeViewModel> AssetDisplayList { get; set; }
        public List<FuelTypeViewModel> FueltypeList { get; set; }
        public List<CategoryViewModel> CategoryDisplayList { get; set; }
        public List<MakeViewModel> MakeTypeList { get; set; }
        public List<CarModelViewModel> ModelTypeList { get; set; }
        public List<Adm_InsuranceType> InsuranceTypeList { get; set; }
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

        public SelectList ModelInsuranceType()
        {
            InsuranceTypeList = assetRepository.GetInsuranceType();
            SelectList InsuranceList = new SelectList(InsuranceTypeList, nameof(Adm_InsuranceType.ID), nameof(Adm_InsuranceType.InsuranceName));
            return InsuranceList;
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
            AssetHeader.FitnessExpiryDate = FitnessVM.ExpiryDate;
            AssetHeader.RoadTaxExpiryDate = RoadTaxVM.ExpiryDate;
            AssetHeader.InsuranceExpiryDate = InsuranceVM.DateTo;

            _context.Hdr_Asset.Add(AssetHeader);
            await _context.SaveChangesAsync();

            //Post Insurance statutory requirements
            StatutoryRequirement.AssetID = 0;
            StatutoryRequirement.RegNo = AssetHeader.RegNo;
            StatutoryRequirement.ChassisNo = AssetHeader.ChassisNo;
            StatutoryRequirement.StatutoryID = 1;
            StatutoryRequirement.StatutoryAvailable = true;
            StatutoryRequirement.InsuranceTypeID = InsuranceVM.TypeId;
            StatutoryRequirement.InsuranceCompany = InsuranceVM.CompanyName;
            StatutoryRequirement.AmountPaid = InsuranceVM.InsuranceValue;
            StatutoryRequirement.DateFrom = InsuranceVM.DateFrom;
            StatutoryRequirement.DateTo = InsuranceVM.DateTo;
            StatutoryRequirement.DateModified = DateTime.Now;
            StatutoryRequirement.ModifiedBy = User.Identity.Name;

            assetRepository.AddStatutory(StatutoryRequirement);

            //post RoadTax statutory requirements
            StatutoryRequirement.ID = 0;
            StatutoryRequirement.AssetID = 0;
            StatutoryRequirement.RegNo = AssetHeader.RegNo;
            StatutoryRequirement.ChassisNo = AssetHeader.ChassisNo;
            StatutoryRequirement.StatutoryID = 2;
            StatutoryRequirement.StatutoryAvailable = true;
            StatutoryRequirement.InsuranceTypeID = 0;
            StatutoryRequirement.InsuranceCompany = "";
            StatutoryRequirement.AmountPaid = 0;
            StatutoryRequirement.DateFrom = RoadTaxVM.DateRenewed;
            StatutoryRequirement.DateTo = RoadTaxVM.ExpiryDate;
            StatutoryRequirement.DateModified = DateTime.Now;
            StatutoryRequirement.ModifiedBy = User.Identity.Name;

            assetRepository.AddStatutory(StatutoryRequirement);

            //post Fitness statutory requirements
            StatutoryRequirement.ID = 0;
            StatutoryRequirement.AssetID = 0;
            StatutoryRequirement.RegNo = AssetHeader.RegNo;
            StatutoryRequirement.ChassisNo = AssetHeader.ChassisNo;
            StatutoryRequirement.StatutoryID = 3;
            StatutoryRequirement.StatutoryAvailable = true;
            StatutoryRequirement.InsuranceTypeID = 0;
            StatutoryRequirement.InsuranceCompany = "";
            StatutoryRequirement.AmountPaid = 0;
            StatutoryRequirement.DateFrom = FitnessVM.DateRenewed;
            StatutoryRequirement.DateTo = FitnessVM.ExpiryDate;
            StatutoryRequirement.DateModified = DateTime.Now;
            StatutoryRequirement.ModifiedBy = User.Identity.Name;

            assetRepository.AddStatutory(StatutoryRequirement);

            return RedirectToPage("/Garage/Asset/Index");
        }
    }
}
