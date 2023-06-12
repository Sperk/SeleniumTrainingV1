using SeleniumTrainingPages;
using System.IO;

namespace SeleniumTraining;

internal class SeleniumTests : BaseTest
{
    // private IWebDriver driver;
    private HomePage homePage;
    int millisecondsToSleep = 3000;
    string homepageUrl = "https://dlapiper.sharepoint.com/sites/intranet";
    string expectedHomePageTitle = "Pulse - Intranet Home";
    string expectedOurFirmPageTitle = "Our Firm - The Firm";
    string resultsDir = "C:\\SeleniumScreenshots\\Results-";
    string today = DateTime.Now.ToString("ddMMyyyy");

    [OneTimeSetUp]
      public void OneTime()
      {
            // Create results directory if it doesn't already exist
        if (!Directory.Exists(resultsDir + today));
        {
            Directory.CreateDirectory(resultsDir + today);
        }
      }
        
    [SetUp]
      public void TestSetUp()
      {
        homePage = new HomePage(GetDriver());
      }

    [Test]
    [Category("Smoke")]
    public void NavToHomepage()
    {
        // Start Edge Session nav to Intranet
        GetDriver().Url = homepageUrl;
        GetDriver().Manage().Window.Maximize();
        Helpers.Helpers.Pause(millisecondsToSleep);
        // Get page title
        string pageTitle = GetDriver().Title;

        // Assert page title is as expected
        Assert.AreEqual(expectedHomePageTitle,pageTitle);

        // Take a screenshot
        Screenshot ss = ((ITakesScreenshot)GetDriver()).GetScreenshot();
        ss.SaveAsFile(resultsDir + today + "//Homepage-" + DateTime.Now.ToString("HHmmss") + ".png", 
        ScreenshotImageFormat.Png);

        // Write to console - Added for training purposes only
        Console.WriteLine("TEST COMPLETED");

    }
    [Test]
    [Category("Smoke")]
    public void NavToOurFirmPage()
    {
      // Navigate to hompepage
      GetDriver().Url = homepageUrl;
      GetDriver().Manage().Window.Maximize();
      // Wait for 'Our Firm' link to render
      homePage.WaitForOurFirmLink();
      // Click 'Our Firm' link
      homePage.ClickOurFirmLink();
      // Added for training purposes
      Helpers.Helpers.Pause(millisecondsToSleep);
      // Get page title
      string pageTitle = GetDriver().Title;

      // Assert page title is as expected
      Assert.AreEqual(expectedOurFirmPageTitle,pageTitle);
    }
}