using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Hidal.MusicApp.Pages;

public class Index_Tests : MusicAppWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
