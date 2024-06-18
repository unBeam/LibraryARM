using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LibraryARM.Scripts.Output
{
    internal class ExcelOut
    {
        public void Out(ListView listView)
        {
            var bookData = listView.ItemsSource as List<BookListViewModel>;
            if (bookData != null)
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Books");

                    worksheet.Cells[1, 1].Value = "Author";
                    worksheet.Cells[1, 2].Value = "Name";
                    worksheet.Cells[1, 3].Value = "Count";
                    worksheet.Cells[1, 4].Value = "BBK";
                    worksheet.Cells[1, 5].Value = "Publishing House";
                    worksheet.Cells[1, 6].Value = "Place Publishing";
                    worksheet.Cells[1, 7].Value = "Year";
                    worksheet.Cells[1, 8].Value = "Count Of Lists";

                    int row = 2;
                    foreach (var book in bookData)
                    {
                        worksheet.Cells[row, 1].Value = book.Author;
                        worksheet.Cells[row, 2].Value = book.Name;
                        worksheet.Cells[row, 3].Value = book.Count;
                        worksheet.Cells[row, 4].Value = book.BBK;
                        worksheet.Cells[row, 5].Value = book.PublishingHouse;
                        worksheet.Cells[row, 6].Value = book.PlacePublishing;
                        worksheet.Cells[row, 7].Value = book.Year;
                        worksheet.Cells[row, 8].Value = book.CountOfLists;
                        row++;
                    }

                    var saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FileName = "Books.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        var filePath = saveFileDialog.FileName;
                        System.IO.File.WriteAllBytes(filePath, package.GetAsByteArray());
                        MessageBox.Show("Файл сохранен");
                    }
                }
            }
        }
    }
}
