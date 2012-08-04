using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Text;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint;

namespace SPVisioNet.WebParts.wpNotification
{
    public partial class wpNotificationUserControl : UserControl
    {
        private DataTable _dataTable;

        private string _selectQuery;
        public string SelectQuery
        {
            get { return _selectQuery; }
            set { _selectQuery = value; }
        }


        private string _viewFields;
        public string ViewFields
        {
            get { return _viewFields; }
            set { _viewFields = value; }
        }

        private string _sortQuery;
        public string SortQuery
        {
            get { return _sortQuery; }
            set { _sortQuery = value; }
        }

        private int _pageSize;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridView1.PageSize = PageSize;
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        private string ReplaceTime(string value)
        {
            if (String.IsNullOrEmpty(value))
                return "";

            if (!value.Contains("[TODAY]"))
                return value;
            int idx = value.IndexOf("[TODAY]");
            int openTag = value.IndexOf(">");
            int nextTag = 0;
            do
            {
                nextTag = value.IndexOf(">", openTag + 1);
                if (nextTag < idx && nextTag > 0)
                    openTag = nextTag;
                else
                    nextTag = -1;

            } while (nextTag > 0);

            nextTag = value.IndexOf("<", openTag);

            string timeVar = value.Substring(openTag + 1, nextTag - openTag - 1);
            idx = timeVar.IndexOf("-");
            if (idx > 0)
                try
                {
                    idx = -int.Parse(timeVar.Substring(idx + 1));
                }
                catch
                {
                    idx = 0;
                }
            else if ((idx = timeVar.IndexOf("+")) > 0)
            {
                try
                {
                    idx = int.Parse(timeVar.Substring(idx + 1));

                }
                catch
                {
                    idx = 0;
                }
            }
            else
            {
                idx = 0;
            }

            DateTime nowTime = DateTime.Now.AddDays(idx);

            StringBuilder sb = new StringBuilder();
            sb.Append(value.Substring(0, openTag + 1));
            sb.Append(SPUtility.CreateISO8601DateTimeFromSystemDateTime(nowTime));
            sb.Append(value.Substring(nextTag));

            return ReplaceTime(sb.ToString());
        }

        private void CreateDataTable()
        {
            _dataTable = new DataTable();
            DataColumn column1 = new DataColumn();
            column1.DataType = Type.GetType("System.Int32");
            column1.ColumnName = "No";
            column1.Caption = "No";
            this._dataTable.Columns.Add(column1);

            DataColumn column2 = new DataColumn();
            column2.DataType = Type.GetType("System.String");
            column2.ColumnName = "Title";
            column2.Caption = "Title";
            column2.AllowDBNull = true;
            this._dataTable.Columns.Add(column2);

            DataColumn column3 = new DataColumn();
            column3.DataType = Type.GetType("System.String");
            column3.ColumnName = "FileRef";
            column3.Caption = "FileRef";
            column3.AllowDBNull = true;
            this._dataTable.Columns.Add(column3);

            DataColumn column4 = new DataColumn();
            column4.DataType = Type.GetType("System.String");
            column4.ColumnName = "List Name";
            column4.Caption = "List Name";
            column4.AllowDBNull = true;
            this._dataTable.Columns.Add(column4);

            DataColumn column5 = new DataColumn();
            column5.DataType = Type.GetType("System.String");
            column5.ColumnName = "FileUrl";
            column5.Caption = "FileUrl";
            column5.AllowDBNull = true;
            this._dataTable.Columns.Add(column5);

            DataColumn column6 = new DataColumn();
            column6.DataType = Type.GetType("System.DateTime");
            column6.ColumnName = "Modified Date";
            column6.Caption = "Modified Date";
            column6.AllowDBNull = true;
            this._dataTable.Columns.Add(column6);

            DataColumn column7 = new DataColumn();
            column7.DataType = Type.GetType("System.DateTime");
            column7.ColumnName = "Period End Date";
            column7.Caption = "Period End Date";
            column7.AllowDBNull = true;
            this._dataTable.Columns.Add(column7);

        }

        private void LoadData()
        {
            CreateDataTable();

            int _counter = 1;
            SPWeb site = SPContext.Current.Web;
            SPQuery query = new SPQuery();
            query.Query = ReplaceTime(SelectQuery);
            query.ViewAttributes = "Scope=\"Recursive\"";
            query.ViewFields = ViewFields;
            string fileRef = string.Empty;
            try
            {
                foreach (SPList list in site.Lists)
                {
                    if (list.Hidden == false)
                    {
                        try
                        {
                            SPListItemCollection Items = list.GetItems(query);
                            foreach (SPListItem item in Items)
                            {
                                DataRow row = _dataTable.NewRow();
                                row["No"] = _counter;

                                row["Title"] = (item["Title"] != null ? item["Title"].ToString() : string.Empty);
                                row["List Name"] = list.Title;

                                if (list.BaseTemplate == SPListTemplateType.DocumentLibrary || list.BaseTemplate == SPListTemplateType.PictureLibrary)
                                {
                                    row["FileRef"] = item["FileRef"].ToString();
                                    fileRef = row["FileRef"].ToString();
                                }
                                else
                                {
                                    row["FileRef"] = item["FileRef"].ToString();
                                    fileRef = string.Format("{0}?ID={1}", SPEncode.UrlEncodeAsUrl(item.Web.Site.Url + item.ParentList.DefaultDisplayFormUrl), item.ID);
                                }


                                row["FileUrl"] = fileRef;
                                row["Modified Date"] = Convert.ToDateTime(item["Modified"]);

                                if (item["Period End Date"] != null)
                                    row["Period End Date"] = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(item["Period_x0020_End_x0020_Date"]));
                                else
                                    row["Period End Date"] = null;

                                _dataTable.Rows.Add(row);
                                _counter++;
                            }
                        }
                        catch { }
                    }
                }

                GridView1.DataSource = _dataTable;
                GridView1.DataBind();
                Label2.Text = string.Format("Total = {0}", _dataTable.Rows.Count);

            }
            catch (Exception exp)
            {
                lblMessage.Text = exp.Message + "," + exp.StackTrace;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadData();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = _dataTable;
            GridView1.DataBind();
        }
    }
}
