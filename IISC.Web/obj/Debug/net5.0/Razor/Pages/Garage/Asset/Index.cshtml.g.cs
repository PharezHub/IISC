#pragma checksum "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "344f311fdc990383d455c3a9df328f138ff74967"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(IISC.Web.Pages.Garage.Asset.Pages_Garage_Asset_Index), @"mvc.1.0.razor-page", @"/Pages/Garage/Asset/Index.cshtml")]
namespace IISC.Web.Pages.Garage.Asset
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\_ViewImports.cshtml"
using IISC.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"344f311fdc990383d455c3a9df328f138ff74967", @"/Pages/Garage/Asset/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d710b025a9f7ba9079e72d7b305d4bcc8c4846e8", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Garage_Asset_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Garage/Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("breadcrumb-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("View asset details"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
  
    ViewData["Title"] = "Asset Catalogue";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-xl-10\">\r\n        <div class=\"row\">\r\n            <div class=\"col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12\">\r\n                <div class=\"page-header\" id=\"top\">\r\n                    <h2 class=\"pageheader-title\">");
#nullable restore
#line 12 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                            Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </h2>
                    <div class=""page-breadcrumb"">
                        <nav aria-label=""breadcrumb"">
                            <ol class=""breadcrumb"">
                                <li class=""breadcrumb-item""><a href=""#"" class=""breadcrumb-link"">Home</a></li>
                                <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "344f311fdc990383d455c3a9df328f138ff749675035", async() => {
                WriteLiteral("Garage Management System");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                                <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 18 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                                                                  Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                            </ol>
                        </nav>
                    </div>
                </div>
            </div>
        </div>

        <div class=""row"">
            <div class=""col-lg-12 col-md-12 col-sm-12 col-12"">
                <div class=""card"">
                    <h5 class=""card-header"">Asset List</h5>
                    <div class=""card-body p-0"">
                        <div class=""table-responsive"">
                            <table class=""table"">
                                <thead class=""bg-light"">
                                    <tr class=""border-0"">
                                        <th class=""border-0"">#</th>
                                        <th class=""border-0"">Type</th>
                                        <th class=""border-0"">Category</th>
                                        <th class=""border-0"">Reg No</th>
                                        <th class=""border-0"">Make</th>
                                    ");
            WriteLiteral(@"    <th class=""border-0"">Model</th>
                                        <th class=""border-0"">Fuel</th>
                                        <th class=""border-0"">Year</th>
                                        <th class=""border-0"">Status</th>
                                        <th class=""border-0""> </th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 48 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                     foreach (var item in Model.AssetCatalogueList)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 51 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                       Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 52 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                       Write(item.AssetType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 53 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                       Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 54 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                       Write(item.RegNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 55 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                       Write(item.MakeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 56 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                       Write(item.ModelName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 57 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                       Write(item.FuelName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 58 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                       Write(item.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n");
#nullable restore
#line 60 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                             if (@item.StatusID == 1)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"badge-dot badge-success mr-1\"></span>");
#nullable restore
#line 62 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                                                                             Write(item.Status);

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                                                                                              
                                            }
                                            else if (@item.StatusID == 2)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"badge-dot badge-brand mr-1\"></span>");
#nullable restore
#line 66 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                                                                           Write(item.Status);

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                                                                                            
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"badge-dot badge-danger mr-1\"></span>");
#nullable restore
#line 70 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                                                                            Write(item.Status);

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                                                                                             
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </td>\r\n                                        <td>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "344f311fdc990383d455c3a9df328f138ff7496713876", async() => {
                WriteLiteral("View");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
            WriteLiteral("Garage/Asset/EditAsset/");
#nullable restore
#line 74 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                                                    WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 77 "C:\Users\ykatambo\source\repos\IISC\IISC.Web\Pages\Garage\Asset\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class=""card-footer p-0""></div>
                </div>
            </div>
        </div>
    </div>

    <!-- sidenavbar -->
    <div class=""col-xl-2 col-lg-2 col-md-6 col-sm-12 col-12"">
        <div class=""sidebar-nav-fixed"">
            <ul class=""list-unstyled"">
                <li><a href=""#overview"" class=""active"">Overview</a></li>
                <li><a href=""#top"">Back to Top</a></li>
            </ul>
        </div>
    </div>
    <!-- end sidenavbar -->
</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IISC.Web.Pages.Garage.Asset.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IISC.Web.Pages.Garage.Asset.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IISC.Web.Pages.Garage.Asset.IndexModel>)PageContext?.ViewData;
        public IISC.Web.Pages.Garage.Asset.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591