#pragma checksum "C:\Yann\Learning\CSharp\IISC\Garage.Web\Pages\Shared\NotFound.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "799063f7291c87dc9a455b8b97c3bfbcaa55fbc7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Garage.Web.Pages.Shared.Pages_Shared_NotFound), @"mvc.1.0.razor-page", @"/Pages/Shared/NotFound.cshtml")]
namespace Garage.Web.Pages.Shared
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
#line 1 "C:\Yann\Learning\CSharp\IISC\Garage.Web\Pages\_ViewImports.cshtml"
using Garage.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Yann\Learning\CSharp\IISC\Garage.Web\Pages\_ViewImports.cshtml"
using Garage.Core.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"799063f7291c87dc9a455b8b97c3bfbcaa55fbc7", @"/Pages/Shared/NotFound.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd211a7f66f973599132e98b1a60dbd9ed4b4fd7", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_NotFound : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Yann\Learning\CSharp\IISC\Garage.Web\Pages\Shared\NotFound.cshtml"
  
    ViewData["Title"] = "Not Found";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container container-fluid\">\r\n    <div class=\"alert alert-warning\">\r\n        <p>Record not found, contact system administator</p>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Garage.Web.Pages.Shared.NotFoundModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Garage.Web.Pages.Shared.NotFoundModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Garage.Web.Pages.Shared.NotFoundModel>)PageContext?.ViewData;
        public Garage.Web.Pages.Shared.NotFoundModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
