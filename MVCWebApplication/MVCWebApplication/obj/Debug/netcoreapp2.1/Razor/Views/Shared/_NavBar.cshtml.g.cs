#pragma checksum "C:\Users\Abhishek\source\repos\MVCWebApplication\MVCWebApplication\Views\Shared\_NavBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa601d75c374bd21d6f567132930cfb3759aab93"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__NavBar), @"mvc.1.0.view", @"/Views/Shared/_NavBar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_NavBar.cshtml", typeof(AspNetCore.Views_Shared__NavBar))]
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
#line 1 "C:\Users\Abhishek\source\repos\MVCWebApplication\MVCWebApplication\Views\_ViewImports.cshtml"
using MVCWebApplication;

#line default
#line hidden
#line 2 "C:\Users\Abhishek\source\repos\MVCWebApplication\MVCWebApplication\Views\_ViewImports.cshtml"
using MVCWebApplication.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa601d75c374bd21d6f567132930cfb3759aab93", @"/Views/Shared/_NavBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a16c62ac1320638a74811ada48eb19a2fb618f45", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__NavBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 403, true);
            WriteLiteral(@"<div class=""navbar navbar-inverse navbar-fixed-top"">
    <div class=""container"">
        <div class=""navbar-header"">
            <button type=""button"" class=""navbar-toggle"" data-toggle=""collapse"" data-target="".navbar-collapse"">
                <span class=""icon-bar""></span>
                <span class=""icon-bar""></span>
                <span class=""icon-bar""></span>
            </button>
            ");
            EndContext();
            BeginContext(404, 102, false);
#line 9 "C:\Users\Abhishek\source\repos\MVCWebApplication\MVCWebApplication\Views\Shared\_NavBar.cshtml"
       Write(Html.ActionLink("My-Application", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" }));

#line default
#line hidden
            EndContext();
            BeginContext(506, 123, true);
            WriteLiteral("\n        </div>\n        <div class=\"navbar-collapse collapse\">\n            <ul class=\"nav navbar-nav\">\n                <li>");
            EndContext();
            BeginContext(630, 47, false);
#line 13 "C:\Users\Abhishek\source\repos\MVCWebApplication\MVCWebApplication\Views\Shared\_NavBar.cshtml"
               Write(Html.ActionLink("New Rental", "New", "Rentals"));

#line default
#line hidden
            EndContext();
            BeginContext(677, 26, true);
            WriteLiteral("</li>\n                <li>");
            EndContext();
            BeginContext(704, 50, false);
#line 14 "C:\Users\Abhishek\source\repos\MVCWebApplication\MVCWebApplication\Views\Shared\_NavBar.cshtml"
               Write(Html.ActionLink("Customers", "Index", "Customers"));

#line default
#line hidden
            EndContext();
            BeginContext(754, 26, true);
            WriteLiteral("</li>\n                <li>");
            EndContext();
            BeginContext(781, 44, false);
#line 15 "C:\Users\Abhishek\source\repos\MVCWebApplication\MVCWebApplication\Views\Shared\_NavBar.cshtml"
               Write(Html.ActionLink("Movies", "Index", "Movies"));

#line default
#line hidden
            EndContext();
            BeginContext(825, 36, true);
            WriteLiteral("</li>\n            </ul>\n            ");
            EndContext();
            BeginContext(862, 29, false);
#line 17 "C:\Users\Abhishek\source\repos\MVCWebApplication\MVCWebApplication\Views\Shared\_NavBar.cshtml"
       Write(Html.Partial("_LoginPartial"));

#line default
#line hidden
            EndContext();
            BeginContext(891, 36, true);
            WriteLiteral("\n        </div>\n    </div>\n</div>\n\n\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
