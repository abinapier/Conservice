#pragma checksum "/Users/abinapier/Projects/ConserviceHRSite/ConserviceHRSite/Views/Employee/Reporting.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "593654314ae8dcccf380c47976acf1bb7b0322fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Reporting), @"mvc.1.0.view", @"/Views/Employee/Reporting.cshtml")]
namespace AspNetCore
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
#line 1 "/Users/abinapier/Projects/ConserviceHRSite/ConserviceHRSite/Views/_ViewImports.cshtml"
using ConserviceHRSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/abinapier/Projects/ConserviceHRSite/ConserviceHRSite/Views/_ViewImports.cshtml"
using ConserviceHRSite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"593654314ae8dcccf380c47976acf1bb7b0322fd", @"/Views/Employee/Reporting.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"467789d0011fe8765268581ead9e8d5000893973", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Reporting : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ConserviceHRSite.Models.Employee>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/abinapier/Projects/ConserviceHRSite/ConserviceHRSite/Views/Employee/Reporting.cshtml"
   ViewData["Title"] = "Reporting Numbers"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Reporting</h1>\r\n<h3>Weekly Hires:</h3>\r\n<h2 class=\"text-primary\">");
#nullable restore
#line 6 "/Users/abinapier/Projects/ConserviceHRSite/ConserviceHRSite/Views/Employee/Reporting.cshtml"
                    Write(ViewBag.WeeklyHires);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n<h3>Yearly Terminations:</h3>\r\n<h2 class=\"text-primary\">");
#nullable restore
#line 9 "/Users/abinapier/Projects/ConserviceHRSite/ConserviceHRSite/Views/Employee/Reporting.cshtml"
                    Write(ViewBag.YearlyTerminations);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ConserviceHRSite.Models.Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591
