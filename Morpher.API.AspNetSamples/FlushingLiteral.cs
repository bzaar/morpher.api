using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetSamples
{
    [ToolboxData ("<{0}:FlushingLiteral runat=server></{0}:FlushingLiteral>")]
    public class FlushingLiteral : WebControl
    {
        IEnumerable<string> content;

        public void SetContent (IEnumerable<string> content)
        {
            this.content = content;
        }

        HttpResponse response;

        public void SetResponse (HttpResponse response)
        {
            this.response = response;
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            foreach (string s in content)
            {
                output.Write(s);
                response.Flush();
            }
        }
    }
}
