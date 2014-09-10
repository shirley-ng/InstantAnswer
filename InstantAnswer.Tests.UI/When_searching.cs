using NUnit.Framework;
using OpenQA.Selenium.Firefox;

namespace InstantAnswer.Tests.UI
{
    [TestFixture]
    public class When_searching
    {
        [Test]
        public void Should_foo()
        {
            int someVal = 2 * 10;

            Assert.IsTrue(someVal == 20);
            Assert.That(someVal == 20);
            Assert.That(someVal, Is.True);
        }

        [Test]
        public void Should_display_answer_if_search_term_is_valid()
        {
            using (var driver = new FirefoxDriver())
            {
                var searchPage = new SearchPage(driver);
                searchPage.NavigateTo();

                searchPage.Search("socks cat");

                Assert.That(searchPage.IsAnswerDisplayed(), Is.True);
            }
        }

        [Test]
        public void Should_not_display_answer_if_search_term_is_invalid()
        {
            using (var driver = new FirefoxDriver())
            {
                var searchPage = new SearchPage(driver);
                searchPage.NavigateTo();

                searchPage.Search("socks cato");

                Assert.That(searchPage.IsAnswerDisplayed(), Is.False);
            }
        }

        [Test]
        public void Should_not_display_answer_if_search_term_is_blank()
        {
            using (var driver = new FirefoxDriver())
            {
                var searchPage = new SearchPage(driver);
                searchPage.NavigateTo();

                searchPage.Search("      ");

                Assert.That(searchPage.IsAnswerDisplayed(), Is.False);
            }
        }
    }
}