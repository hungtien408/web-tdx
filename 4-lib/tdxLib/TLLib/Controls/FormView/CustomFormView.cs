using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace TLLib
{
    /// <summary>
    /// Summary description for CustomGridView
    /// </summary>
    public partial class CustomFormView : FormView
    {

        protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
        {
            int rows = base.CreateChildControls(dataSource, dataBinding);

            //  no data rows created, create empty table if enabled
            if (rows == 0 && this.ShowWhenEmpty)
            {
                //  create the table
                Table table = new Table();
                FormViewRow fr = new FormViewRow(0,DataControlRowType.DataRow,DataControlRowState.Normal);
                TableCell tc = new TableCell();

                this.ItemTemplate.InstantiateIn(tc);

                fr.Controls.Add(tc);
                table.Controls.Add(fr);
                
                this.Controls.Clear();
                this.Controls.Add(table);
            }

            return rows;
        }

        [Category("Behavior")]
        [Themeable(true)]
        [Bindable(BindableSupport.No)]
        public bool ShowWhenEmpty
        {
            get
            {
                if (this.ViewState["ShowWhenEmpty"] == null)
                {
                    this.ViewState["ShowWhenEmpty"] = false;
                }

                return (bool)this.ViewState["ShowWhenEmpty"];
            }
            set
            {
                this.ViewState["ShowWhenEmpty"] = value;
            }
        }

    }
}
