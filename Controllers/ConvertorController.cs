using Microsoft.AspNetCore.Mvc;
using System.Xml;
using zadaniya.Data;
using zadaniya.Entites;
using zadaniya.Services;
using System.Xml.Linq;

namespace zadaniya.Controller;

[ApiController]
[Route("api/[controller]")]
public class ConvertorController:ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<ConvertorController> _logger;

    public ConvertorController(ILogger<ConvertorController> logger,AppDbContext context)
    {
        _context = context;
        _logger = logger;
    }
    [HttpPost]
    [Route("csvToXml")]
    public async Task<IActionResult> GetAsyncCsv(IFormFile file) 
    {
        if(System.IO.Path.GetExtension(file.FileName).Substring(1).ToLower()!="csv")
        {
            return BadRequest("File type is invalid. Allowed only .csv .");
        }
        var templates=FileToEntityService.CSVFormFileToTemplate(file);
        var resultFile=TemplateToXMLFile(templates);
        await _context.Templates.AddRangeAsync(templates);
        await _context.SaveChangesAsync();
       
        return resultFile;

    }

    [HttpPost]
    [Route("xlsxToXml")]
    public async Task<IActionResult> GetAsyncXlsx(IFormFile file)
    {
        if(System.IO.Path.GetExtension(file.FileName).Substring(1).ToLower()!="xlsx")
        {
                return BadRequest("File type is invalid. Allowed only .xlsx .");
        }  
        
        var templates=FileToEntityService.XLSXIFormFileToTemplate(file);
        await _context.Templates.AddRangeAsync(templates);
        await _context.SaveChangesAsync();
        var resultFile=TemplateToXMLFile(templates);

        return resultFile;
    }
    [HttpGet]
    [Route("getAll")]
    public IActionResult Get()=>TemplateToXMLFile(_context.Templates.ToList());
    private FileContentResult TemplateToXMLFile(List<Template> templates)
    {
        XElement people = new XElement("people");
        templates.ForEach(e =>{
            XElement persons = new XElement("person");
            
            persons.Add(new XAttribute("name", e.PesonName ), new XAttribute("age", e.Age));

            XElement pets = new XElement("pets");
            XElement pet = new XElement("pet");
            XElement pet1 = new XElement("pet");
            XElement pet2 = new XElement("pet");

            if(e.Pet1 != "-")
            {
               pet.Add(new XAttribute("name",e.Pet1),new XAttribute("type",e.Pet1Type)); 
               pets.Add(pet);
            }

            if(e.Pet2 != "-")
            {
             pet1.Add( new XAttribute("name",e.Pet2),new XAttribute("type",e.Pet2Type));
             pets.Add(pet1);
            }

            if(e.Pet3 != "-"){
                pet2.Add(new XAttribute("name",e.Pet3),new XAttribute("type",e.Pet3Type));
                pets.Add(pet2);
            }
            
            persons.Add(pets);
            people.Add(persons);
        });

        XmlDocument xml = new XmlDocument();
        xml.LoadXml(people.ToString());

        using MemoryStream xmlStream = new MemoryStream();
        xml.Save(xmlStream);

        var file=new FileContentResult(xmlStream.ToArray(), "application/xml")
        {
            FileDownloadName = "Export template"
        };
        return file;
        
        
    }
}