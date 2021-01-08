using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruishen.公共中间量
{
   static class  SoundPlayPointer
    {
        private static int playSound = 0;

        public static int PlaySound
        {
            get { return SoundPlayPointer.playSound; }
            set { SoundPlayPointer.playSound = value; }
        }

       
    }
}
