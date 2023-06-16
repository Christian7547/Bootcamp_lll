using Bootcamp_lll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.IO;

namespace Bootcamp_lll.Controllers
{
    public class ContestantController
    {
        List<Contestant> contestants = new List<Contestant>();
        string path = @"mi_archivo.json";

        public List<Contestant> GetMany()
        {
            return contestants;
        }

        public void AddNew(Contestant contestant)
        {
            this.contestants.Add(contestant);
            Save();
        }

        public void Save()
        {
            string jsonSerialize = JsonConvert.SerializeObject(contestants, Formatting.Indented);   
            File.WriteAllText(path, jsonSerialize);
        }

        public void Recuperar()
        {
            try
            {
                string jsonDeserialize = File.ReadAllText(path);
                contestants = JsonConvert.DeserializeObject<List<Contestant>>(jsonDeserialize)!;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                    EmailC = c.UserName,
                    GradeC = c.Grade,
                    SubjectName = s.Name
                });
            foreach(var item in  query)
                dataGrid.Items.Add(item);
            return dataGrid;
        }

        public bool Update(Contestant contestant)
        {
            var query = contestants.Find(c => c.Id.Equals(contestant.Id));
            if (query != null)
            {
                contestant = query;
                return true;
            }
            return false;
        }
    }
}
