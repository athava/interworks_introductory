#pragma checksum "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\CreateDiscount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b021cb1fe8ab9a8968a9280c6a46c883501af777"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Discount_CreateDiscount), @"mvc.1.0.view", @"/Views/Discount/CreateDiscount.cshtml")]
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
#line 1 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\_ViewImports.cshtml"
using ERP_UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\_ViewImports.cshtml"
using ERP_UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b021cb1fe8ab9a8968a9280c6a46c883501af777", @"/Views/Discount/CreateDiscount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a0d9b07449ef44bf077a604ffc95c39521b7228", @"/Views/_ViewImports.cshtml")]
    public class Views_Discount_CreateDiscount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CreateUpdateDiscountVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\CreateDiscount.cshtml"
  
    ViewBag.Title = "Create Discount";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1 class=\"CHeading\">Create Discount</h1>\r\n<div class=\"ViewDetails\">\r\n");
#nullable restore
#line 8 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\CreateDiscount.cshtml"
     using (Html.BeginForm("CreateDiscount", "Discount", FormMethod.Post, new { id = "create-discount-form" }))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-sm-6 col-md-4 col-lg-3\">\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 13 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\CreateDiscount.cshtml"
               Write(Html.LabelFor(model => model.DiscountName, new { @class = "Required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 14 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\CreateDiscount.cshtml"
               Write(Html.TextBoxFor(model => model.DiscountName, new { @class = "form-control", required = "Required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 15 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\CreateDiscount.cshtml"
               Write(Html.ValidationMessageFor(model => model.DiscountName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div><!-- form-group -->\r\n            </div><!-- col -->\r\n        </div><!-- row -->\r\n        <div class=\"row\">\r\n            <div class=\"col-sm-6 col-md-4 col-lg-3\">\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 22 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\CreateDiscount.cshtml"
               Write(Html.LabelFor(model => model.DiscountType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 23 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\CreateDiscount.cshtml"
               Write(Html.DropDownListFor(model => model.DiscountType, Model.DiscountTypes, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 24 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\CreateDiscount.cshtml"
               Write(Html.ValidationMessageFor(model => model.DiscountType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div><!-- form-group -->\r\n            </div><!-- col -->\r\n        </div><!-- row -->\r\n        <div class=\"row\">\r\n            <div class=\"col-sm-6 col-md-4 col-lg-3\">\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 31 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\CreateDiscount.cshtml"
               Write(Html.LabelFor(model => model.DiscountValue, new { @class = "Required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 32 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\CreateDiscount.cshtml"
               Write(Html.EditorFor(model => model.DiscountValue, new { htmlAttributes = new { @class = "form-control NumInput intMask", type = "text", required = "Required" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 33 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\CreateDiscount.cshtml"
               Write(Html.ValidationMessageFor(model => model.DiscountValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div><!-- form-group -->\r\n            </div><!-- col -->\r\n        </div><!-- row -->\r\n");
            WriteLiteral(@"        <div class=""row"">
            <div class=""col-sm-12 text-right"">
                <div class=""FormBtns"" role=""group"">
                    <button type=""submit"" class=""btn btn-primary"">Save</button>
                    <button type=""button"" class=""btn btn-default"">Cancel</button>
                </div><!-- FormBtns -->
            </div><!--col -->
        </div><!-- row -->
");
#nullable restore
#line 46 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\CreateDiscount.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CreateUpdateDiscountVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
