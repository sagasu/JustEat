using System.Web.Mvc;

namespace CodingExercise.Web.RazorHelpers
{
    public static class CustomHelpers
    {
        public static MvcHtmlString Pluralize(this HtmlHelper htmlHelper,
            int number, string singularForm)
        {
            var formatedForm = number == 1 ? singularForm : singularForm + "s";

            return MvcHtmlString.Create(formatedForm);
        }

        public static MvcHtmlString Pluralize(this HtmlHelper htmlHelper,
            double number, string singularForm)
        {
            var formatedForm = number == 1D ? singularForm : singularForm + "s";

            return MvcHtmlString.Create(formatedForm);
        }
    }
}