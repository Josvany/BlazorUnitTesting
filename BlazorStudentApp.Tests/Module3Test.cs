using Bunit;

namespace BlazorStudentApp.Tests
{
    public class Module3Test
    {
        [Fact]
        public void Basic_Markup_IndexComponentRendersCorrectly_Test()
        {
            using var ctx = new TestContext();

            var renderedComponent = ctx.RenderComponent<Pages.Index>();

            renderedComponent.MarkupMatches("<h1>Welcome to our school</h1>\r\n<p>This is the official page to manage students of our School.</p>");

        }

        [Fact]
        public void DOM_Markup_IndexComponentRendersCorrectly_Test()
        {
            using var ctx = new TestContext();

            var renderedComponent = ctx.RenderComponent<Pages.Index>();

            var h1Element = renderedComponent.Find("h1");

            h1Element.MarkupMatches("<h1>Welcome to our school</h1");



            var pElement = renderedComponent.Find("p");

            pElement.MarkupMatches("<p>This is the official page to manage students of our School.</p>");


        }
    }
}