using System;
using DevExpress.Web;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace DXWebApplication5 {
    public partial class Root : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            MainSplitter.GetPaneByName("HeaderPane").Size = ASPxWebControl.GlobalTheme == "Moderno" ? 101 : 87;
            MainSplitter.GetPaneByName("HeaderPane").MinSize = ASPxWebControl.GlobalTheme == "Moderno" ? 101 : 87;
        }
        protected void HeadLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e) {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}