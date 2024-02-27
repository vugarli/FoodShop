using Microsoft.AspNetCore.Components.Web;

namespace FoodShop.Web.Client
{
    public class NonPreRenderMode : InteractiveWebAssemblyRenderMode
    {
        public NonPreRenderMode()
            : base(prerender: false)
        {

        }
    }
}
