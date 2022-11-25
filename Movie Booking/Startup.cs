using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Movie_Booking.Startup))]
namespace Movie_Booking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
