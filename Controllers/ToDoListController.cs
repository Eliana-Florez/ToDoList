using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 

    public class ToDoListController : Controller
    {
        public static List<Tasks> myList = new List<Tasks>();

        [HttpGet]
        public ActionResult<IEnumerable<Tasks>> Get()
        {
            return myList;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Tasks>> Get(string id)
        {
            return myList.Where(item => item.id == id).ToList();
        }

        [HttpPost]
        public ActionResult<IEnumerable<string>> Post([FromBody] Tasks item) {

            myList.Add(item);
            return new string[] { "status", "200" };
        }


        [HttpPut]
        public ActionResult<IEnumerable<string>> put([FromBody] Tasks itemtask)
        {
            int index = 0;
            foreach (Tasks item in myList)
            {
                if (item.id == itemtask.id)
                {
                    myList[index].taskName = itemtask.taskName;
                    myList[index].isComplete = itemtask.isComplete;
                    return new string[] { "204", "Actualizado!!" };
                }
                index++;
            }
            return new string[] { "101", "Registro no encontrado!!" };
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<string>> Delete(string id)
        {
            int index = 0;
            foreach (Tasks item in myList)
            {
                if (item.id == id)
                {
                    myList.Remove(item);
                    return new string[] { "200", "Tarea Eliminada!!" };
                }
                index++;
            }
            return new string[] { "101", "Registro no encontrado!!" };
        }
    }
}
