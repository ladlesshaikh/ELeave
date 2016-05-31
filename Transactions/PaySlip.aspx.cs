using ATTNPAY.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ATTNPAY;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.tool.xml;
using CreateDoc;
using System.Web.UI.HtmlControls;

namespace BizHRMS.Transactions
{
    public partial class PaySlip : System.Web.UI.Page
    {
        protected void  Page_Load(object sender, EventArgs e)
        {
            //Account_Name.InnerHtml = "Welcome, " + GlobalVariable.UserName;
            
        }

        [WebMethod]
        public static List<object> GetPaySlipDetails(int month_val)
        {
            try
            {
                List<object> lstRes = new List<object>();
                PayslipListBUS PBus = new PayslipListBUS();
                PayslipListVO pbusVO = new PayslipListVO();
                string MemCode = GlobalVariable.UserCode;
                pbusVO = PBus.GetPayslip(MemCode, month_val, 4);
                lstRes.Add(pbusVO.PayslipHeader);
                lstRes.Add(pbusVO.LstPayslipLoanDet);
                lstRes.Add(pbusVO.LstPayslipEarning);
                lstRes.Add(pbusVO.LstPayslipDeduction);
                return lstRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public void GenPDFDIV()
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            employeelistDiv.RenderControl(htmlTextWriter);
            StringReader stringReader = new StringReader(stringWriter.ToString());
            //Document Doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(Doc);
            //PdfWriter.GetInstance(Doc, Response.OutputStream);
            // Doc.Open();
            /// htmlparser.Parse(stringReader);
            // Doc.Close();
            // Response.Write(Doc);
            Response.End();


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            List<object> lstRes = new List<object>();
            PayslipListBUS PBus = new PayslipListBUS();
            PayslipListVO pbusVO = new PayslipListVO();
            string month = ddl_month.Value;
            int monthval = Convert.ToInt32(month);
            string MemCode = GlobalVariable.UserCode;
            pbusVO = PBus.GetPayslip(MemCode, monthval, 4);
            lstRes.Add(pbusVO.PayslipHeader);
            lstRes.Add(pbusVO.LstPayslipLoanDet);
            lstRes.Add(pbusVO.LstPayslipEarning);
            lstRes.Add(pbusVO.LstPayslipDeduction);
            if(pbusVO.LstPayslipEarning.Count == 0)
            {
                return;
            }

            List<CompanyVO> lstComp = new List<CompanyVO>();
            CompanyBUS bus = new CompanyBUS();
            lstComp = bus.getCompanyDetails();

            //Report Container
            HtmlGenericControl ReportContainer = new HtmlGenericControl("div");
            ReportContainer.Style.Add("margin", "50px");
            //Company Name
            HtmlGenericControl CompName = new HtmlGenericControl("h1");
            CompName.Style.Add("margin-top", "5px");
            CompName.Style.Add("margin-bottom", "5px");
            CompName.Style.Add("text-align", "center");
            CompName.InnerText = lstComp[0].Company_Name;
            //Company Address

            HtmlGenericControl CompAddr = new HtmlGenericControl("p");
            CompAddr.Style.Add("margin-top", "0px");
            CompAddr.Style.Add("margin-bottom", "5px");
            CompAddr.Style.Add("text-align", "center");
            CompAddr.InnerHtml = lstComp[0].Address + "," + lstComp[0].Contact;

            HtmlGenericControl country = new HtmlGenericControl("p");
            country.Style.Add("margin-top", "0px");
            country.Style.Add("margin-bottom", "5px");
            country.Style.Add("text-align", "center");
            country.InnerHtml = lstComp[0].Country;

            HtmlGenericControl DocHeading = new HtmlGenericControl("h4");
            DocHeading.Style.Add("text-align", "center");
            DocHeading.Style.Add("text-decoration", "underline");
            DocHeading.InnerHtml = "PAYSLIP";

            List<PayslipHeaderVO> lstHeader = new List<PayslipHeaderVO>();
            //lstHeader = pbusVO.PayslipHeader;
            HtmlGenericControl HeaderTab = new HtmlGenericControl("table");
            HeaderTab.Style.Add("width", "100%");
            HeaderTab.Style.Add("margin-top", "50px");
            HeaderTab.Style.Add("margin", "50px");
            HeaderTab.InnerHtml = "";
            HeaderTab.InnerHtml += "<tr><td style='font-weight:bold;padding-left:10px;'>Member name:</td><td style='padding-left:10px;width:180px;'>" + ((ATTNPAY.Core.PayslipHeaderVO)(lstRes[0])).Member_Name + "</td>";
            HeaderTab.InnerHtml += "<td style='font-weight:bold;padding-left:10px;'>Branch:</td><td style='padding-left:10px;'>" + ((ATTNPAY.Core.PayslipHeaderVO)(lstRes[0])).Branch_name + "</td>";
            HeaderTab.InnerHtml += "<td style='font-weight:bold;padding-left:10px;'>Type:</td><td style='padding-left:10px;'>" + ((ATTNPAY.Core.PayslipHeaderVO)(lstRes[0])).Employee_type + "</td></tr>";

            HeaderTab.InnerHtml += "<tr><td style='font-weight:bold;padding-left:10px;'>Designation:</td><td style='padding-left:10px;'>" + ((ATTNPAY.Core.PayslipHeaderVO)(lstRes[0])).Designation + "</td>";
            HeaderTab.InnerHtml += "<td style='font-weight:bold;padding-left:10px;'>Department:</td><td style='padding-left:10px;'>" + ((ATTNPAY.Core.PayslipHeaderVO)(lstRes[0])).Department_name + "</td>";
            HeaderTab.InnerHtml += "<td style='font-weight:bold;padding-left:10px;'></td></tr>";

            HtmlGenericControl break1 = new HtmlGenericControl("hr");


            HtmlGenericControl DedEarn = new HtmlGenericControl("table");
            DedEarn.Style.Add("width", "100%");
            DedEarn.Style.Add("margin-top", "10px");
            DedEarn.Style.Add("margin", "50px");
            DedEarn.Attributes.Add("border", "1");
            DedEarn.InnerHtml = "";
            DedEarn.InnerHtml += "<tr><td style='padding:10px;'><b>Earnings</b></td><td style='padding:10px;'><b>Deduction</b></td></tr>";
            List<PayslipEDVO> lstEarning = new List<PayslipEDVO>();
            lstEarning = pbusVO.LstPayslipEarning;

            DedEarn.InnerHtml += "<tr><td>";
            DedEarn.InnerHtml += "<table style='width:100%;'>";
            DedEarn.InnerHtml += "<tr>";
            DedEarn.InnerHtml += "<td><b>Description</b></td><td><b>Actual Earning</b></td><td><b>Amount</b></td>";
            DedEarn.InnerHtml += "</tr>";
            for (var i=0;i<lstEarning.Count;i++)
            {
                DedEarn.InnerHtml += "<tr>";
                DedEarn.InnerHtml += "<td>"+ lstEarning[i].Description + "</td><td>"+ lstEarning[i].Actual_earning + "</td><td>" + lstEarning[i].Amount + "</td>";
                DedEarn.InnerHtml += "</tr>";
            }
            DedEarn.InnerHtml += "</table>";
            DedEarn.InnerHtml += "</td><td>";
            List<PayslipEDVO> LstDeduction = new List<PayslipEDVO>();
            LstDeduction = pbusVO.LstPayslipDeduction;
            DedEarn.InnerHtml += "<table style='width:100%;'>";
            DedEarn.InnerHtml += "<tr>";
            DedEarn.InnerHtml += "<td><b>Description</b></td><td><b>Actual Earning</b></td><td><b>Amount</b></td>";
            DedEarn.InnerHtml += "</tr>";
            for (var i = 0; i < LstDeduction.Count; i++)
            {
                DedEarn.InnerHtml += "<tr>";
                DedEarn.InnerHtml += "<td>" + LstDeduction[i].Description + "</td><td>" + LstDeduction[i].Actual_earning + "</td><td>" + LstDeduction[i].Amount + "</td>";
                DedEarn.InnerHtml += "</tr>";
            }
            DedEarn.InnerHtml += "</table>";
            DedEarn.InnerHtml += "</td></tr>";


            //Balance Details
            HtmlGenericControl Details = new HtmlGenericControl("table");
            Details.Style.Add("width", "100%");
            Details.Style.Add("margin-top", "10px");
            Details.Style.Add("margin", "50px");
            Details.InnerHtml = "";
            Details.InnerHtml += "<tr><td style='font-weight:bold;padding-left:10px;'>Rate:</td><td style='padding-left:10px;'>" + ((ATTNPAY.Core.PayslipHeaderVO)(lstRes[0])).Dailypayrate+ "</td>";
            Details.InnerHtml += "<td style='font-weight:bold;padding-left:10px;'>Hourly Rate:</td><td style='padding-left:10px;'>" + ((ATTNPAY.Core.PayslipHeaderVO)(lstRes[0])).Hourlyrate+ "</td>";
            Details.InnerHtml += "<td style='font-weight:bold;padding-left:10px;'>Pay Day(s):</td><td style='padding-left:10px;'>" + ((ATTNPAY.Core.PayslipHeaderVO)(lstRes[0])).Pay_day + "</td>";
            Details.InnerHtml += "<td style='font-weight:bold;padding-left:10px;'>Month:</td><td style='padding-left:10px;'>January</td>";
            Details.InnerHtml += "<td style='font-weight:bold;padding-left:10px;'>Payment mode:</td><td style='padding-left:10px;'>" + ((ATTNPAY.Core.PayslipHeaderVO)(lstRes[0])).PaymentMode + "</td></tr>";

            HtmlGenericControl break2 = new HtmlGenericControl("hr");

            //Summary
            HtmlGenericControl Summary = new HtmlGenericControl("table");
            Summary.Style.Add("width", "100%");
            Summary.Style.Add("margin-top", "10px");
            Summary.Style.Add("margin", "50px");
            Summary.Attributes.Add("border", "1");
            Summary.InnerHtml = "";
            Summary.InnerHtml += "<tr><td colspan='2' style='text-align:right;padding:10px;'><b>Summary</b></td></tr>";
            Summary.InnerHtml += "<tr><td  style='text-align:right;width:100%;padding:5px;'>Earnings</td><td style='padding:5px;'>" + ((ATTNPAY.Core.PayslipHeaderVO)(lstRes[0])).Total_earning+ "</td></tr>";
            Summary.InnerHtml += "<tr><td  style='text-align:right;width:100%;padding:5px;'>Deduction</td><td style='padding:5px;'>" + ((ATTNPAY.Core.PayslipHeaderVO)(lstRes[0])) .Total_deduction+ "</td></tr>";
            Summary.InnerHtml += "<tr><td  style='text-align:right;width:100%;padding:5px;'><b>Net Pay</b></td><td style='padding:5px;'><b>" + ((ATTNPAY.Core.PayslipHeaderVO)(lstRes[0])).Net_pay + "</b></td></tr>";

            HtmlGenericControl break3 = new HtmlGenericControl("hr");

            ReportContainer.Controls.Add(CompName);
            ReportContainer.Controls.Add(CompAddr);
            ReportContainer.Controls.Add(country);
            ReportContainer.Controls.Add(break1);
            ReportContainer.Controls.Add(DocHeading);
            ReportContainer.Controls.Add(HeaderTab);
            ReportContainer.Controls.Add(break2);
            ReportContainer.Controls.Add(Details);
            ReportContainer.Controls.Add(DedEarn);
            ReportContainer.Controls.Add(Summary);

            ControlContainer.Controls.Add(ReportContainer);





            string strHtml = null;
            MemoryStream memStream = new MemoryStream();
            StringWriter strWriter = new StringWriter();
            //Console.Write(tdDEd.InnerHtml);
            //Server.Execute("ConvertHTMLtoPDF.aspx", strWriter);
            //strHtml = strWriter.ToString();
            //strWriter.Close();
            //strWriter.Dispose();

            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);

            ControlContainer.RenderControl(htmlTextWriter);
            
            StringReader stringReader = new StringReader(stringWriter.ToString());
            
            iTextSharp.text.Image addLogo = default(iTextSharp.text.Image);
            addLogo = iTextSharp.text.Image.GetInstance(Server.MapPath("Files") + "/logo.jpg");
            string strFileShortName = "test" + DateTime.Now.Ticks + ".pdf";
            string strFileName = HttpContext.Current.Server.MapPath("Files\\" + strFileShortName);
            iTextSharp.text.Document docWorkingDocument = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 20, 20, 20, 20);
            StringReader srdDocToString = null;
            try
            {
                PdfWriter pdfWrite = default(PdfWriter);
                pdfWrite = PdfWriter.GetInstance(docWorkingDocument, new FileStream(strFileName, FileMode.Create));
                srdDocToString = new StringReader(stringWriter.ToString());// strHtml);
                docWorkingDocument.Open();
                addLogo.ScaleToFit(100, 100);
                addLogo.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                docWorkingDocument.Add(addLogo);
                XMLWorkerHelper.GetInstance().ParseXHtml(pdfWrite, docWorkingDocument, srdDocToString);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if ((docWorkingDocument != null))
                {
                    docWorkingDocument.Close();
                    docWorkingDocument.Dispose();
                }
                if ((srdDocToString != null))
                {
                    srdDocToString.Close();
                    srdDocToString.Dispose();
                }
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myscript", "window.open('files/" + strFileShortName + "','_blank','location=0,menubar=0,status=0,titlebar=0,toolbar=0');", true);
        }


    }
}