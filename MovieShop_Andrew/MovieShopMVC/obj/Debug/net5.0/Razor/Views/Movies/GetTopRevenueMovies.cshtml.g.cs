#pragma checksum "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew05_revise04to05\MovieShopMVC\Views\Movies\GetTopRevenueMovies.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc9d259f69ae11b8c4bb7b3fc7dce7faf1871f3d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_GetTopRevenueMovies), @"mvc.1.0.view", @"/Views/Movies/GetTopRevenueMovies.cshtml")]
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
#line 1 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew05_revise04to05\MovieShopMVC\Views\_ViewImports.cshtml"
using MovieShopMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew05_revise04to05\MovieShopMVC\Views\_ViewImports.cshtml"
using MovieShopMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc9d259f69ae11b8c4bb7b3fc7dce7faf1871f3d", @"/Views/Movies/GetTopRevenueMovies.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6112aabca9b932007558671ce74e32c023ef6c3", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_GetTopRevenueMovies : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ApplicationCore.Models.MovieCardResponseModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew05_revise04to05\MovieShopMVC\Views\Movies\GetTopRevenueMovies.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<hr />\r\n\r\n");
#nullable restore
#line 10 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew05_revise04to05\MovieShopMVC\Views\Movies\GetTopRevenueMovies.cshtml"
 foreach (var item in Model)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        ");
#nullable restore
#line 14 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew05_revise04to05\MovieShopMVC\Views\Movies\GetTopRevenueMovies.cshtml"
   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 228, "\"", 249, 1);
#nullable restore
#line 17 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew05_revise04to05\MovieShopMVC\Views\Movies\GetTopRevenueMovies.cshtml"
WriteAttributeValue("", 234, item.PosterUrl, 234, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Alternate Text\" />\r\n    </div>\r\n    <div>\r\n        <p>Revenue is: ");
#nullable restore
#line 20 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew05_revise04to05\MovieShopMVC\Views\Movies\GetTopRevenueMovies.cshtml"
                  Write(item.Revenue);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n    </div>\r\n");
#nullable restore
#line 22 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew05_revise04to05\MovieShopMVC\Views\Movies\GetTopRevenueMovies.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ApplicationCore.Models.MovieCardResponseModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591