using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections;
using System.Data;

namespace TLLib
{
    /// <summary>
    /// Summary description for CustomGridView
    /// </summary>
    /// 

    public delegate IEnumerable MustAddARowHandler(IEnumerable data);

    public partial class CustomGridView : GridView
    {
        bool m_isEmpty = false;

        protected override void PerformDataBinding(IEnumerable data)
        {
            //If in DesignMode, don't do anything special. Just call back base and return.
            if (DesignMode)
            {
                base.PerformDataBinding(data);
            }

            //COunt the data items.
            int objectItemCount = 0;
            foreach (object o in data)
            {
                objectItemCount++;
            }

            //If there is a count, don't do anything special. Just call base and return.
            if (objectItemCount > 0)
            {
                base.PerformDataBinding(data);
                return;
            }

            //Set these values so the GridView knows what's up
            SelectArguments.TotalRowCount++;
            m_isEmpty = true;

            //If it's a DataView, it will work without having to handle the MustAddARowHandler
            if (data.GetType() == typeof(DataView))
            {
                //Add a row and use that new view.
                DataView dv = (DataView)data;
                dv.Table.Rows.InsertAt(dv.Table.NewRow(), 0);
                base.PerformDataBinding(dv.Table.DefaultView);
                return;
            }
            else
            {
                //If you are using some custom object, you need to handle this event.
                base.PerformDataBinding(OnMustAddArow(data));
                return;
            }
        }

        protected override void OnDataBound(EventArgs e)
        {
            //If in DesignMode, don't do anything special. Just call base and return
            if (DesignMode)
            {
                base.OnDataBound(e);
                return;
            }

            //hide the dummy row.
            if (m_isEmpty)
                Rows[0].Visible = false;

            base.OnDataBound(e);
        }

        protected IEnumerable OnMustAddArow(IEnumerable data)
        {
            if (MustAddARow == null)
                throw new NullReferenceException("The datasource has no rows. You must handle the \"MustAddARow\"");

            return MustAddARow(data);
        }

        public event MustAddARowHandler MustAddARow;
    }
}
