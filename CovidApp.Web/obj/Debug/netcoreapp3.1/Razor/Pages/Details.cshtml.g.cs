#pragma checksum "D:\sandbox\CovidApp\CovidApp.Web\Pages\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bcc3f96dcc12d4665d9a43db8dd38fc410322549"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CovidApp.Web.Pages.Pages_Details), @"mvc.1.0.razor-page", @"/Pages/Details.cshtml")]
namespace CovidApp.Web.Pages
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
#line 1 "D:\sandbox\CovidApp\CovidApp.Web\Pages\_ViewImports.cshtml"
using CovidApp.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{id:guid}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcc3f96dcc12d4665d9a43db8dd38fc410322549", @"/Pages/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55fae2c01894a379f8a1ab11653abf7d0f1e1705", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\sandbox\CovidApp\CovidApp.Web\Pages\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<section class=\"col-md-8\">\r\n    <img");
            BeginWriteAttribute("src", " src=\"", 155, "\"", 189, 1);
#nullable restore
#line 10 "D:\sandbox\CovidApp\CovidApp.Web\Pages\Details.cshtml"
WriteAttributeValue("", 161, Model.HospitalPatient.Photo, 161, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\"");
            BeginWriteAttribute("alt", " alt=\"", 211, "\"", 249, 1);
#nullable restore
#line 10 "D:\sandbox\CovidApp\CovidApp.Web\Pages\Details.cshtml"
WriteAttributeValue("", 217, Model.HospitalPatient.FirstName, 217, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n\r\n    <h3>");
#nullable restore
#line 13 "D:\sandbox\CovidApp\CovidApp.Web\Pages\Details.cshtml"
   Write(Model.HospitalPatient.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    <h3>");
#nullable restore
#line 14 "D:\sandbox\CovidApp\CovidApp.Web\Pages\Details.cshtml"
   Write(Model.HospitalPatient.DocumentId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    <h3>");
#nullable restore
#line 15 "D:\sandbox\CovidApp\CovidApp.Web\Pages\Details.cshtml"
   Write(Model.HospitalPatient.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CovidApp.Web.Pages.Details> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CovidApp.Web.Pages.Details> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CovidApp.Web.Pages.Details>)PageContext?.ViewData;
        public CovidApp.Web.Pages.Details Model => ViewData.Model;
    }
}
#pragma warning restore 1591
