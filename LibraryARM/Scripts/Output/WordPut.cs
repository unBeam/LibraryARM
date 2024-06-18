using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using LibraryARM.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryARM.Scripts.Output
{
    internal class WordPut
    {
        public void CreateWordDocument(Reader reader)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = $"Reader_{reader.FIO.Replace(" ", "_")}.docx",
                DefaultExt = ".docx",
                Filter = "Word Documents (*.docx)|*.docx"
            };

            bool? result = saveFileDialog.ShowDialog();

            if (result == true)
            {
                string filePath = saveFileDialog.FileName;
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                {

                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = new Body();

                    body.Append(new Paragraph(new Run(new Text($"ФИО: {reader.FIO}"))));
                    body.Append(new Paragraph(new Run(new Text($"Номер билета: {reader.TicketNumber}"))));
                    body.Append(new Paragraph(new Run(new Text($"Дата рождения: {reader.DateOfBirth}"))));
                    body.Append(new Paragraph(new Run(new Text($"Место работы: {reader.PlaceToWork}"))));
                    body.Append(new Paragraph(new Run(new Text($"Контактный номер: {reader.Number}"))));

                    mainPart.Document.Append(body);
                    mainPart.Document.Save();
                }
                MessageBox.Show($"Файл сохранен");
            }
            else
            {
                MessageBox.Show("Сохранение файла отменено.");
            }
        }
    }
}
