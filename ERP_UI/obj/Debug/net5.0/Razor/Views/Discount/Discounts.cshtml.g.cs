#pragma checksum "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\Discounts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b30ac4446cda8e06eec6eb66e0550a523252d999"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Discount_Discounts), @"mvc.1.0.view", @"/Views/Discount/Discounts.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b30ac4446cda8e06eec6eb66e0550a523252d999", @"/Views/Discount/Discounts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a0d9b07449ef44bf077a604ffc95c39521b7228", @"/Views/_ViewImports.cshtml")]
    public class Views_Discount_Discounts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DiscountsVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\Discounts.cshtml"
  
    ViewBag.Title = "Discounts";
    Layout = "_Layout";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class="" d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3"">
    <h2>Discounts</h2>
    <div class=""float-right btn-toolbar mb-2 mb-md-0"">
        <div class=""btn-group me-2"">
            <a type=""button"" class=""btn btn-sm btn-outline-secondary""");
            BeginWriteAttribute("href", " href=\"", 383, "\"", 430, 1);
#nullable restore
#line 12 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\Discounts.cshtml"
WriteAttributeValue("", 390, Url.Action("CreateDiscount","Discount"), 390, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Add Discount</a>
        </div>
    </div>
</div>
<div class=""table-responsive"">
    <table class=""table table-striped table-sm ListTable"">
        <thead>
            <tr>
                <th>Name</th>
                <th>Type</th>
                <th>Value</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 27 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\Discounts.cshtml"
             for (var index = 0; index < Model.Discounts?.Count(); index++)
            {
                var discount = Model.Discounts.ElementAt(index);

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr");
            BeginWriteAttribute("class", " class=\"", 965, "\"", 1002, 1);
#nullable restore
#line 30 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\Discounts.cshtml"
WriteAttributeValue("", 973, index == 0 ? "active" : "", 973, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                    style=\"cursor: pointer\">\r\n                    <td data-label=\"Name\">");
#nullable restore
#line 32 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\Discounts.cshtml"
                                     Write(discount.DiscountName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td data-label=\"Type\">");
#nullable restore
#line 33 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\Discounts.cshtml"
                                     Write(discount.DiscountType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td data-label=\"Value\">");
#nullable restore
#line 34 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\Discounts.cshtml"
                                      Write(discount.DiscountValue);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td data-label=\"Actions\" class=\"LTActions\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\'", 1357, "\'", 1432, 1);
#nullable restore
#line 36 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\Discounts.cshtml"
WriteAttributeValue("", 1364, Url.Action("Discount","Discount", new { discountId = discount.Id }), 1364, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" rel=\"tooltip\" class=\"btn btn-link ActionBtn\"><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></a>\r\n                        <a");
            BeginWriteAttribute("href", " href=\'", 1555, "\'", 1636, 1);
#nullable restore
#line 37 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\Discounts.cshtml"
WriteAttributeValue("", 1562, Url.Action("UpdateDiscount","Discount", new { discountId = discount.Id }), 1562, 74, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" rel=""tooltip"" class=""btn btn-link ActionBtn""><i class=""fa fa-pen"" aria-hidden=""true""></i></a>
                        <button class=""btn btn-link ActionBtn""
                                type=""button""
                                onclick=""openDeleteModal(this)""
                                rel=""tooltip""
                                data-discount-id=""");
#nullable restore
#line 42 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\Discounts.cshtml"
                                             Write(discount.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            <i class=\"fa fa-trash\" aria-hidden=\"true\"></i>\r\n                        </button>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 47 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\Discounts.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    <p>\r\n        Total Discounts : ");
#nullable restore
#line 51 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\Discounts.cshtml"
                     Write(Model.Discounts?.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </p>
</div>


<inpt class=""hidden"" id=""discount-id""></inpt>
<!-- Delete Modal-->
<div class=""modal"" id=""delete-modal"" role=""dialog"" aria-labelledby=""insert-modal-title"" data-backdrop=""static"" data-keyboard=""false"">
    <div class=""modal-dialog modal-md"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <div class=""modal-title"">Delete Discount</div>
            </div><!-- modal-header -->

            <div class=""modal-body"">
                Are you sure you want to delete this discount?
            </div>

            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-primary"" onclick=""deleteDiscount()"">Yes</button>
                <button type=""button"" class=""btn btn-default"" onclick=""closeModal()"">No</button>
            </div><!-- modal-footer -->
        </div>
    </div>
</div>
<!-- /Delete Modal-->

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        const deleteDiscountUrl = \'");
#nullable restore
#line 81 "C:\Users\dona\source\repos\interworks_app\ERP_UI\Views\Discount\Discounts.cshtml"
                              Write(Url.Action("DeleteDiscount", "Discount"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';

        function openDeleteModal(element) {
            const discountId = $(element).data(""discount-id"");
            $(""#delete-modal"").data(""discount-id"", discountId);
            $(""#discount-id"").val(discountId);
            $(""#delete-modal"").modal();
        }

        function deleteDiscount() {
            const selectedDiscountId = $(""#discount-id"").val();
            if (selectedDiscountId) {
                $.post(deleteDiscountUrl + '?discountId=' + selectedDiscountId, function () {
                    location.reload();
                });
            }
        }

        function closeModal() {
            $(""#delete-modal"").modal('hide');
        }

    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DiscountsVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
