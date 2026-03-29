using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_Tap_4.Models
{
    internal class Beam
    {
        public string Id { get; set; }
        public string Mark { get; set; }
        public string Story { get; set; }
        public double Length { get; set; }
        public double Volume { get; set; }
        public EtabsAPI_Frame Frame { get; set; }
        public ObservableCollection<EtabsAPI_FrameForce> FrameForces { get; set; }
    }
}
