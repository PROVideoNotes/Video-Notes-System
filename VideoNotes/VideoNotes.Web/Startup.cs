using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoNotes.Web.Startup))]
namespace VideoNotes.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
