using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;

namespace UseMatlab_0505
{
    public class AccessExcel
    {
        private static AccessExcel m_sigleton_accessexcel;
        private ExcelApplication m_excel;
        private Workbook m_workbook;
        private Worksheet m_worksheet;

        private AccessExcel()
        {
            m_excel = new ExcelApplication();
            m_excel.DisplayAlerts = false;
            m_excel.AlertBeforeOverwriting = false;
        }
        public static AccessExcel GetInstance()
        {
            if (null == m_sigleton_accessexcel)
            {
                m_sigleton_accessexcel = new AccessExcel();
            }
            return m_sigleton_accessexcel;
        }
        public string OpenExcelFile(string file_name)
        {
            try{
                // 当前为缺省参数
                m_workbook = m_excel.Workbooks.Open(file_name,0,false);
                m_excel.Visible = false;
                m_worksheet = (Worksheet)m_workbook.Worksheets[1];
                return string.Empty;
            }catch(System.Exception ex){
                return ex.ToString();
            }
        }
        public void CloseExcelFile()
        {
            if (null != m_excel){
                m_excel.Quit();
            }
        }
        public string ReadData(int row, int col, out string data)
        {
            try{
                Range range = (Range)m_worksheet.Cells[row,col];
                data = range.Text;
                return string.Empty;
            }catch (System.Exception ex) {
                data = string.Empty;
                return ex.ToString();
            }
        }
        public string WriteData(int row, int col, string data)
        {
            try {
                m_worksheet.Cells[row, col] = data;
                return string.Empty;
            }catch (System.Exception ex) {
                return ex.ToString();
            }
        }
        public string SaveExcelFile(string file_name)
        {
            try{ 
                // 当前为缺省参数
                m_workbook.SaveAs(file_name,System.Reflection.Missing.Value,System.Reflection.Missing.Value);
                return string.Empty;
            }catch(System.Exception ex){
                return ex.ToString();
            }
        }
        public void SetExcelVisible()
        {
            m_excel.Visible = true;
        }
    }
}
