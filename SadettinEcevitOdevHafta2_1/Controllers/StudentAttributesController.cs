using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SadettinEcevitOdevHafta2_1.Attributes;
using SadettinEcevitOdevHafta2_1.Models;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SadettinEcevitOdevHafta2_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttributesController : ControllerBase
    {
        [HttpPost("add")]
        public IActionResult Add(Student student)
        {
            IActionResult retVal;

            if (Validate(student))
            {
                retVal = Ok(student);
            }
            else
            {
                retVal = BadRequest();
            }

            return retVal;
        }

        [HttpGet("getscript")]
        public IActionResult GetScript()
        {
            IActionResult retVal;

            string res = Validate();

            if (!string.IsNullOrEmpty(res))
            {
                retVal = Ok(res);
            }
            else
            {
                retVal = BadRequest();
            }

            return retVal;
        }

        string Validate()
        {
            string retVal = string.Empty;

            Type type = typeof(Student);

            PropertyInfo[]? pi = type.GetProperties();

            string tabloAdi = nameof(Student);
            string kolonları = "\n";

            foreach (var item in pi)
            {
                var attr2 = item.GetCustomAttribute<ColumnAttribute>() ?? default;
                kolonları += "->" + item.Name + ", Tipi: " + item.PropertyType.ToString() + (attr2 != null ? (attr2.Required ? ", Zorunlu" : ", Zorunlu Değil") : ", Zorunlu Değil") + "\n";

            }
            retVal += "Tablo Adı: " + tabloAdi + "\n - Kolonları: " + kolonları + " - ";

            return retVal;
        }

        bool Validate(Student student)
        {
            bool retVal = true;

            Type type = typeof(Student);
            var attr = type.GetCustomAttribute<TableAttribute>() ?? default;
            var deger = attr.Deger;
            Regex r = new Regex($"[{deger}]");

            PropertyInfo[]? pi = type.GetProperties();

            foreach (var item in pi)
            {
                object data = item.GetValue(student, null);
                var objType = data.GetType();

                if (objType == typeof(string))
                {
                    retVal = r.IsMatch(data.ToString(), 0);

                    if (retVal)
                    {
                        break;
                    }
                }
            }
            return !retVal;
        }
    }

}

