#pragma checksum "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "294495dd384e24d277e4ff1ffd048596e86978b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Details), @"mvc.1.0.view", @"/Views/Movies/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"294495dd384e24d277e4ff1ffd048596e86978b2", @"/Views/Movies/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6112aabca9b932007558671ce74e32c023ef6c3", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationCore.Models.MovieDetailModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Details.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"rounded\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"col-4\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 238, "\"", 266, 1);
#nullable restore
#line 12 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 244, Model.movie.PosterUrl, 244, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Alternate Text\" />\r\n            </div>\r\n            <div class=\"col-4\">\r\n                <p>");
#nullable restore
#line 15 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Details.cshtml"
              Write(Model.movie.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <span class=\"badge badge-pill badge-success\">Rating</span>\r\n                <p>");
#nullable restore
#line 17 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Details.cshtml"
              Write(Model.movie.Overview);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
            </div>
            <div class=""col-4"">
                <button type=""button"" class=""btn btn-primary btn-lg"">Review</button>
                <button type=""button"" class=""btn btn-secondary btn-lg"">Watch Movie</button>
            </div>
        </div>
    </div>
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-3"">
                <h2>Movie Facts</h2>
                <ul class=""list-group"">
                    <li class=""list-group-item"">");
#nullable restore
#line 30 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Details.cshtml"
                                           Write(Model.movie.ReleaseDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\">");
#nullable restore
#line 31 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Details.cshtml"
                                           Write(Model.movie.RunTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\">");
#nullable restore
#line 32 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Details.cshtml"
                                           Write(Model.movie.Revenue);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\">");
#nullable restore
#line 33 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Details.cshtml"
                                           Write(Model.movie.Budget);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\">Some Icon</li>\r\n                </ul>\r\n                <hr />\r\n                <h2>Trailers</h2>\r\n                <ul class=\"list-group\">\r\n");
#nullable restore
#line 39 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Details.cshtml"
                      
                        foreach (var item in Model.trailer.Name)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"list-group-item\">");
#nullable restore
#line 42 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Details.cshtml"
                                                   Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 43 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Details.cshtml"
                        }

                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </div>\r\n            <div class=\"col-9\">\r\n                <h2>Cast</h2>\r\n                <ul class=\"list-group\">\r\n");
#nullable restore
#line 51 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Details.cshtml"
                      
                        foreach (var item in Model.cast.TmdbUrl)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"list-group-item\">");
#nullable restore
#line 54 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Details.cshtml"
                                                   Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 55 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Details.cshtml"
                        }

                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationCore.Models.MovieDetailModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
