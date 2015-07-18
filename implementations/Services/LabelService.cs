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
        public List<Label> GetLabel(int ProjectId, int TaskId)
        {
            //var model = from x in context.Set<Label>()
            //            where x.Project.ProjectId == ProjectId &&
            //                  x.
            //            select x;
            //return model.ToList();
            var model = new List<Label>();
            return model;
        }
    }
}
