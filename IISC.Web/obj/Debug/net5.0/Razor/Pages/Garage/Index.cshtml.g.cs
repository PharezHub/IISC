#pragma checksum "C:\Program Files\LearningYear\IISC\IISC.Web\Pages\Garage\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "117f6795e6ab3fe9d91cb90d4cb75fd5f922b185"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(IISC.Web.Pages.Garage.Pages_Garage_Index), @"mvc.1.0.razor-page", @"/Pages/Garage/Index.cshtml")]
namespace IISC.Web.Pages.Garage
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
#line 1 "C:\Program Files\LearningYear\IISC\IISC.Web\Pages\_ViewImports.cshtml"
using IISC.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"117f6795e6ab3fe9d91cb90d4cb75fd5f922b185", @"/Pages/Garage/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d710b025a9f7ba9079e72d7b305d4bcc8c4846e8", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Garage_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Program Files\LearningYear\IISC\IISC.Web\Pages\Garage\Index.cshtml"
  
    ViewData["Title"] = "Garage Management System";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-xl-12 col-md-12 col-sm-12"">
        <div class=""row"">
            <div class=""col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12"">
                <div class=""page-header"" id=""top"">
                    <h2 class=""pageheader-title"">");
#nullable restore
#line 12 "C:\Program Files\LearningYear\IISC\IISC.Web\Pages\Garage\Index.cshtml"
                                            Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </h2>
                    <div class=""page-breadcrumb"">
                        <nav aria-label=""breadcrumb"">
                            <ol class=""breadcrumb"">
                                <li class=""breadcrumb-item""><a href=""#"" class=""breadcrumb-link"">Home</a></li>
                                <li class=""breadcrumb-item active"" aria-current=""page"">");
#nullable restore
#line 17 "C:\Program Files\LearningYear\IISC\IISC.Web\Pages\Garage\Index.cshtml"
                                                                                  Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            </ol>\r\n                        </nav>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 26 "C:\Program Files\LearningYear\IISC\IISC.Web\Pages\Garage\Index.cshtml"
                 foreach (var item in Model.SystemAreaList)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-sm-3\">\r\n                        <div class=\"card\">\r\n                            <div class=\"card-header bg-dark text-white text-center\">");
#nullable restore
#line 30 "C:\Program Files\LearningYear\IISC\IISC.Web\Pages\Garage\Index.cshtml"
                                                                               Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"card-body\">\r\n                                <div class=\"text-center\">\r\n                                    <img");
            BeginWriteAttribute("src", " src=", 1395, "", 1415, 1);
#nullable restore
#line 33 "C:\Program Files\LearningYear\IISC\IISC.Web\Pages\Garage\Index.cshtml"
WriteAttributeValue("", 1400, item.ImagePath, 1400, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=", 1415, "", 1431, 1);
#nullable restore
#line 33 "C:\Program Files\LearningYear\IISC\IISC.Web\Pages\Garage\Index.cshtml"
WriteAttributeValue("", 1420, item.Title, 1420, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"rounded-circle bg-light\" />\r\n                                </div>\r\n                                <p class=\"card-text text-center\">");
#nullable restore
#line 35 "C:\Program Files\LearningYear\IISC\IISC.Web\Pages\Garage\Index.cshtml"
                                                            Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</p>\r\n                            </div>\r\n                            <div class=\"card-footer text-center\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 1734, "\"", 1779, 1);
#nullable restore
#line 38 "C:\Program Files\LearningYear\IISC\IISC.Web\Pages\Garage\Index.cshtml"
WriteAttributeValue("", 1741, $"DataCapture/{item.ID.ToString()}", 1741, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-dark\">");
#nullable restore
#line 38 "C:\Program Files\LearningYear\IISC\IISC.Web\Pages\Garage\Index.cshtml"
                                                                                                         Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            </div>\r\n                        </div>\r\n\r\n                        <br />\r\n\r\n                    </div>\r\n");
#nullable restore
#line 45 "C:\Program Files\LearningYear\IISC\IISC.Web\Pages\Garage\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IISC.Web.Pages.Garage.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IISC.Web.Pages.Garage.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IISC.Web.Pages.Garage.IndexModel>)PageContext?.ViewData;
        public IISC.Web.Pages.Garage.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
