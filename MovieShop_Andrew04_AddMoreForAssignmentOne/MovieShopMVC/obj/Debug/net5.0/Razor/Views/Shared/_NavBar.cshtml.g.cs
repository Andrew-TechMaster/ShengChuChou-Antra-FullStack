#pragma checksum "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Shared\_NavBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ef50b856702f4dff655d83866b7c95b2861abd2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__NavBar), @"mvc.1.0.view", @"/Views/Shared/_NavBar.cshtml")]
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
#line 1 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\_ViewImports.cshtml"
using MovieShopMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\_ViewImports.cshtml"
using MovieShopMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ef50b856702f4dff655d83866b7c95b2861abd2", @"/Views/Shared/_NavBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6112aabca9b932007558671ce74e32c023ef6c3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__NavBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<nav class=""navbar navbar-expand-lg navbar-dark bg-dark"">
    <div class=""container-fluid"">
        <div class=""navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2"">
            <ul class=""navbar-nav mr-auto"">
                <li class=""nav-item active"">
                    <a class=""nav-link"" href=""#"">MovieShop <i class=""fa fa-film""></i></a>
                </li>
                <li class=""nav-item dropdown"">
                    <a class=""nav-link dropdown-toggle"" href=""#"" id=""navbarDropdown"" role=""button"" data-bs-toggle=""dropdown"" aria-expanded=""false"">
                        GENRES
                    </a>
                    <ul class=""dropdown-menu"" aria-labelledby=""navbarDropdown"">
                        <li><a class=""dropdown-item"" href=""#"">War</a></li>
                        <li><a class=""dropdown-item"" href=""#"">Drama</a></li>
                        <li><hr class=""dropdown-divider""></li>
                        <li><a class=""dropdown-item"" href=""#"">Other...</a></li>
");
            WriteLiteral(@"                    </ul>
                </li>
            </ul>
        </div>
        <div class=""collapse navbar-collapse"" id=""navbarNav"">
            <ul class=""navbar-nav ml-auto"">
                <li class=""nav-item"">
                    <a class=""nav-link active"" href=""#"">Login</a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link active"" href=""#"">Register</a>
                </li>
            </ul>
        </div>
    </div>
</nav>");
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
