using Bootcamp_lll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bootcamp_lll.Controllers
{
    public class ContestantController
    {
        List<Contestant> contestants = new List<Contestant>()
        {
            new Contestant{ Id = 1, Name = "Luis", LastName = "Mendoza", Grade = "Secundaria", SubjectId = 1, UserName = "luMen", Password = "hola", Email = "lu@gmail.com" },
            new Contestant{ Id = 2, Name = "Carlos", LastName = "Ibañez", Grade = "Secundaria", SubjectId = 1, UserName = "carI", Password = "hola", Email = "carlos@gmail.com" },
            new Contestant{ Id = 3, Name = "Rocio", LastName = "García", Grade = "Universitario", SubjectId = 3, UserName = "RoCia", Password = "hola", Email = "rocio@gmail.com" },
            new Contestant{ Id = 4, Name = "Antonio", LastName = "Ugarte", Grade = "Postgrado", SubjectId = 4, UserName =  "UgarteNio", Password = "hola", Email = "antonio@gmail.com" },
            new Contestant{ Id = 5, Name= "Estephany", LastName = "Aguilar", Grade = "Universitario", SubjectId = 3, UserName = "Estelar", Password = "hola", Email = "aguilar@gmail.com"},
        };

        public List<Contestant> GetMany()
        {
            return contestants;
        }

        public void AddNew(Contestant contestant)
        {
            this.contestants.Add(contestant);
        }

        public DataGrid GetContestants(DataGrid dataGrid)
        {
            SubjectController subjectController = new();
            var query = contestants.Join(subjectController.GetMany(), c => c.SubjectId, s => s.Id,
                (c, s) => new
                {
                    ID = c.Id,
                    NameC = c.Name,
                    LastNameC = c.LastName,
                    EmailC = c.Email,
                    GradeC = c.Grade,
                    SubjectName = s.Name
                });
            foreach(var item in  query)
                dataGrid.Items.Add(item);
            return dataGrid;
        }
    }
}
