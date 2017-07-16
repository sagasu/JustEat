using CodingExercise.Web.RazorHelpers;
using NUnit.Framework;

namespace CodingExercise.Web.Tests.RazorHelpers
{
    [TestFixture]
    public class CustomHelperTests
    {
        [TestCase(1, "foo", "foo")]
        [TestCase(2, "foo", "foos")]
        [TestCase(0, "foo", "foos")]
        public void Pluralize_DependingOnIntegerNumber_CorrectPluralizedFormIsReturned(
            int number, string singularForm, string expectedForm)
        {
            var pluralizeForm = CustomHelpers.Pluralize(null, number, singularForm);
            
            Assert.AreEqual(expectedForm, pluralizeForm.ToString());
        }
        
        [TestCase(1D, "foo", "foo")]
        [TestCase(2D, "foo", "foos")]
        [TestCase(0D, "foo", "foos")]
        [TestCase(1.5D, "foo", "foos")]
        [TestCase(2.5D, "foo", "foos")]
        [TestCase(0.5D, "foo", "foos")]
        public void Pluralize_DependingOnDoubleNumber_CorrectPluralizedFormIsReturned(
            double number, string singularForm, string expectedForm)
        {
            var pluralizeForm = CustomHelpers.Pluralize(null, number, singularForm);
            
            Assert.AreEqual(expectedForm, pluralizeForm.ToString());
        }
    }
}
