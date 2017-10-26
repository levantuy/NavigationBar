#region License and Copyright

/*
 
Author:  Jacob Mesu
 
Attribution-Noncommercial-Share Alike 3.0 Unported
You are free:

    * to Share — to copy, distribute and transmit the work
    * to Remix — to adapt the work

Under the following conditions:

    * Attribution — You must attribute the work and give credits to the author or guifreaks.net
    * Noncommercial — You may not use this work for commercial purposes. If you want to adapt
      this work for a commercial purpose, visit guifreaks.net and request the Attribution-Share 
      Alike 3.0 Unported license for free. 

http://creativecommons.org/licenses/by-nc-sa/3.0/

*/
#endregion

using System.Drawing;

namespace Guifreaks.NavigationBar
{
   public class NaviColorTableOff10 : NaviColorTableOff7
   {
      // General colors 
      public virtual Color DarkOutlines { get { return Color.FromArgb(187, 195, 205); } }
      public virtual Color LightOutlines { get { return Color.FromArgb(239, 244, 250); } }
      public virtual Color TextColor { get { return Color.FromArgb(39, 52, 67); } }

      // NaviButton Normal
      public override Color ButtonLight { get { return Color.FromArgb(219, 225, 231); } }
      public override Color ButtonDark { get { return Color.FromArgb(219, 225, 231); } }
   }
}
