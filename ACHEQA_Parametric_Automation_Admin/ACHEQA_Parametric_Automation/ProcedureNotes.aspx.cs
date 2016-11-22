using CKEditor.NET;
using Jord.ACHEQA.BAL;
using Jord.ACHEQA.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACHEQA_Parametric_Automation_Admin
{
    public partial class ProcedureNotes : System.Web.UI.Page
    {
        ProcedureNotes_Entity objProcedureNotesEntity;
        ProcNotes_Lines_Entity objProcedureNotesLinesEntity;
        clsProcedureNotes_BAL objProcedureNotes_Bal;
        
        int ProcNotes_ID = 0;
        int _ProcNotes_ID = 0;
        int ProcNotes_Line_ID = 0;
        DataTable dt_ProcNotes;
        DataTable dt_ProcNotesLines;
        public DataTable _dtNotes=new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDowns();
                GetProcNotesByProcID();
            }
        }

        public void BindDropDowns()
        {
            DataTable dt_ProcedureList = new DataTable();
            dt_ProcedureList = cls_Procedures_BAL.Get_Procedures_BAL();
            ddlProcedureList.DataSource = dt_ProcedureList;
            ddlProcedureList.DataTextField = "ProcName";
            ddlProcedureList.DataValueField = "ProcID";
            ddlProcedureList.DataBind();
            ddlProcedureList.Items.Insert(0, (new ListItem("--Select--", "-1")));
        }

        public void GetProcNotesByProcID()
        {
            try
            {
                dt_ProcNotes = new DataTable();
                objProcedureNotes_Bal = new clsProcedureNotes_BAL();
                dt_ProcNotes = objProcedureNotes_Bal.GetProcNotesByProcID(Convert.ToInt32(ddlProcedureList.SelectedItem.Value.ToString()));

                if (dt_ProcNotes != null)
                {
                    if (dt_ProcNotes.Rows.Count > 0)
                    {
                        tvProcNotes.Visible = true;

                        lnkbtnDeleteNode.Visible = true;

                        Session["dt_ProcNotes"] = dt_ProcNotes;

                        PopulateTree(tvProcNotes, dt_ProcNotes);

                        tvProcNotes.ExpandAll();
                    }
                    else
                    {
                        tvProcNotes.Visible = false;
                       
                        rbtnlstNotesType.Visible = false;
                        rbtnlstActiveInActive.Visible = false;
                        CKEditorControl1.Text = "";
                        CKEditorControl1.Visible = false;
                        lnkbtnAddLine.Visible = false;
                        lnkbtnDeleteNode.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString());
            }
        }

        public void GetProcNoteLine(int ProcNotes_ID)
        {
            dt_ProcNotesLines = new DataTable();
            dt_ProcNotesLines = objProcedureNotes_Bal.GetProcNoteLinesByProcNoteID(ProcNotes_ID);

            if (dt_ProcNotesLines != null)
            {
                if (dt_ProcNotesLines.Rows.Count > 0)
                {
                    Session["dt_ProcNotesLines"] = dt_ProcNotesLines;
                    gvProcNotesLines.DataSource = dt_ProcNotesLines;
                    gvProcNotesLines.DataBind();

                    LinkButton lnkUp = (gvProcNotesLines.Rows[0].FindControl("lnkUp") as LinkButton);
                    LinkButton lnkDown = (gvProcNotesLines.Rows[gvProcNotesLines.Rows.Count - 1].FindControl("lnkDown") as LinkButton);
                    lnkUp.Enabled = false;
                    lnkDown.Enabled = false;
                }
                else
                {
                    gvProcNotesLines.DataSource = null;
                    gvProcNotesLines.DataBind();
                }
            }
            else
            {
                gvProcNotesLines.DataSource = null;
                gvProcNotesLines.DataBind();
            }
        }

        public byte[] ConvertHtmlToImage(string html)
        {
            string _newhtml = html;

            byte[] _Notes_Binary_Data;
            Bitmap m_Bitmap = new Bitmap(400, 600);
            PointF point1 = new PointF(0, 0);
            SizeF maxSize = new System.Drawing.SizeF(500, 500);
            TheArtOfDev.HtmlRenderer.WinForms.HtmlRender.Render(Graphics.FromImage(m_Bitmap), _newhtml);
            string filepath = Server.MapPath("~/ProcNotesLineImages/" + "ProcNotesLineImage.png");
            m_Bitmap.Save(filepath, ImageFormat.Png);
            Thread.Sleep(3000);

            // Load file meta data with FileInfo
            FileInfo fileInfo = new FileInfo(filepath);

            // The byte[] to save the data in
            _Notes_Binary_Data = new byte[fileInfo.Length];

            // Load a filestream and put its content into the byte[]
            using (FileStream fs = fileInfo.OpenRead())
            {
                fs.Read(_Notes_Binary_Data, 0, _Notes_Binary_Data.Length);
            }

            return _Notes_Binary_Data;
        }

        protected void ddlProcedureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProcNotesByProcID();
        }

        private void PopulateTree(TreeView objTreeView, DataTable Dt)
        {
            try
            {
                if (Dt != null)
                {
                    objTreeView.Nodes.Clear();
                    foreach (DataRow dataRow in Dt.Rows)
                    {
                        if (int.Parse(dataRow["ParentID"].ToString()) == 0)
                        {
                            TreeNode treeRoot = new TreeNode();
                            string CategoryName = dataRow["Notes"].ToString();
                            int Length = CategoryName.Length;
                            treeRoot.Text = dataRow["Notes"].ToString();
                            treeRoot.Value = dataRow["ProcNotes_ID"].ToString();
                            objTreeView.Nodes.Add(treeRoot);
                            foreach (TreeNode childnode in GetChildNode(Convert.ToInt64(dataRow["ProcNotes_ID"]), Dt))
                            {
                                treeRoot.ChildNodes.Add(childnode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString());
            }
        }

        private TreeNodeCollection GetChildNode(long parentid, DataTable Dt)
        {
            TreeNodeCollection childtreenodes = new TreeNodeCollection();
            try
            {
                childtreenodes.Clear();
                DataView dataView1 = new DataView(Dt);
                String strFilter = " ParentID=" + parentid.ToString() + "";
                dataView1.RowFilter = strFilter;

                if (dataView1.Count > 0)
                {
                    foreach (DataRow dataRow in dataView1.ToTable().Rows)
                    {
                        TreeNode childNode = new TreeNode();
                        string CategoryName = dataRow["Notes"].ToString();
                        int Length = CategoryName.Length;

                        if ((dataRow["Notes"].ToString().Replace(" - Blank", "")) == dataRow["SerialNumber"].ToString())
                        {
                            childNode.Text = (dataRow["Notes"].ToString().Replace("<p>", "")).Replace("</p>", "");
                        }
                        else
                        {
                            childNode.Text = dataRow["SerialNumber"].ToString() + " - " + (dataRow["Notes"].ToString().Replace("<p>", "")).Replace("</p>", "");
                        }

                        childNode.Value = dataRow["ProcNotes_ID"].ToString();
                        foreach (TreeNode cnode in GetChildNode(Convert.ToInt64(dataRow["ProcNotes_ID"]), Dt))
                        {
                            childNode.ChildNodes.Add(cnode);
                            cnode.Text = new string(cnode.Text.Take(25).ToArray()) + ".....";
                        }
                        childtreenodes.Add(childNode);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString());
            }
            return childtreenodes;
        }

        protected void tvProcNotes_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            try
            {
                foreach (TreeNode treenode in tvProcNotes.Nodes)
                {
                    if (treenode.Text == e.Node.Text)
                    {
                        treenode.Expand();
                        treenode.ImageUrl = "~/Images/OpenedBookColorInBlue.png";
                        break;
                    }
                    foreach (TreeNode t in treenode.ChildNodes)
                    {
                        if (t.Text == e.Node.Text)
                        {
                            t.Expand();
                            t.ImageUrl = "~/Images/OpenedBookColorInBlue.png";
                            break;
                        }
                        foreach (TreeNode t1 in t.ChildNodes)
                        {
                            if (t1.Text == e.Node.Text)
                            {
                                t1.Expand();
                                t1.ImageUrl = "~/Images/OpenedBookColorInBlue.png";
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString());
            }
        }

        protected void tvProcNotes_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
        {
            try
            {
                foreach (TreeNode treenode in tvProcNotes.Nodes)
                {
                    if (treenode.Text == e.Node.Text)
                    {
                        treenode.Collapse();
                        treenode.ImageUrl = "~/Images/ClosedBookColorInBlue.png";
                        break;
                    }
                    foreach (TreeNode t in treenode.ChildNodes)
                    {
                        if (t.Text == e.Node.Text)
                        {
                            t.Collapse();
                            t.ImageUrl = "~/Images/ClosedBookColorInBlue.png";
                            break;
                        }
                        foreach (TreeNode t1 in t.ChildNodes)
                        {
                            if (t1.Text == e.Node.Text)
                            {
                                t1.Collapse();
                                t1.ImageUrl = "~/Images/ClosedBookColorInBlue.png";
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString());
            }
        }

        protected void tvProcNotes_SelectedNodeChanged(object sender, EventArgs e)
        {
            objProcedureNotes_Bal = new clsProcedureNotes_BAL();

            _ProcNotes_ID=Convert.ToInt32(tvProcNotes.SelectedNode.Value.ToString());
            hfProcNotes_ID.Value = _ProcNotes_ID.ToString();

            DataTable dt = (DataTable)Session["dt_ProcNotes"];
            DataRow dr = dt.AsEnumerable().SingleOrDefault(r => r.Field<int>("ProcNotes_ID") == _ProcNotes_ID);

            int _ParentID = Convert.ToInt32(dr["ParentID"].ToString());
            hfParentID.Value = _ParentID.ToString();

            int _SequenceNumber = Convert.ToInt32(dr["SequenceNumber"].ToString());
            hfSequenceNumber.Value = _SequenceNumber.ToString();

            string _SerialNumber = dr["SerialNumber"].ToString();
            hfSerialNumber.Value = _SerialNumber.ToString();

            string _Notes = dr["Notes"].ToString();
            //CKEditorControl1.Text = _Notes.ToString();

            GetProcNoteLine(Convert.ToInt32(hfProcNotes_ID.Value.ToString()));

            if (_ParentID > 0)
            {
                rbtnlstNotesType.Visible = true;
                rbtnlstActiveInActive.Visible = true;
                CKEditorControl1.Visible = true;
                lnkbtnAddLine.Visible = true;

                CKEditorControl1.Text = "";
                lnkbtnUpdateNotes.Visible = false;
                lnkbtnCancel.Visible = false;
            }
            else
            {
                rbtnlstNotesType.Visible = false;
                rbtnlstActiveInActive.Visible = false;
                CKEditorControl1.Visible = false;
                lnkbtnAddLine.Visible = false;
            }
        }

        protected void lnkbtnAddNode_Click(object sender, EventArgs e)
        {
            objProcedureNotes_Bal = new clsProcedureNotes_BAL();
            int _ProcID = 0;
            int _CountOfProcID = 0;
            int _SequenceNumber = 0;
            int _SNO = 0;
            int _ChildNotesCount = 0;
            int _SeqNum = 0;
            int _ParentID = 0;

            if (ddlProcedureList.SelectedItem.Value == "-1")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage1", "Showalert_ProcedureList();", true);
                return;
            }
            else
            {
                objProcedureNotesEntity = new ProcedureNotes_Entity();

                _ProcID = Convert.ToInt32(ddlProcedureList.SelectedItem.Value.ToString());
                _CountOfProcID = objProcedureNotes_Bal.GetCountOfProc_ID(_ProcID);

                if (_CountOfProcID > 0)
                {
                    if (Convert.ToInt32(hfParentID.Value.ToString()) == 0)
                    {
                        _ParentID = Convert.ToInt32(hfParentID.Value.ToString());
                        objProcedureNotesEntity.SequenceNumber = 1;
                        objProcedureNotesEntity.SeqNum = 1;
                        _SNO = objProcedureNotes_Bal.GetCountOfChildNodes(Convert.ToInt32(hfProcNotes_ID.Value.ToString()));
                        objProcedureNotesEntity.SNO = _SNO + 1;
                        objProcedureNotesEntity.SerialNumber = objProcedureNotesEntity.SNO.ToString();
                        objProcedureNotesEntity.Notes = (objProcedureNotesEntity.SNO) + " - Blank";
                    }
                    else
                    {
                        _ParentID = Convert.ToInt32(hfParentID.Value.ToString());
                        _SequenceNumber = objProcedureNotes_Bal.GetMaxSequenceNumber(Convert.ToInt32(hfProcNotes_ID.Value.ToString()));
                        _SeqNum = objProcedureNotes_Bal.GetMaxSeqNum(Convert.ToInt32(hfProcNotes_ID.Value.ToString()));

                        _ChildNotesCount = objProcedureNotes_Bal.GetCountOfChildNodes(Convert.ToInt32(hfProcNotes_ID.Value.ToString()));
                        if (_ChildNotesCount > 0)
                        {
                            objProcedureNotesEntity.SeqNum = _SeqNum + 1;
                            objProcedureNotesEntity.SerialNumber = hfSerialNumber.Value.ToString() + "." + objProcedureNotesEntity.SeqNum.ToString();
                        }
                        else
                        {
                            objProcedureNotesEntity.SeqNum = 1;
                            objProcedureNotesEntity.SerialNumber = hfSerialNumber.Value.ToString() + "." + objProcedureNotesEntity.SeqNum.ToString();
                        }

                        objProcedureNotesEntity.SNO = 0;
                        objProcedureNotesEntity.SequenceNumber = _SequenceNumber + 1;

                        objProcedureNotesEntity.Notes = objProcedureNotesEntity.SerialNumber.ToString() + " - Blank";
                    }

                    ProcNotes_ID = 0;
                    objProcedureNotesEntity.ProcNotes_ID = ProcNotes_ID;
                    objProcedureNotesEntity.Proc_ID = _ProcID;
                    objProcedureNotesEntity.ParentID = Convert.ToInt32(hfProcNotes_ID.Value.ToString());
                    lblParentID.Text = objProcedureNotesEntity.ParentID.ToString();
                    objProcedureNotesEntity.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    objProcedureNotesEntity.LastUpdatedBy = Convert.ToInt32(Session["UserID"]); ;
                }
                else
                {
                    ProcNotes_ID = 0;
                    objProcedureNotesEntity = new ProcedureNotes_Entity();
                    objProcedureNotesEntity.ProcNotes_ID = ProcNotes_ID;
                    objProcedureNotesEntity.Proc_ID = _ProcID;
                    objProcedureNotesEntity.ParentID = 0;
                    objProcedureNotesEntity.SerialNumber = "0";
                    objProcedureNotesEntity.Notes = ddlProcedureList.SelectedItem.Text.ToString();
                    objProcedureNotesEntity.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                    objProcedureNotesEntity.LastUpdatedBy = Convert.ToInt32(Session["UserID"]); ;
                    objProcedureNotesEntity.SequenceNumber = 0;
                    objProcedureNotesEntity.SNO = 0;
                    objProcedureNotesEntity.SeqNum = 0;
                    _ParentID = 0;
                }

                ProcNotes_ID = objProcedureNotes_Bal.InsertUpdateProcedureNotes(objProcedureNotesEntity);

                if (ProcNotes_ID > 0)
                {
                    if (objProcedureNotesEntity.ParentID > 0)
                    {
                        int _LineNumber = 0;

                        ProcNotes_Line_ID = 0;
                        objProcedureNotesLinesEntity = new ProcNotes_Lines_Entity();
                        objProcedureNotesLinesEntity.ProcNotes_Line_ID = ProcNotes_Line_ID;

                        objProcedureNotesLinesEntity.ProcNotes_ID = ProcNotes_ID;

                        _LineNumber = objProcedureNotes_Bal.GetMaxLineNumber(ProcNotes_ID);

                        objProcedureNotesLinesEntity.LineNumber = _LineNumber + 1;

                        objProcedureNotesLinesEntity.Notes_Type = "Text";
                        objProcedureNotesLinesEntity.Notes = objProcedureNotesEntity.Notes.ToString();

                        objProcedureNotesLinesEntity.Notes_Binary = new byte[0];
                        objProcedureNotesLinesEntity.IsActive = true;
                        objProcedureNotesEntity.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        objProcedureNotesEntity.LastUpdatedBy = Convert.ToInt32(Session["UserID"]);

                        ProcNotes_Line_ID = objProcedureNotes_Bal.InsertUpdateProcedureNotesLines(objProcedureNotesLinesEntity);

                        hfProcNotes_Line_ID.Value = ProcNotes_Line_ID.ToString();
                    }
                    else
                    {

                    }
                }

                if (ProcNotes_ID > 0)
                {
                    GetProcNotesByProcID();
                }
            }
        }

        protected void lnkbtnDeleteNode_Click(object sender, EventArgs e)
        {

        }

        protected void lnkbtnAddLine_Click(object sender, EventArgs e)
        {
            objProcedureNotes_Bal = new clsProcedureNotes_BAL();
            objProcedureNotesLinesEntity = new ProcNotes_Lines_Entity();

            if (Convert.ToInt32(hfProcNotes_ID.Value.ToString()) > 0)
            {
                if (rbtnlstNotesType.SelectedItem.Text.ToString() == "Text")
                {
                    if (CKEditorControl1.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage2", "Showalert_Notes();", true);
                        return;
                    }
                }

                int _LineNumber = 0;

                ProcNotes_Line_ID = 0;
                objProcedureNotesLinesEntity = new ProcNotes_Lines_Entity();
                objProcedureNotesLinesEntity.ProcNotes_Line_ID = ProcNotes_Line_ID;

                if (Convert.ToInt32(hfParentID.Value.ToString()) == 0)
                {
                    objProcedureNotesLinesEntity.ProcNotes_ID = ProcNotes_ID;
                }
                else
                {
                    objProcedureNotesLinesEntity.ProcNotes_ID = Convert.ToInt32(hfProcNotes_ID.Value.ToString());
                }

                _LineNumber = objProcedureNotes_Bal.GetMaxLineNumber(Convert.ToInt32(hfProcNotes_ID.Value.ToString()));

                objProcedureNotesLinesEntity.LineNumber = _LineNumber + 1;

                objProcedureNotesLinesEntity.Notes_Type = rbtnlstNotesType.SelectedItem.Text.ToString();

                string _htmltext = "";
                _htmltext = CKEditorControl1.Text.ToString();

                objProcedureNotesLinesEntity.Notes = _htmltext;
                //objProcedureNotesLinesEntity.Notes = Addnewline(_htmltext);

                //objProcedureNotesLinesEntity.Notes = Addnewline(_htmltext,125);

                objProcedureNotesLinesEntity.Notes_Binary = new byte[0];

                if (rbtnlstActiveInActive.SelectedItem.Text == "Active")
                {
                    objProcedureNotesLinesEntity.IsActive = true;
                }
                else if (rbtnlstActiveInActive.SelectedItem.Text == "InActive")
                {
                    objProcedureNotesLinesEntity.IsActive = false;
                }

                objProcedureNotesLinesEntity.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                objProcedureNotesLinesEntity.LastUpdatedBy = Convert.ToInt32(Session["UserID"]); ;

                ProcNotes_Line_ID = objProcedureNotes_Bal.InsertUpdateProcedureNotesLines(objProcedureNotesLinesEntity);

                hfProcNotes_Line_ID.Value = ProcNotes_Line_ID.ToString();

                if (ProcNotes_Line_ID > 0)
                {
                    CKEditorControl1.Text = "";
                    rbtnlstNotesType.Text = "Text";
                    rbtnlstNotesType.Items.FindByText("Text").Selected = true;
                    rbtnlstActiveInActive.Text = "Active";
                    rbtnlstActiveInActive.Items.FindByText("Active").Selected = true; 

                    GetProcNoteLine(Convert.ToInt32(hfProcNotes_ID.Value.ToString()));
                }
            }
        }

        protected void lnkbtnUpdateNotes_Click(object sender, EventArgs e)
        {
            objProcedureNotes_Bal = new clsProcedureNotes_BAL();
            objProcedureNotesEntity = new ProcedureNotes_Entity();
            objProcedureNotesLinesEntity = new ProcNotes_Lines_Entity();

            if (lblProcNotes_Line_ID.Text.ToString() != "")
            {
                objProcedureNotesLinesEntity.ProcNotes_Line_ID = Convert.ToInt32(lblProcNotes_Line_ID.Text.ToString());
                objProcedureNotesLinesEntity.ProcNotes_ID = Convert.ToInt32(lblProcNotes_ID.Text.ToString());
                objProcedureNotesLinesEntity.LineNumber = Convert.ToInt32(lblLineNumber.Text);
                objProcedureNotesLinesEntity.Notes_Type = rbtnlstNotesType.SelectedItem.Text.ToString();
                objProcedureNotesLinesEntity.Notes = CKEditorControl1.Text.ToString();
                objProcedureNotesLinesEntity.Notes_Binary = new byte[0];

                if (rbtnlstActiveInActive.SelectedItem.Text == "Active")
                {
                    objProcedureNotesLinesEntity.IsActive = true;
                }
                else if (rbtnlstActiveInActive.SelectedItem.Text == "InActive")
                {
                    objProcedureNotesLinesEntity.IsActive = false;
                }

                objProcedureNotesLinesEntity.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                objProcedureNotesLinesEntity.LastUpdatedBy = Convert.ToInt32(Session["UserID"]); ;

                ProcNotes_Line_ID = objProcedureNotes_Bal.InsertUpdateProcedureNotesLines(objProcedureNotesLinesEntity);

                if (objProcedureNotesLinesEntity.LineNumber == 1 && objProcedureNotesLinesEntity.Notes_Type.ToString()=="Text")
                {
                    objProcedureNotesEntity.ProcNotes_ID = objProcedureNotesLinesEntity.ProcNotes_ID;
                    objProcedureNotesEntity.Notes = objProcedureNotesLinesEntity.Notes;
                    objProcedureNotesEntity.LastUpdatedBy = Convert.ToInt32(Session["UserID"]); ;
                    objProcedureNotesEntity.SerialNumber = "";

                    ProcNotes_ID = objProcedureNotes_Bal.InsertUpdateProcedureNotes(objProcedureNotesEntity);
                }

                if (ProcNotes_Line_ID > 0)
                {
                    CKEditorControl1.Text = "";
                    rbtnlstNotesType.Text = "Text";
                    rbtnlstNotesType.Items.FindByText("Text").Selected = true;
                    rbtnlstActiveInActive.Text = "Active";
                    rbtnlstActiveInActive.Items.FindByText("Active").Selected = true; 

                    GetProcNoteLine(Convert.ToInt32(lblProcNotes_ID.Text.ToString()));
                    GetProcNotesByProcID();
                }
            }
        }

        protected void lnkbtnCancel_Click(object sender, EventArgs e)
        {
            lnkbtnAddLine.Visible = true;
            lnkbtnUpdateNotes.Visible = false;
            lnkbtnCancel.Visible = false;

            CKEditorControl1.Text = "";
            rbtnlstNotesType.Text = "Text";
            rbtnlstNotesType.Items.FindByText("Text").Selected = true;
            rbtnlstActiveInActive.Text = "Active";
            rbtnlstActiveInActive.Items.FindByText("Active").Selected = true; 
        }

        protected void gvProcNotesLines_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateProcNotesLine")
            {
                lnkbtnAddLine.Visible = false;
                lnkbtnUpdateNotes.Visible = true;
                lnkbtnCancel.Visible = true;

                int _ProcNotes_Line_ID;
                _ProcNotes_Line_ID = Convert.ToInt32(e.CommandArgument);
                lblProcNotes_Line_ID.Text = _ProcNotes_Line_ID.ToString();
                DataTable dt = (DataTable)Session["dt_ProcNotesLines"];
                DataRow dr = dt.AsEnumerable().SingleOrDefault(r => r.Field<int>("ProcNotes_Line_ID") == _ProcNotes_Line_ID);

                int _LineNumber = Convert.ToInt32(dr["LineNumber"].ToString());
                string _Notes_Type = dr["Notes_Type"].ToString();
                string _Notes = dr["Notes"].ToString();

                string _ProcNotes_ID = dr["ProcNotes_ID"].ToString();
                bool _IsActive = Convert.ToBoolean(dr["IsActive"].ToString());

                lblProcNotes_ID.Text = _ProcNotes_ID;
                lblLineNumber.Text = _LineNumber.ToString();

                if (_IsActive == true)
                {
                    rbtnlstActiveInActive.Text = "Active";
                }
                else
                {
                    rbtnlstActiveInActive.Text = "InActive";
                }
                rbtnlstActiveInActive.Items.FindByText(rbtnlstActiveInActive.Text).Selected = true;

                rbtnlstNotesType.Text = _Notes_Type;
                rbtnlstNotesType.Items.FindByText(rbtnlstNotesType.Text).Selected = true;
                CKEditorControl1.Text = _Notes;
            }
        }

        public string Addnewline(string Text, int Number)
        {
            int x = Text.Length;
            int y = 0;
            string result = "";
            while (x > Number)
            {
                x = x - Number;
                y = y + Number;
                result += Text.Substring(0, Number) + System.Environment.NewLine;
                Text = Text.Substring(Number);
            }
            return result;
        }

        public string Addnewline(string newStr)
        {
            int StartIndex=0;
            int EndIndex=0;
            string result = "";
            while (newStr.Length > 0)
            {
                if (StartIndex < 0)
                {
                    StartIndex = 0;
                }
                else
                {
                    StartIndex = 0;
                }
                if (EndIndex < 0)
                {
                    EndIndex = 0;
                }
                else
                {
                    EndIndex = 125;
                }
                result += newStr.Substring(StartIndex, EndIndex) + System.Environment.NewLine;
                newStr = newStr.Substring(EndIndex);
            }
            return result;
        }

        protected void ChangePreference(object sender, EventArgs e)
        {
            Label lblProcNotes_Line_ID;
            Label lblProcNotes_ID;
            Label lblLineNumber;
            int LastUpdatedBy;

            string commandArgument = (sender as LinkButton).CommandArgument;

            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            lblProcNotes_Line_ID = (gvProcNotesLines.Rows[rowIndex].FindControl("lblProcNotes_Line_ID") as Label);
            lblProcNotes_ID = (gvProcNotesLines.Rows[rowIndex].FindControl("lblProcNotes_ID") as Label);
            lblLineNumber = (gvProcNotesLines.Rows[rowIndex].FindControl("lblLineNumber") as Label);

            int ProcNotes_Line_ID1 = Convert.ToInt32(lblProcNotes_Line_ID.Text.ToString());
            int ProcNotes_ID1 = Convert.ToInt32(lblProcNotes_ID.Text.ToString());
            int LineNumber1 = Convert.ToInt32(lblLineNumber.Text.ToString());

            LineNumber1 = commandArgument == "up" ? LineNumber1 - 1 : LineNumber1 + 1;
            LastUpdatedBy = Convert.ToInt32(Session["UserID"]);

            this.UpdateLineNumber(ProcNotes_Line_ID1, LineNumber1, LastUpdatedBy);

            rowIndex = commandArgument == "up" ? rowIndex - 1 : rowIndex + 1;
            lblProcNotes_Line_ID = (gvProcNotesLines.Rows[rowIndex].FindControl("lblProcNotes_Line_ID") as Label);
            lblProcNotes_ID = (gvProcNotesLines.Rows[rowIndex].FindControl("lblProcNotes_ID") as Label);
            lblLineNumber = (gvProcNotesLines.Rows[rowIndex].FindControl("lblLineNumber") as Label);
            int LineNumber2 = commandArgument == "up" ? LineNumber1 + 1 : LineNumber1 - 1;

            int ProcNotes_Line_ID2 = Convert.ToInt32(lblProcNotes_Line_ID.Text.ToString());
            int ProcNotes_ID2 = Convert.ToInt32(lblProcNotes_ID.Text.ToString());

            this.UpdateLineNumber(ProcNotes_Line_ID2, LineNumber2, LastUpdatedBy);

            GetProcNoteLine(ProcNotes_ID1);
            //Response.Redirect(Request.Url.AbsoluteUri);

            //int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
            //int locationId = Convert.ToInt32(gvLocations.Rows[rowIndex].Cells[0].Text); // ProcNotes_Line_ID
            //int preference = Convert.ToInt32(gvLocations.DataKeys[rowIndex].Value); // LineNumber
            //preference = commandArgument == "up" ? preference - 1 : preference + 1; // LineNumber
            //this.UpdatePreference(locationId, preference); // ProcNotes_Line_ID,LineNumber

            //rowIndex = commandArgument == "up" ? rowIndex - 1 : rowIndex + 1;
            //locationId = Convert.ToInt32(gvLocations.Rows[rowIndex].Cells[0].Text); // ProcNotes_Line_ID
            //preference = Convert.ToInt32(gvLocations.DataKeys[rowIndex].Value); // LineNumber
            //preference = commandArgument == "up" ? preference + 1 : preference - 1; // LineNumber
            //this.UpdatePreference(locationId, preference); // ProcNotes_Line_ID,LineNumber

            //Response.Redirect(Request.Url.AbsoluteUri);
        }

        private void UpdateLineNumber(int ProcNotes_Line_ID, int LineNumber,int LastUpdatedBy)
        {
            objProcedureNotes_Bal = new clsProcedureNotes_BAL();
            int _ID = 0;
            _ID = objProcedureNotes_Bal.UpdateProcedureNotesLineNumber(ProcNotes_Line_ID, LineNumber, LastUpdatedBy);

            //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand("UPDATE HolidayLocations SET Preference = @Preference WHERE Id = @Id"))
            //    {
            //        using (SqlDataAdapter sda = new SqlDataAdapter())
            //        {
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Parameters.AddWithValue("@Id", locationId);
            //            cmd.Parameters.AddWithValue("@Preference", preference);
            //            cmd.Connection = con;
            //            con.Open();
            //            cmd.ExecuteNonQuery();
            //            con.Close();
            //        }
            //    }
            //}
        }

        //public void GetAllToolTips()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        objProcedureNotes_Bal = new clsProcedureNotes_BAL();
        //        dt = objProcedureNotes_Bal.GetAllProcNotes();

        //        //Max_ID = Convert.ToInt32(dt.AsEnumerable().Max(row => row["ID"]));
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //private void PopulateTreeView()
        //{
        //    DataSet ds = new DataSet(); //(populate the dataset with the table)

        //    DataTable dt = new DataTable();
        //    objProcedureNotes_Bal = new clsProcedureNotes_BAL();
        //    dt = objProcedureNotes_Bal.GetTreeView();

        //    //Use LINQ to filter out items without a parent
        //    DataTable parents = dt.AsEnumerable()
        //                    .Where(i => i.Field<int>("ParentID") == 0)
        //                    .CopyToDataTable();

        //    //DataTable tbl = (from DataRow dr in dt.Rows
        //    //                 where Convert.ToInt32(dr["ParentID"].ToString()) == 0
        //    //                 select dr).CopyToDataTable();

        //    //Add the parents to the treeview
        //    foreach (DataRow dr in parents.Rows)
        //    {
        //        TreeNode node = new TreeNode();
        //        node.Text = dr["Notes"].ToString();
        //        node.Value = dr["ProcNotes_ID"].ToString();
        //        tvProcNotes.Nodes.Add(node);
        //    }

        //    //Use LINQ to filter out items with parent
        //    DataTable children = dt.AsEnumerable()
        //        .Where(i => i.Field<int>("ParentID") != 0)
        //        .OrderBy(i => i.Field<int>("ParentID"))
        //        .CopyToDataTable();

        //    //Add the children to the parents
        //    foreach (DataRow dr in children.Rows)
        //    {
        //        TreeNode node = new TreeNode();
        //        node.Text = dr["Notes"].ToString();
        //        node.Value = dr["ProcNotes_ID"].ToString();
        //        TreeNode parentNode = FindNodeByValue(dr["ParentID"].ToString());
        //        if (parentNode != null)
        //            parentNode.ChildNodes.Add(node);
        //    }
        //}

        //private TreeNode FindNodeByValue(string value)
        //{
        //    foreach (TreeNode node in tvProcNotes.Nodes)
        //    {
        //        if (node.Value == value) return node;
        //        TreeNode pnode = FindNodeRecursion(node, value);
        //        if (pnode != null) return pnode;
        //    }
        //    return null;
        //}

        //private TreeNode FindNodeRecursion(TreeNode parentNode, string value)
        //{
        //    foreach (TreeNode node in parentNode.ChildNodes)
        //    {
        //        if (node.Value == value) return node;
        //        TreeNode pnode = FindNodeRecursion(node, value);
        //        if (pnode != null) return pnode;
        //    }
        //    return null;
        //}
    }
}

