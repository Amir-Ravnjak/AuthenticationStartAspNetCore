#pragma checksum "C:\Users\amirr\source\repos\AuthenticationStartAspNetCore\AuthenticationStartAspNetCore\Views\Authentication\Registration.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf8537ba537cb2832d602dbd27012997849d70f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Authentication_Registration), @"mvc.1.0.view", @"/Views/Authentication/Registration.cshtml")]
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
#line 1 "C:\Users\amirr\source\repos\AuthenticationStartAspNetCore\AuthenticationStartAspNetCore\Views\_ViewImports.cshtml"
using AuthenticationStartAspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\amirr\source\repos\AuthenticationStartAspNetCore\AuthenticationStartAspNetCore\Views\_ViewImports.cshtml"
using AuthenticationStartAspNetCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf8537ba537cb2832d602dbd27012997849d70f2", @"/Views/Authentication/Registration.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42d4420a470226f0bd40425145ed6226a670b89c", @"/Views/_ViewImports.cshtml")]
    public class Views_Authentication_Registration : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-signin"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Authentication/Registration"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\amirr\source\repos\AuthenticationStartAspNetCore\AuthenticationStartAspNetCore\Views\Authentication\Registration.cshtml"
  
    string message = (string)TempData["message"];

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container\">\r\n        <h2>Registracija korisnika</h2>\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf8537ba537cb2832d602dbd27012997849d70f24799", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\amirr\source\repos\AuthenticationStartAspNetCore\AuthenticationStartAspNetCore\Views\Authentication\Registration.cshtml"
             if (message != null)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <h5 class=\"alert alert-danger\">");
#nullable restore
#line 10 "C:\Users\amirr\source\repos\AuthenticationStartAspNetCore\AuthenticationStartAspNetCore\Views\Authentication\Registration.cshtml"
                                          Write(message);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n");
#nullable restore
#line 11 "C:\Users\amirr\source\repos\AuthenticationStartAspNetCore\AuthenticationStartAspNetCore\Views\Authentication\Registration.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("            <label for=\"username\">Korisni??ko ime</label>\r\n            ");
#nullable restore
#line 13 "C:\Users\amirr\source\repos\AuthenticationStartAspNetCore\AuthenticationStartAspNetCore\Views\Authentication\Registration.cshtml"
       Write(Html.ValidationMessage("Username"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <input type=\"text\" autocomplete=\"new-password\" name=\"username\" id=\"username\" class=\"form-control\" placeholder=\"Korisni??ko ime\" autofocus />\r\n            <label for=\"password\">Lozinka</label>\r\n            ");
#nullable restore
#line 16 "C:\Users\amirr\source\repos\AuthenticationStartAspNetCore\AuthenticationStartAspNetCore\Views\Authentication\Registration.cshtml"
       Write(Html.ValidationMessage("Password"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            <input type=""password"" autocomplete=""new-password"" name=""password"" id=""password"" class=""form-control"" placeholder=""Lozinka"" />
                        
            <label for=""firstName"">Ime</label>
            <input type=""text"" name=""firstName"" id=""firstName"" class=""form-control"" placeholder=""Ime"" />
            <label for=""lastName"">Prezime</label>
            <input type=""text"" name=""lastName"" id=""lastName"" class=""form-control"" placeholder=""Prezime"" />
            <label for=""dateOfBirth"">Email</label>
            <input type=""email"" name=""email"" id=""email"" class=""form-control"" placeholder=""E-mail"" />
            <label for=""mobileNumber"">Broj telefona</label>
            <input type=""text"" name=""mobileNumber"" class=""form-control"" placeholder=""Broj telefona"" />
            <br />
            <input type=""submit"" class=""btn btn-primary"" style=""min-width:7rem;"" value=""Snimi"" />
            <a href=""/Home/Login"" class=""btn btn-danger"" style=""min-width:7rem;"">Nazad</a>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <br />\r\n        <br />\r\n\r\n\r\n    </div>\r\n\r\n<style>\r\n\r\n    .field-validation-error {\r\n        color: red;\r\n        display: block;\r\n    }\r\n\r\n</style>\r\n\r\n\r\n");
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
