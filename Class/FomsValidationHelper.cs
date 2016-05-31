using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace ATTNPAY.Class
{
    class FomsValidationHelper
    {

        ErrorProvider errorProvider1;

        public FomsValidationHelper()
        {
            errorProvider1 = new ErrorProvider();
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        public bool validateForm( MetroForm frmMetroForm)
        {
            try
            {

                bool isValid = true;

                errorProvider1.SetError(frmMetroForm.Controls["tbCompanyName"], frmMetroForm.Controls["tbCompanyName"].Tag.ToString());
                // get all the TableLayoutPanel on the current Tab Page.
              //  var cParentCtrlList = frmMetroForm.Controls.Cast<Control>().Where(c =>  c.Tag != null).ToList();
                    //.GetType() == typeof(TableLayoutPanel) || c.GetType() ==


                var cParentCtrlList = frmMetroForm.Controls.Cast<Control>().Where(c => c.GetType() == typeof(Panel)).ToList();
                //.GetType() == typeof(TableLayoutPanel) || c.GetType() ==




                // typeof(Panel)).ToList();
                // iterate each parent TableLayoutPanel and find the individual controls on it.
                // foreach (TableLayoutPanel tPanelitems in cParentCtrlList)
                foreach (Control  frmitems in cParentCtrlList)
                {

                    // find all the child controls on each tPanelitems
                    var ctChildsList = frmitems.Controls.Cast<Control>().Where(c => c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) ||
                     c.GetType() == typeof(CheckBox) || c.GetType() == typeof(Panel) ||
                     c.GetType() == typeof(MetroCheckBox) || c.GetType() == typeof( MetroComboBox) ||
                     c.GetType() == typeof(MetroRadioButton)).ToList();//||  
                     
                    // iterate each controls within each TableLayoutPanelPanels

                    foreach (Control items in ctChildsList)
                    {
                        if (items is TextBox||items is  MetroTextBox  )
                        {
                            if (items.Tag != null)
                            {
                                if (items.Text == "")
                                {
                                    errorProvider1.SetError(items, items.Tag.ToString());
                                    isValid = false;
                                }
                                else
                                {
                                    errorProvider1.SetError(items, "");
                                }
                            }
                        }//if (items is TextBox)

                        
                        if (items is ComboBox || items is  MetroComboBox)
                        {

                            if (items.Tag != null)
                            {

                                if (items.Text == "")
                                {

                                    errorProvider1.SetError(items, items.Tag.ToString());
                                    isValid = false;
                                }
                                else
                                {
                                    errorProvider1.SetError(items, "");
                                }
                            }
                        }//if (items is ComboBox)

                        if (items is CheckBox || items is   MetroCheckBox)
                        {

                            //bool bChecked=  ((CheckBox) items).Checked;
                            
                            if (items.Tag != null)
                            {

                                //if (items.Text == "False")
                                if (((CheckBox)items).Checked == false)
                                {

                                    errorProvider1.SetError(items, items.Tag.ToString());
                                    isValid = false;
                                }
                                else
                                {
                                    errorProvider1.SetError(items, "");
                                }
                            }
                        }//if (items is ComboBox)

                        
                        if (items is Panel|| items is  MetroPanel)
                        {

                            foreach (Control ctrl in items.Controls)
                            {

                                if (ctrl is TextBox || items is   MetroTextBox)
                                {

                                    if (ctrl.Tag != null)
                                    {
                                        if (ctrl.Text == "")
                                        {
                                            errorProvider1.SetError(ctrl, ctrl.Tag.ToString());
                                            isValid = false;
                                        }
                                        else
                                        {
                                            errorProvider1.SetError(ctrl, "");
                                        }
                                    }

                                }


                            }

                        }//if (items is Panel)
                        /*
                        if (items is TableLayoutPanel || items is  MetroFramework.Controls..MetroComboBox)
                        {

                            foreach (Control ctrl in items.Controls)
                            {
                                if (ctrl is TextBox)
                                {
                                    if (ctrl.Tag != null)
                                    {
                                        if (ctrl.Text == "")
                                        {
                                            errorProvider1.SetError(ctrl, ctrl.Tag.ToString());
                                            isValid = false;
                                        }
                                        else
                                        {
                                            errorProvider1.SetError(ctrl, "");
                                        }
                                    }

                                }
                            }

                        }//if (items is TableLayoutPanel)
                        */

                    }// foreach (Control items in ctChildsList)

                }// foreach ( TableLayoutPanel tPanelitems in cParentCtrlList)

                return (isValid);
            }
            catch (Exception exp)
            {
                return false;
            }
        }

    }
}
