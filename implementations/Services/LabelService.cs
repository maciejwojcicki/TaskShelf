using database;
using database.Entities;
using implementations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace implementations.Services
{
    public class LabelService:ILabelService
    {
        private Model1 context;

        public LabelService()
        {

            this.context = new Model1();
            this.context.Configuration.LazyLoadingEnabled = false;
            this.context.Database.Log = (text) =>
            {
                Console.WriteLine(text);
            };
        }
        public List<Label> GetLabel(int ProjectId)
        {
            var project = context.Set<Project>().Single(p=>p.ProjectId == ProjectId);
                          
            var model = from x in context.Set<Label>()
                        where x.Project.ProjectId.Equals(project.ProjectId)
                        select x;




            return model.ToList();
        }
    }
}
