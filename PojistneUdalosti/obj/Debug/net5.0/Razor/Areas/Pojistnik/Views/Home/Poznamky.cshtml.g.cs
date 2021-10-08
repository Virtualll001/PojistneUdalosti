#pragma checksum "C:\Users\lonet\source\repos\PojistneUdalosti\PojistneUdalosti\Areas\Pojistnik\Views\Home\Poznamky.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0940775be52e315292f564cbde7eb52161935ea3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Pojistnik_Views_Home_Poznamky), @"mvc.1.0.view", @"/Areas/Pojistnik/Views/Home/Poznamky.cshtml")]
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
#line 1 "C:\Users\lonet\source\repos\PojistneUdalosti\PojistneUdalosti\Areas\Pojistnik\Views\_ViewImports.cshtml"
using PojistneUdalosti;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lonet\source\repos\PojistneUdalosti\PojistneUdalosti\Areas\Pojistnik\Views\_ViewImports.cshtml"
using PojistneUdalosti.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0940775be52e315292f564cbde7eb52161935ea3", @"/Areas/Pojistnik/Views/Home/Poznamky.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"103e31100eb9daa81e05f17ce378b49b2baca233", @"/Areas/Pojistnik/Views/_ViewImports.cshtml")]
    public class Areas_Pojistnik_Views_Home_Poznamky : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\lonet\source\repos\PojistneUdalosti\PojistneUdalosti\Areas\Pojistnik\Views\Home\Poznamky.cshtml"
  
    ViewData["Title"] = "O projektu";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""text-center"">
    <h1 class=""display-4"">Pojistné události</h1>
    <h4 class=""text-primary"">ASP.NET Core MVC</h4>
</div>
<br />
<h2 class=""text-primary"">Zadání</h2>
<ul>
    <li>Aplikace obsahuje kompletní správu (CRUD) pojištěných (např. ""Jan Novák"") a jejich pojištění (např. ""pojištění bytu""):</li>
    <li>Vytvoření pojištěného</li>
    <li>Vytvoření pojištění</li>
    <li>Zobrazení detailu pojištěného včetně jeho pojištění</li>
    <li>Zobrazení detailu pojištění</li>
    <li>Zobrazení seznamu pojištěných</li>
    <li>Odstranění pojištěného včetně všech jeho pojištění</li>
    <li>Odstranění pojištění</li>
    <li>Editace pojištěného</li>
    <li>Editace pojištění pojištěného</li>
    <li>Dané entity jsou uloženy v SQL databázi</li>
    <li>Aplikace je naprogramována podle dobrých praktik a je plně responzivní</li>
</ul>
<h5 class=""text-white"">Rozšíření</h5>
<ul>
    <li>Aplikace podporuje uživatelské role (pojištěný, administrátor), návrh a implementace, kdo vidí a může e");
            WriteLiteral(@"ditovat jaká data</li>
    <li>Aplikace eviduje pojistné události pojištěných, rovněž pomocí kompletní správy (CRUD)</li>
</ul>
<br />

<h2 class=""text-primary"">Použité zdroje</h2>
<ul>
    <li>
        Ikony <a href=""https://fontawesome.com/v6.0/icons?s=solid%2Cbrands"" target=""_blank"">FontAwesome</a>
    </li>
    <li>
        Bootstrap styling <a href=""https://bootswatch.com/superhero/"" target=""_blank"">Bootswatch</a>
    </li>
    <li>
        JavaScriptové hlášky <a href=""https://codeseven.github.io/toastr/"" target=""_blank"">Toastr</a>
    </li>
    <li>
        Vyskakovací okna <a href=""https://sweetalert.js.org/"">SweetAlert</a>
    </li>
    <li>
        Tabulky <a href=""https://datatables.net/examples/index"" target=""_blank"">DataTables</a>
    </li>
    <li>
        Textový (WYSIWYG) editor <a href=""https://www.tiny.cloud"" target=""_blank"">TinyMCE</a>
    </li>
    <li>
        Info k ASP.NET Core MVC <a href=""https://www.udemy.com/course/complete-aspnet-core-21-course/"" target=""_");
            WriteLiteral(@"blank"">Udemy tutorial</a><br />
    </li>
</ul>
<br />

<h2 class=""text-primary"">Tvorba projektu</h2>
<p>Postup viz <a href=""https://github.com/Virtualll001/PojistneUdalosti/commits/main"" target=""_blank"">GitHub commits</a></p>
<br />


<h2 class=""text-primary"">Problémy</h2>
<strong class=""text-danger"">Nefunkční scaffolding na Controlleru</strong>
<br />
<ul>
    <li>Chybová hláška: <q>There was an error running the selected code generator: ‚Package restore failed.Rolling back package changes for...</q></li>
    <li>
        Kontrola a aktualizace všech NuGetů. (nepomohlo)
    </li>
    <li>
        Restart s vymaznáním souboru .vs (nepomohl)
    </li>
    <li>
        Přeinstalování nugetu: Microsoft.VisualStudio.Web.CodeGeneration.Design (nepomohlo)
    </li>
    <li>
        Vymazání Nuget Cache (nepomohlo)
    </li>
</ul>

<strong class=""text-danger"">Změna formátu DataTable</strong>
<br />
<ul>
    <li>Problémy s úpravou barev a úpravou jazkové verze textu</li>
    <li>
  ");
            WriteLiteral(@"      Dočasné řešení = obejít se bez DataTables;
    </li>
</ul>

<strong class=""text-danger"">Chybové hlášky v AJ</strong>
<br />
<ul>
    <li>
        Nejdou mi přepsat frontendové validace do češtiny.
    </li>
    <li>
        Do češtiny jsem přeložila hlášky v souborech: jquery.validate.js; jquery.validate.min.js, ale na hlášky při tvorbě tabulek to nemá vliv...
    </li>
</ul>

<strong class=""text-danger"">Problémy s databází</strong>
<br />
<ul>
    <li>
        Chybová hláška: Your SQL Server installation is either corrupt or has been tampered with (Unable to load SQLBOOT.DLL)...
    </li>
</ul>

<strong class=""text-muted"">Problém s responzibilitou u delších tabulek</strong>
<br />
<ul>
    <li>Zobrazovat jen nejdůležitější data nebo zobrazit jiným typem tabulky...</li>
</ul>

<strong class=""text-muted"">Ajax errory</strong>
<br />
<ul>
    <li>Chybové hlášky: <q>DataTables warning: table id=tblData - Ajax error. For more information about this error, please see http://dat");
            WriteLiteral("atables.net/tn/7 </q></li>\r\n    <li>\r\n        Obvykle nalezena chyba v JS kódu...\r\n    </li>\r\n</ul>\r\n<br />\r\n<br />\r\n<br />\r\n\r\n");
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