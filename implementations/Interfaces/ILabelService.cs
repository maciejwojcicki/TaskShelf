using database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace implementations.Interfaces
{
    public interface ILabelService
    {
        List<Label> GetLabels();
    }
}
