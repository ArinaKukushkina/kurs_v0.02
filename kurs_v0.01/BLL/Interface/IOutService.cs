using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IOutService
    {
        List<Model.Out> Find(int st, int book, List<Model.Out> list);
    }
}
