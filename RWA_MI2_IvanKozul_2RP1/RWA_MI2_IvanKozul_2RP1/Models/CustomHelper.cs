using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_MI2_IvanKozul_2RP1.Models
{
    public static class CustomHelper
    {
        public static MvcHtmlString DDLGradovi(this HtmlHelper html, List<Grad> kolekcijaGradova)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "GradID");
            selectTag.MergeAttribute("name", "GradID");
            foreach (Grad grad in kolekcijaGradova)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", grad.IDGrad.ToString());
                optionTag.SetInnerText(grad.Naziv);
                selectTag.InnerHtml += optionTag.ToString();
            }
            return new MvcHtmlString(selectTag.ToString());
        }
    }
}