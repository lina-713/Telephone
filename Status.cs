using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telphone
{
    internal class Status
    {
        public int Id { get; set; }
        [DisplayName("Имя статуса")]
        public string Name { get; set; }
        public string Count_Subs { get; set; }
    }
}
