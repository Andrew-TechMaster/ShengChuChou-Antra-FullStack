#pragma checksum "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Genre.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ee94929aff2610298a31fa52bea9840c45237e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Genre), @"mvc.1.0.view", @"/Views/Movies/Genre.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ee94929aff2610298a31fa52bea9840c45237e1", @"/Views/Movies/Genre.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6112aabca9b932007558671ce74e32c023ef6c3", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Genre : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ApplicationCore.Models.MoviesByGenreModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n<div>\r\n");
#nullable restore
#line 6 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Genre.cshtml"
     foreach (var item in Model)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Genre.cshtml"
   Write(item.movieTable.Title);

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Genre.cshtml"
   Write(Html.DisplayFor(modelItem => item.movieTable.Title));

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\andre\Antra\dotnet\Project_MovieShop\Andrew\MovieShop_Andrew04_AddMoreForAssignmentOne\MovieShopMVC\Views\Movies\Genre.cshtml"
                                                            
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

<hr />

<nav aria-label=""Page navigation example"">
    <ul class=""pagination"">
        <li class=""page-item""><a class=""page-link"" href=""#"">Previous</a></li>
        <li class=""page-item""><a class=""page-link"" href=""#"">1</a></li>
        <li class=""page-item""><a class=""page-link"" href=""#"">2</a></li>
        <li class=""page-item""><a class=""page-link"" href=""#"">3</a></li>
        <li class=""page-item""><a class=""page-link"" href=""#"">Next</a></li>
    </ul>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ApplicationCore.Models.MoviesByGenreModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
