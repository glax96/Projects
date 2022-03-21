using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobiliEvidencija.Models
{
    public class Automobil
    {
        public int ID { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Godina { get; set; }
        public string KonjskaSnaga { get; set; }
    }
}
