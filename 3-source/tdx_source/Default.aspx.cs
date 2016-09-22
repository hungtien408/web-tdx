using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TLLib;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Thu Mua Phe Lieu";
        var meta = new HtmlMeta() { Name = "description", Content = "Thu Mua Phế Liệu Trái Đất Xanh, thu mua phe lieu giá cao, thu mua sắt, thép, đồng, nhôm, máy móc. Liên hệ: 0977 92 1239 Mr. Sơn, có xe tải riêng." };
        Header.Controls.Add(meta);
    }
    protected string progressTitle(object input)
    {
        return Common.ConvertTitle(input.ToString());
    }
}