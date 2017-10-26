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
   public class NaviColorTableOff7Black : NaviColorTableOff7
   {
      // General colors 
      public override Color DarkBorder { get { return Color.FromArgb(167, 173, 182); } }
      public override Color Text { get { return Color.FromArgb(0, 0, 0); } }
      public override Color ShapesFront { get { return Color.FromArgb(49, 52, 49); } }

      // NaviButton Normal
      public override Color ButtonLight { get { return Color.FromArgb(219, 222, 226); } }
      public override Color ButtonDark { get { return Color.FromArgb(199, 203, 209); } }
      public override Color ButtonHighlightDark { get { return Color.FromArgb(223, 226, 228); } }
      public override Color ButtonHighlightLight { get { return Color.FromArgb(248, 248, 249); } }

      // Header of band
      public override Color HeaderBgDark { get { return Color.FromArgb(189, 193, 200); } }
      public override Color HeaderBgLight { get { return Color.FromArgb(240, 241, 242); } }

      // Splitter
      public override Color SplitterDark { get { return Color.FromArgb(195, 200, 206); } }
      public override Color SplitterLight { get { return Color.FromArgb(255, 255, 255); } }
      public override Color SplitterHighlights { get { return Color.FromArgb(255, 255, 255); } }

      // Group
      public override Color GroupBgLight { get { return Color.FromArgb(239, 240, 241); } }
      public override Color GroupBgDark { get { return Color.FromArgb(221, 224, 227); } }
      public override Color GroupBgHoveredLight { get { return Color.FromArgb(255, 255, 255); } }
      public override Color GroupBgHoveredDark { get { return Color.FromArgb(232, 234, 236); } }
      public override Color GroupBorderLight { get { return Color.FromArgb(199, 203, 209); } }
      public override Color GroupInnerBorder { get { return Color.FromArgb(255, 255, 255); } }

      // Collapsed band
      public override Color BandCollapsedBg { get { return Color.FromArgb(235, 235, 235); } }

      public override Color PopupBandBackground { get { return Color.FromArgb(240, 241, 242); } }
   }
}