using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs_v0._01.Model
{
    public class Book
    {
        public List<BLL.Model.Book> onboard { get; set; }
        public List<BLL.Model.Book> offboard { get; set; }
        public List<BLL.Model.Book> lost { get; set; }
        public int onboard_count { get; set; }
        public int offboard_count { get; set; }
        public int lost_count { get; set; }
        public string name { get; set; }
        public Book() { }
        public Book(List<BLL.Model.Book> spis)
        {
            onboard = new List<BLL.Model.Book>();
            offboard = new List<BLL.Model.Book>();
            lost = new List<BLL.Model.Book>();
            foreach (BLL.Model.Book tmp in spis)
            {
                switch (tmp.Status_id)
                {
                    case 2:
                        onboard.Add(tmp);
                        break;
                    case 1:
                        offboard.Add(tmp);
                        break;
                    case 3: 
                        lost.Add(tmp);
                        break;
                }
                onboard_count = onboard.Count;
                offboard_count = offboard.Count;
                lost_count = lost.Count;
                name = spis.FirstOrDefault().Name;
            }
        }
    }
}
