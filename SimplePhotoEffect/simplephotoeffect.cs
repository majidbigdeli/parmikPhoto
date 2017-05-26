using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Effect.DataContract
{
    [DataContract]
    public class SimplePhotoEffect
    {
        [DataMember]
        public string ImagesBase64 { get; set; }

        [DataMember]
        public Effects Effect { get; set; }

        [DataMember]
        public string Text { get; set; }


        [DataMember]
        public string Signature { get; set; }

        [DataMember]
        public float? Level { get; set; }


    }
}
