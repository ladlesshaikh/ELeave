using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Windows.Forms;
using System.Data;
using ATTNPAY.Core;

namespace ATTNPAY.Class
{

    class DGVHelper
    {
        #region Variables
            public DataGridView sDGVs = new DataGridView();
            List<int> listcolumnIndex;
            List<BindDataClassVO> _lstBindDataClassVO=new List<BindDataClassVO>();
            List<CPFSettingsVO> _lstCPFSettingsVO =new List<CPFSettingsVO>();
            int DateColumnIndex=0;
            int ColorColumnIndex = 0;
            int ClickColumnIndex = 0;
            DateTimePicker sDateTimePicker;
            String EventFucntions;
        # endregion

        //Set all the telerik Grid layout
        #region Layout
        
        public static void Layouts(DataGridView cDGV, Color BackgroundColor, Color RowsBackColor, Color AlternatebackColor, Boolean AutoGenerateColumns, Color HeaderColor, Boolean HeaderVisual, Boolean RowHeadersVisible, Boolean AllowUserToAddRows)
        {
            try
            {
                //Grid Back ground Color
                cDGV.BackgroundColor = BackgroundColor;

                //Grid Back Color
                cDGV.RowsDefaultCellStyle.BackColor = RowsBackColor;

                //GridColumnStylesCollection Alternate Rows Backcolr
                cDGV.AlternatingRowsDefaultCellStyle.BackColor = AlternatebackColor;

                // Auto generated here set to tru or false.
                cDGV.AutoGenerateColumns = AutoGenerateColumns;
                //  ShanuDGV.DefaultCellStyle.Font = new Font("Verdana", 10.25f, FontStyle.Regular);
                // ShanuDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

                //Column Header back Color
                cDGV.ColumnHeadersDefaultCellStyle.BackColor = HeaderColor;

                //header Visisble
                cDGV.EnableHeadersVisualStyles = HeaderVisual;

                // Enable the row header
                cDGV.RowHeadersVisible = RowHeadersVisible;

                // to Hide the Last Empty row here we use false.
                cDGV.AllowUserToAddRows = AllowUserToAddRows;
            }
            catch (Exception exp)
            {
                //...
            }
        }
        #endregion

        //Add your grid to your selected Control and set height,width,position of your grid.
        #region Variables
        public static void Generategrid(DataGridView customDGV, Control cntrlName, int width, int height, int xval, int yval)
        {
            customDGV.Location = new Point(xval, yval);
            customDGV.Size = new Size(width, height);
            //ShanuDGV.Dock = docktyope.
            cntrlName.Controls.Add(customDGV);
        }
        #endregion

        //Template Column In this column we can add Textbox,Lable,Check Box,Dropdown box and etc
        #region Templatecolumn
        public static void Templatecolumn(DataGridView customDGV, GridControlTypes sControlTypes, String cntrlnames, String Headertext, String ToolTipText, Boolean Visible, int width, DataGridViewTriState Resizable, DataGridViewContentAlignment cellAlignment, DataGridViewContentAlignment headerAlignment, Color CellTemplateBackColor, DataTable dtsource, String DisplayMember, String ValueMember, Color CellTemplateforeColor)
        {
            try
            {
                switch (sControlTypes)
                {
                    case GridControlTypes.CheckBox:
                        DataGridViewCheckBoxColumn dgvChk = new DataGridViewCheckBoxColumn();
                        dgvChk.ValueType = typeof(bool);
                        dgvChk.Name = cntrlnames;

                        dgvChk.HeaderText = Headertext;
                        dgvChk.ToolTipText = ToolTipText;
                        dgvChk.Visible = Visible;
                        dgvChk.Width = width;
                        dgvChk.SortMode = DataGridViewColumnSortMode.Automatic;
                        dgvChk.Resizable = Resizable;
                        dgvChk.DefaultCellStyle.Alignment = cellAlignment;
                        dgvChk.HeaderCell.Style.Alignment = headerAlignment;
                        if (CellTemplateBackColor.Name.ToString() != "Transparent")
                        {
                            dgvChk.CellTemplate.Style.BackColor = CellTemplateBackColor;
                        }
                        dgvChk.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                        customDGV.Columns.Add(dgvChk);
                        break;
                    case GridControlTypes.BoundColumn:
                        DataGridViewColumn col = new DataGridViewTextBoxColumn();
                        col.DataPropertyName = cntrlnames;
                        col.Name = cntrlnames;
                        col.HeaderText = Headertext;
                        col.ToolTipText = ToolTipText;
                        col.Visible = Visible;
                        col.Width = width;
                        col.SortMode = DataGridViewColumnSortMode.Automatic;
                        col.Resizable = Resizable;
                        col.DefaultCellStyle.Alignment = cellAlignment;
                        col.HeaderCell.Style.Alignment = headerAlignment;
                        if (CellTemplateBackColor.Name.ToString() != "Transparent")
                        {
                            col.CellTemplate.Style.BackColor = CellTemplateBackColor;
                        }
                        col.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                        customDGV.Columns.Add(col);
                        break;
                    case GridControlTypes.TextBox:
                        DataGridViewTextBoxColumn dgvText = new DataGridViewTextBoxColumn();
                        //dgvText.ValueType = typeof(decimal);
                        dgvText.DataPropertyName = cntrlnames;
                        dgvText.Name = cntrlnames;
                        dgvText.HeaderText = Headertext;
                        dgvText.ToolTipText = ToolTipText;
                        dgvText.Visible = Visible;
                        dgvText.Width = width;
                        dgvText.SortMode = DataGridViewColumnSortMode.Automatic;
                        dgvText.Resizable = Resizable;
                        dgvText.DefaultCellStyle.Alignment = cellAlignment;
                        dgvText.HeaderCell.Style.Alignment = headerAlignment;
                        if (CellTemplateBackColor.Name.ToString() != "Transparent")
                        {
                            dgvText.CellTemplate.Style.BackColor = CellTemplateBackColor;
                        }
                        dgvText.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                        customDGV.Columns.Add(dgvText);
                        break;
                    case GridControlTypes.ComboBox:
                        System.Windows.Forms.DataGridViewComboBoxColumn dgvcombo = new System.Windows.Forms.DataGridViewComboBoxColumn();
                        dgvcombo.ValueType = typeof(decimal);
                        dgvcombo.Name = cntrlnames;
                        dgvcombo.DataSource = dtsource;
                        dgvcombo.DisplayMember = DisplayMember; 
                        dgvcombo.ValueMember = ValueMember;
                        dgvcombo.Visible = Visible;
                        dgvcombo.FlatStyle = FlatStyle.Flat;
                        dgvcombo.Width = width;
                        dgvcombo.SortMode = DataGridViewColumnSortMode.Automatic;
                        dgvcombo.Resizable = Resizable;
                        dgvcombo.DefaultCellStyle.Alignment = cellAlignment;
                        dgvcombo.HeaderCell.Style.Alignment = headerAlignment;
                        if (CellTemplateBackColor.Name.ToString() != "Transparent")
                        {
                            dgvcombo.CellTemplate.Style.BackColor = CellTemplateBackColor;

                        }
                        dgvcombo.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                        customDGV.Columns.Add(dgvcombo);
                        break;

                    case GridControlTypes.Button:
                        DataGridViewButtonColumn dgvButtons = new DataGridViewButtonColumn();
                        dgvButtons.Name = cntrlnames;
                        dgvButtons.FlatStyle = FlatStyle.Popup;
                        dgvButtons.DataPropertyName = cntrlnames;
                        dgvButtons.Visible = Visible;
                        dgvButtons.Width = width;
                        dgvButtons.SortMode = DataGridViewColumnSortMode.Automatic;
                        dgvButtons.Resizable = Resizable;
                        dgvButtons.DefaultCellStyle.Alignment = cellAlignment;
                        dgvButtons.HeaderCell.Style.Alignment = headerAlignment;
                        if (CellTemplateBackColor.Name.ToString() != "Transparent")
                        {
                            dgvButtons.CellTemplate.Style.BackColor = CellTemplateBackColor;
                        }
                        dgvButtons.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                        customDGV.Columns.Add(dgvButtons);
                        break;
                }

            }
            catch (Exception exp)
            {
                //...
            }


        }

        #endregion
        #region Templatecolumn
        public static void Templatecolumn<T>(DataGridView customDGV, GridControlTypes sControlTypes, String cntrlnames, String Headertext, String ToolTipText, Boolean Visible, int width, DataGridViewTriState  Resizable, DataGridViewContentAlignment cellAlignment, DataGridViewContentAlignment headerAlignment, Color CellTemplateBackColor, IList<T> dtsource, String DisplayMember, String ValueMember, Color CellTemplateforeColor)
        {
            try
            {
                switch (sControlTypes)
                {
                    case GridControlTypes.CheckBox:
                        DataGridViewCheckBoxColumn dgvChk = new DataGridViewCheckBoxColumn();
                        dgvChk.ValueType = typeof(bool);
                        dgvChk.Name = cntrlnames;

                        dgvChk.HeaderText = Headertext;
                        dgvChk.ToolTipText = ToolTipText;
                        dgvChk.Visible = Visible;
                        dgvChk.FlatStyle= FlatStyle.Flat;
                        dgvChk.Width = width;
                        dgvChk.SortMode = DataGridViewColumnSortMode.Automatic;
                        dgvChk.Resizable = Resizable;
                        dgvChk.DefaultCellStyle.Alignment = cellAlignment;
                        dgvChk.HeaderCell.Style.Alignment = headerAlignment;
                        if (CellTemplateBackColor.Name.ToString() != "Transparent")
                        {
                            dgvChk.CellTemplate.Style.BackColor = CellTemplateBackColor;
                        }
                        dgvChk.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                        customDGV.Columns.Add(dgvChk);
                        break;
                    case GridControlTypes.BoundColumn:
                        DataGridViewColumn col = new DataGridViewTextBoxColumn();
                        col.DataPropertyName = cntrlnames;
                        col.Name = cntrlnames;
                        col.HeaderText = Headertext;
                        col.ToolTipText = ToolTipText;
                        col.Visible = Visible;
                        col.Width = width;
                        col.SortMode = DataGridViewColumnSortMode.Automatic;
                        col.Resizable = Resizable;
                        col.DefaultCellStyle.Alignment = cellAlignment;
                        col.HeaderCell.Style.Alignment = headerAlignment;
                        if (CellTemplateBackColor.Name.ToString() != "Transparent")
                        {
                            col.CellTemplate.Style.BackColor = CellTemplateBackColor;
                        }
                        col.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                        customDGV.Columns.Add(col);
                        break;
                    case GridControlTypes.TextBox:
                        DataGridViewTextBoxColumn dgvText = new DataGridViewTextBoxColumn();
                        //dgvText.ValueType = typeof(decimal);
                        dgvText.DataPropertyName = cntrlnames;
                        dgvText.Name = cntrlnames;
                        dgvText.HeaderText = Headertext;
                        dgvText.ToolTipText = ToolTipText;
                        dgvText.Visible = Visible;
                        dgvText.Width = width;
                        dgvText.SortMode = DataGridViewColumnSortMode.Automatic;
                        dgvText.Resizable = Resizable;
                        dgvText.DefaultCellStyle.Alignment = cellAlignment;
                        dgvText.HeaderCell.Style.Alignment = headerAlignment;
                        if (CellTemplateBackColor.Name.ToString() != "Transparent")
                        {
                            dgvText.CellTemplate.Style.BackColor = CellTemplateBackColor;
                        }
                        dgvText.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                        customDGV.Columns.Add(dgvText);
                        break;
                    case GridControlTypes.ComboBox:
                      System.Windows.Forms.DataGridViewComboBoxColumn dgvcombo = new  System.Windows.Forms.DataGridViewComboBoxColumn();
                        //DataGridViewComboBoxCell dgvcombo = new DataGridViewComboBoxCell();// DataGridViewComboBoxColumn();
                        dgvcombo.ValueType = typeof(decimal);
                        dgvcombo.Name = cntrlnames;
                        dgvcombo.DataSource = dtsource;
                        dgvcombo.DisplayMember = DisplayMember;
                        dgvcombo.ValueMember = ValueMember;
                        dgvcombo.Visible = Visible;
                        dgvcombo.FlatStyle = FlatStyle.Flat;
                        dgvcombo.Width = width;
                        dgvcombo.SortMode = DataGridViewColumnSortMode.Automatic;
                        dgvcombo.Resizable = Resizable;
                        dgvcombo.DefaultCellStyle.Alignment = cellAlignment;
                        dgvcombo.HeaderCell.Style.Alignment = headerAlignment;
                        if (CellTemplateBackColor.Name.ToString() != "Transparent")
                        {
                            dgvcombo.CellTemplate.Style.BackColor = CellTemplateBackColor;

                        }
                        dgvcombo.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                        customDGV.Columns.Add(dgvcombo);
                        break;
                    case GridControlTypes.ComboCell:

                        System.Windows.Forms.DataGridViewComboBoxCell dgvcomboCell = new DataGridViewComboBoxCell();
                        //DataGridViewComboBoxCell dgvcombo = new DataGridViewComboBoxCell();// DataGridViewComboBoxColumn();
                        dgvcomboCell.ValueType = typeof(decimal);
                        //dgvcomboCell.T.Name = cntrlnames;
                        dgvcomboCell.DataSource = dtsource;
                        dgvcomboCell.DisplayMember = DisplayMember;
                        dgvcomboCell.ValueMember = ValueMember;
                        //dgvcomboCell.Visible = Visible;
                        dgvcomboCell.FlatStyle = FlatStyle.Flat;
                        dgvcomboCell.DropDownWidth = width;
                        dgvcomboCell.Sorted = true;
                        dgvcomboCell.InheritedStyle.Alignment = cellAlignment;

                        
                        if (CellTemplateBackColor.Name.ToString() != "Transparent")
                        {
                            dgvcomboCell.InheritedStyle.BackColor = CellTemplateBackColor;

                        }
                        dgvcomboCell.InheritedStyle.ForeColor = CellTemplateforeColor;
                        //customDGV.Columns.Add(dgvcomboCell);



                        break;
                    case GridControlTypes.Button:
                        DataGridViewButtonColumn dgvButtons = new DataGridViewButtonColumn();
                        dgvButtons.Name = cntrlnames;
                        dgvButtons.FlatStyle = FlatStyle.Popup;
                        dgvButtons.DataPropertyName = cntrlnames;
                        dgvButtons.Visible = Visible;
                        dgvButtons.Width = width;
                        dgvButtons.SortMode = DataGridViewColumnSortMode.Automatic;
                        dgvButtons.Resizable = Resizable;
                        dgvButtons.DefaultCellStyle.Alignment = cellAlignment;
                        dgvButtons.HeaderCell.Style.Alignment = headerAlignment;
                        if (CellTemplateBackColor.Name.ToString() != "Transparent")
                        {
                            dgvButtons.CellTemplate.Style.BackColor = CellTemplateBackColor;
                        }
                        dgvButtons.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                        customDGV.Columns.Add(dgvButtons);
                        break;

                    


                }

            }
            catch (Exception exp)
            {
                //...
            }


        }

        #endregion
        //Numeric Textbox event and check for key press event for accepting only numbers for the selected column
        #region Numeric Textbox Events 
        public void NumeriTextboxEvents(DataGridView customDGV, List<int> columnIndexs)
        {
            try
            {

                sDGVs = customDGV;
                listcolumnIndex = columnIndexs;

                customDGV.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dSDGV_EditingControlShowing);
            }
            catch (Exception ex)
            {
                //...
            }
        }

        #region DataGridViewComboBoxColumn control 
        public void DataGridViewCellFormatEvents(DataGridView cDGV, List<CPFSettingsVO> lstCPFSettingsVO)
        {
            try
            {
               _lstCPFSettingsVO = lstCPFSettingsVO;
                sDGVs = cDGV;
                cDGV.CellFormatting += new DataGridViewCellFormattingEventHandler(dSDGV_CellFormatting);
            }
            catch (Exception ex)
            {
                //...
            }
        }


        // In this cell click event,DateTime Picker Control will be added to the selected column
        private void shanuDGVs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DateColumnIndex)
            {
                sDateTimePicker = new DateTimePicker();
                sDGVs.Controls.Add(sDateTimePicker);
                sDateTimePicker.Format = DateTimePickerFormat.Short;
                Rectangle dgvRectangle = sDGVs.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                sDateTimePicker.Size = new Size(dgvRectangle.Width, dgvRectangle.Height);
                sDateTimePicker.Location = new Point(dgvRectangle.X, dgvRectangle.Y);
                // shanuDateTimePicker.Visible = true;
            }

        }


        #endregion


        // grid Editing Control Showing
        private void dSDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress -= new KeyPressEventHandler(itemID_KeyPress);//This line of code resolved my issue
                if (listcolumnIndex.Contains(sDGVs.CurrentCell.ColumnIndex))
                {
                    TextBox itemID = e.Control as TextBox;
                    if (itemID != null)
                    {
                        itemID.KeyPress += new KeyPressEventHandler(itemID_KeyPress);
                    }
                }
            }
            catch (Exception ex)
            {
                //...
            }
        }


        //
        void dSDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //DataGridViewComboBoxColumn cb = (DataGridViewComboBoxColumn)sender;
            //if ( sender.GetType()==typeof(DataGridViewComboBoxColumn) )
            //{

           try{  
            if (_lstCPFSettingsVO.Count > 0 && e.RowIndex<_lstCPFSettingsVO.Count && e.Value == null)
            {

                //PRYear
                //CPFCode
                //AgeGroup
                //SalaryGroup

                // List<CPFSettingsVO>
                //if (this.sDGVs.Columns[e.ColumnIndex].Name == "Artist")
                //switch (e.ColumnIndex)

                switch (this.sDGVs.Columns[e.ColumnIndex].Name.Trim())
                {
                    //case "CPFID":
                    //    this.sDGVs.Rows[e.RowIndex].Cells["CPFID"].Value = _lstCPFSettingsVO[e.RowIndex].CPFID;
                    //    // e..Value =  _lstCPFSettingsVO[e.RowIndex].PRYearGroup_id;
                    //    break;

                    case "PRYear":

                        this.sDGVs.Rows[e.RowIndex].Cells["PRYear"].Value = _lstCPFSettingsVO[e.RowIndex].PRYearGroup_id;
                       // e..Value =  _lstCPFSettingsVO[e.RowIndex].PRYearGroup_id;
                        this.sDGVs.Rows[e.RowIndex].Cells["CPFID"].Value = _lstCPFSettingsVO[e.RowIndex].CPFID;
                     
                       break;
                    //case "CPFCode":
                    //    //e.Value = _lstCPFSettingsVO[e.RowIndex].CpfGroup_Id;
                    //    this.sDGVs.Rows[e.RowIndex].Cells["CPFCode"].Value = _lstCPFSettingsVO[e.RowIndex].CpfGroup_Id;
                    //    break;
                    case "AgeGroup":
                       // e.Value = _lstCPFSettingsVO[e.RowIndex].CPFAgeGroupID;
                       this.sDGVs.Rows[e.RowIndex].Cells["AgeGroup"].Value = _lstCPFSettingsVO[e.RowIndex].CPFAgeGroupID;
                    
                        break;
                    case "SalaryGroup":
                        //e.Value = _lstCPFSettingsVO[e.RowIndex].CPFSALGROUPID;
                        this.sDGVs.Rows[e.RowIndex].Cells["SalaryGroup"].Value = _lstCPFSettingsVO[e.RowIndex].CPFSalGroupId;
                    
                        break;

                    case "CPFTotalShare":
                        //e.Value = _lstCPFSettingsVO[e.RowIndex].CPFSALGROUPID;
                        this.sDGVs.Rows[e.RowIndex].Cells["CPFTotalShare"].Value = _lstCPFSettingsVO[e.RowIndex].CPFTotalShare;
                        
                        break;

                    case "CPFTotalShareMax":
                        //e.Value = _lstCPFSettingsVO[e.RowIndex].CPFSALGROUPID;
                        this.sDGVs.Rows[e.RowIndex].Cells["CPFTotalShareMAX"].Value = _lstCPFSettingsVO[e.RowIndex].CPFTotalShareMAX;

                        break;

                    case "CPFEmpShareMax":
                        //e.Value = _lstCPFSettingsVO[e.RowIndex].CPFSALGROUPID;
                        this.sDGVs.Rows[e.RowIndex].Cells["CPFEmpShareMax"].Value = _lstCPFSettingsVO[e.RowIndex].CPFEmpShareMax;

                        break;

                    case "CPFEmpShare":
                        //e.Value = _lstCPFSettingsVO[e.RowIndex].CPFSALGROUPID;
                        this.sDGVs.Rows[e.RowIndex].Cells["CPFEmpShare"].Value = _lstCPFSettingsVO[e.RowIndex].CPFEmpShare;

                        break;
                    //case "AWFactor":
                    //    //e.Value = _lstCPFSettingsVO[e.RowIndex].CPFSALGROUPID;
                    //    this.sDGVs.Rows[e.RowIndex].Cells["AWFactor"].Value = _lstCPFSettingsVO[e.RowIndex].AwFactor;

                    //    break;

                    case "ChkDel":
                        //clear check box
                        this.sDGVs.Rows[e.RowIndex].Cells["ChkDel"].Value = false;

                        break;

                }
            }
           }
            catch(Exception ex)

           //catch (FormatException)
            {

                // Set to false in case there are other handlers interested trying to
                // format this DataGridViewCellFormattingEventArgs instance.
                e.FormattingApplied = false;
            }
                //if (e.ColumnIndex == 2)
                //{
                //    // DataGridViewComboBoxColumn

                //    //DataTable dt = cb.DataSource as DataTable;
                //    e.Value = "test...";// dt.Rows[0]["c2"];
                //}
            }
        //}




        //Grid Kyey press event
        private void itemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception exp)
            {
                //..
            }
        }
        #endregion

        // Add an datTime Picker control to existing Textbox Column
        #region DateTimePicker control to textbox column
        //public void DateTimePickerEvents(DataGridView cDGV, int columnIndexs,GridEventTypes eventtype)
        //{


        //    //sDGVs = cDGV;
        //    //DateColumnIndex = columnIndexs;
        //    //cDGV.CellClick += new DataGridViewCellEventHandler(shanuDGVs_CellClick);
        //    ////switch (eventtype)
        //    //{
        //    //    case ShanuEventTypes.CellClick:
        //    //        ShanuDGV.CellClick +=new DataGridViewCellEventHandler(shanuDGVs_CellClick);
        //    //        break;
        //    //    case ShanuEventTypes.cellContentClick:
        //    //          ShanuDGV.CellContentClick +=new DataGridViewCellEventHandler(shanuDGVs_CellContentClick);
        //    //        break;
        //    //}

        //    }


        // In this cell click event,DateTime Picker Control will be added to the selected column
        //private void shanuDGVs_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == DateColumnIndex)
        //    {
        //        sDateTimePicker = new DateTimePicker();
        //        sDGVs.Controls.Add(sDateTimePicker);
        //        sDateTimePicker.Format = DateTimePickerFormat.Short;
        //        Rectangle dgvRectangle = sDGVs.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
        //        sDateTimePicker.Size = new Size(dgvRectangle.Width, dgvRectangle.Height);
        //        sDateTimePicker.Location = new Point(dgvRectangle.X, dgvRectangle.Y);
        //       // shanuDateTimePicker.Visible = true;
        //    }

        //}


        #endregion
        // Button Click evnet
        #region Button Click Event
        public void DGVClickEvents(DataGridView cDGV, int columnIndexs, GridEventTypes eventtype)
        {
        try{

           sDGVs = cDGV;
           ClickColumnIndex = columnIndexs;
           cDGV.CellContentClick += new DataGridViewCellEventHandler(shanuDGVs_CellContentClick_Event);

        }
        catch (Exception ex)
        {
            //...
        }
        }
        private void shanuDGVs_CellContentClick_Event(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == ClickColumnIndex)
            {
                MessageBox.Show("Button Clicked " + sDGVs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }
        #endregion
        // Button Click Event to show Color Dialog
        #region Button Click Event to show Color Dialog
        public void colorDialogEvents(DataGridView cDGV, int columnIndexs, GridEventTypes eventtype)
        {


            sDGVs = cDGV;
            ColorColumnIndex = columnIndexs;

            cDGV.CellContentClick += new DataGridViewCellEventHandler(shanuDGVs_CellContentClick);
                  
        }

      
            
          private void shanuDGVs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                if (e.ColumnIndex == ColorColumnIndex)
                {
                    MessageBox.Show("Button Clicked " + sDGVs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                    ColorDialog cd = new ColorDialog();
                    cd.ShowDialog();
                    sDGVs.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = cd.Color;


                }

        }

        #endregion


    }
}
//Enum decalaration for DataGridView Column Type ex like Textbox Column ,Button Column
public enum GridControlTypes { BoundColumn, TextBox, ComboBox, ComboCell, CheckBox, DateTimepicker, Button, NumericTextBox, ColorDialog, ComboBoxColumnEx }
public enum GridEventTypes { CellClick, cellContentClick, EditingControlShowing }
