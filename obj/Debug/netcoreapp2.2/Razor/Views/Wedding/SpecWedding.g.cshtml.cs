#pragma checksum "C:\Users\tkrec\Downloads\c#\WeddingPlanner\Views\Wedding\SpecWedding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ca2dce5db647269bffd397cef14527ded515de0e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Wedding_SpecWedding), @"mvc.1.0.view", @"/Views/Wedding/SpecWedding.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Wedding/SpecWedding.cshtml", typeof(AspNetCore.Views_Wedding_SpecWedding))]
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
#line 2 "C:\Users\tkrec\Downloads\c#\WeddingPlanner\Views\_ViewImports.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca2dce5db647269bffd397cef14527ded515de0e", @"/Views/Wedding/SpecWedding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"351d227bf48a2430faa5aea2e3670d68c93e08d1", @"/Views/_ViewImports.cshtml")]
    public class Views_Wedding_SpecWedding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(16, 56, true);
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col 6\">\r\n        <h3>");
            EndContext();
            BeginContext(73, 15, false);
#line 4 "C:\Users\tkrec\Downloads\c#\WeddingPlanner\Views\Wedding\SpecWedding.cshtml"
       Write(Model.WedderOne);

#line default
#line hidden
            EndContext();
            BeginContext(88, 5, true);
            WriteLiteral(" and ");
            EndContext();
            BeginContext(94, 15, false);
#line 4 "C:\Users\tkrec\Downloads\c#\WeddingPlanner\Views\Wedding\SpecWedding.cshtml"
                            Write(Model.WedderTwo);

#line default
#line hidden
            EndContext();
            BeginContext(109, 240, true);
            WriteLiteral("\'s Wedding</h3>\r\n    </div>\r\n    <div class=\"col s6 right-align\">\r\n        <a href=\"/dashboard\">Dashboard</a>&nbsp;\r\n        <a href=\"/logout\">Log Out</a>\r\n    </div>\r\n</div>\r\n<div class=\"row\">\r\n    <div class=\"col s12\">\r\n        <h5>Date: ");
            EndContext();
            BeginContext(350, 33, false);
#line 13 "C:\Users\tkrec\Downloads\c#\WeddingPlanner\Views\Wedding\SpecWedding.cshtml"
             Write(Model.Date.ToString("MMM d yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(383, 32, true);
            WriteLiteral("</h5>\r\n        <h5>Guests</h5>\r\n");
            EndContext();
#line 15 "C:\Users\tkrec\Downloads\c#\WeddingPlanner\Views\Wedding\SpecWedding.cshtml"
         foreach(var attending in @Model.Attendees)
        {

#line default
#line hidden
            BeginContext(479, 15, true);
            WriteLiteral("            <p>");
            EndContext();
            BeginContext(495, 28, false);
#line 17 "C:\Users\tkrec\Downloads\c#\WeddingPlanner\Views\Wedding\SpecWedding.cshtml"
          Write(attending.Attendee.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(523, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(525, 27, false);
#line 17 "C:\Users\tkrec\Downloads\c#\WeddingPlanner\Views\Wedding\SpecWedding.cshtml"
                                        Write(attending.Attendee.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(552, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 18 "C:\Users\tkrec\Downloads\c#\WeddingPlanner\Views\Wedding\SpecWedding.cshtml"
        }

#line default
#line hidden
            BeginContext(569, 20, true);
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wedding> Html { get; private set; }
    }
}
#pragma warning restore 1591
