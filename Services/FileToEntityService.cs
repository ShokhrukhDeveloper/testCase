using System.Xml.Serialization;
using ClosedXML.Excel;
using zadaniya.Entites;

namespace zadaniya.Services;
 public class FileToEntityService
{
    public static List<Template> XLSXIFormFileToTemplate(IFormFile formFile)
    {
         var sm = formFile.OpenReadStream();
        List<Template> templates = new List<Template>();
        using XLWorkbook excelWorkbook = new XLWorkbook(sm);
        var xlWorksheet = excelWorkbook.Worksheet(1);
        var range = xlWorksheet.Range(xlWorksheet.FirstCellUsed(), xlWorksheet.LastCellUsed());
        var col = range.ColumnCount();
        var row = range.RowCount();
        for(int i = 1; i <= row; i++)
        {
            var template = new Template()
            {
                PesonName = xlWorksheet.Cell(i,1).Value.ToString(),
                Age = xlWorksheet.Cell(i, 2).Value.ToString(),
                Pet1 = xlWorksheet.Cell(i, 3).Value.ToString(),
                Pet1Type = xlWorksheet.Cell(i, 4).Value.ToString(),
                Pet2 = xlWorksheet.Cell(i, 5).Value.ToString(),
                Pet2Type = xlWorksheet.Cell(i, 6).Value.ToString(),
                Pet3 = xlWorksheet.Cell(i, 6).Value.ToString(),
                Pet3Type = xlWorksheet.Cell(i, 7).Value.ToString()
            };
            templates.Add(template);
        }
        return templates;
    }
       public static List<Template> CSVFormFileToTemplate(IFormFile formFile)
    {

            var stream=formFile.OpenReadStream();
        List<Template> templates = new List<Template>();
        StreamReader sr = new StreamReader(stream);

        string? line;
        string[] row = new string[8];
        sr.ReadLine();
        while ((line = sr.ReadLine()) != null)
            {

            row = line.Split(',');

            var template = new Template()
            {
                PesonName=row[0],
                Age=row[1],
                Pet1=row[2] ,
                Pet1Type = row[3],
                Pet2 = row[4],
                Pet2Type = row[5],
                Pet3 = row[6],
                Pet3Type = row[7]
            };
            templates.Add(template);
            }




        return templates;
    }
    
}