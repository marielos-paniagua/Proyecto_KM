#pragma checksum "C:\Users\casa\source\repos\Proyecto_KM\Proyecto_KM\Views\Buscar\ResultadoBusqueda.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "556fc13b1d225acaeb5072cc44089729be7b374b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Buscar_ResultadoBusqueda), @"mvc.1.0.view", @"/Views/Buscar/ResultadoBusqueda.cshtml")]
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
#line 1 "C:\Users\casa\source\repos\Proyecto_KM\Proyecto_KM\Views\_ViewImports.cshtml"
using Proyecto_KM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\casa\source\repos\Proyecto_KM\Proyecto_KM\Views\_ViewImports.cshtml"
using Proyecto_KM.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"556fc13b1d225acaeb5072cc44089729be7b374b", @"/Views/Buscar/ResultadoBusqueda.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b9d60144c881634a922d9c7017c61ecd18e9f1b", @"/Views/_ViewImports.cshtml")]
    public class Views_Buscar_ResultadoBusqueda : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Proyecto_KM.Models.Task>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<center>\r\n    <div class=\"card border-primary mb-3\" style=\"max-width: 18rem;\">\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-title\">Paciente</h5>\r\n            <p class=\"card-text\">Nombre: ");
#nullable restore
#line 7 "C:\Users\casa\source\repos\Proyecto_KM\Proyecto_KM\Views\Buscar\ResultadoBusqueda.cshtml"
                                    Write(Model.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n        <ul class=\"list-group list-group-flush\">\r\n            <li class=\"list-group-item\">Apellido: ");
#nullable restore
#line 10 "C:\Users\casa\source\repos\Proyecto_KM\Proyecto_KM\Views\Buscar\ResultadoBusqueda.cshtml"
                                             Write(Model.Apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n            <li class=\"list-group-item\">DPI: ");
#nullable restore
#line 11 "C:\Users\casa\source\repos\Proyecto_KM\Proyecto_KM\Views\Buscar\ResultadoBusqueda.cshtml"
                                        Write(Model.DPI);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n            <li class=\"list-group-item\">Fase: ");
#nullable restore
#line 12 "C:\Users\casa\source\repos\Proyecto_KM\Proyecto_KM\Views\Buscar\ResultadoBusqueda.cshtml"
                                         Write(Model.Fase);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
        </ul>
    </div>
</center>


<style>
    .container-fluid {
        display: flex;
        justify-content: center;
        width: 100%;
        height: 88vh;
        background-image: url(""/svg/waves_landing.svg"");
        background-repeat: no-repeat;
        background-size: cover;
    }
</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Proyecto_KM.Models.Task> Html { get; private set; }
    }
}
#pragma warning restore 1591
