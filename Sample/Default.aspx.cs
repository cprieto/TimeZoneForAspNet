using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cprieto.Utils;

namespace Sample
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var current = DateTime.Now;
            var utc = current.ToUniversalTime();
            currentTimeLabel.Text = current.ToString();
            currentUtcTimeLabel.Text = utc.ToString();
            currentTimeOffsetLabel.Text = this.UtcOffset().ToString();
            calculatedTimeLabel.Text = this.LocalTimeFromTimeOffset(utc).ToString();
        }
    }
}
