#pragma checksum "/Users/abinapier/Projects/ConserviceHRSite/ConserviceHRSite/Views/Employee/Permissions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d53ee6ac6fc5bb6bef21e688fbb779c79a1b554"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Permissions), @"mvc.1.0.view", @"/Views/Employee/Permissions.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d53ee6ac6fc5bb6bef21e688fbb779c79a1b554", @"/Views/Employee/Permissions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"467789d0011fe8765268581ead9e8d5000893973", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Permissions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ConserviceHRSite.Models.Employee>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/abinapier/Projects/ConserviceHRSite/ConserviceHRSite/Views/Employee/Permissions.cshtml"
   ViewData["Title"] = "Security Permissions"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    <h1>Permissions</h1>\r\n    <hr />\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    Employee\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 13 "/Users/abinapier/Projects/ConserviceHRSite/ConserviceHRSite/Views/Employee/Permissions.cshtml"
               Write(Html.DisplayNameFor(model => model.Permission));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 19 "/Users/abinapier/Projects/ConserviceHRSite/ConserviceHRSite/Views/Employee/Permissions.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n    <td>\r\n        ");
#nullable restore
#line 23 "/Users/abinapier/Projects/ConserviceHRSite/ConserviceHRSite/Views/Employee/Permissions.cshtml"
   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        ");
#nullable restore
#line 26 "/Users/abinapier/Projects/ConserviceHRSite/ConserviceHRSite/Views/Employee/Permissions.cshtml"
   Write(Html.DisplayFor(modelItem => item.Permission));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n\r\n</tr>");
#nullable restore
#line 29 "/Users/abinapier/Projects/ConserviceHRSite/ConserviceHRSite/Views/Employee/Permissions.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n");
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
