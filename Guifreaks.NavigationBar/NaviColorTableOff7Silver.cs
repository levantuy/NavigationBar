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
   public class NaviColorTableOff7Silver : NaviColorTableOff7
   {
      // General colors 
      public override Color DarkBorder { get { return Color.FromArgb(111, 112, 116); } }
      public override Color Text { get { return Color.FromArgb(21, 66, 139); } }
      public override Color ShapesFront { get { return Color.FromArgb(101, 104, 112); } }

      // NaviButton Normal
      public override Color ButtonLight { get { return Color.FromArgb(219, 222, 226); } }
      public override Color ButtonDark { get { return Color.FromArgb(197, 199, 209); } }
      public override Color ButtonHighlightDark { get { return Color.FromArgb(214, 218, 228); } }
      public override Color ButtonHighlightLight { get { return Color.FromArgb(235, 238, 250); } }

      // Header of band
      public override Color HeaderBgDark { get { return Color.FromArgb(218, 223, 230); } }
      public override Color HeaderBgLight { get { return Color.FromArgb(255, 255, 255); } }

      // Splitter
      public override Color SplitterDark { get { return Color.FromArgb(119, 118, 151); } }
      public override Color SplitterLight { get { return Color.FromArgb(168, 167, 191); } }
      public override Color SplitterHighlights { get { return Color.FromArgb(255, 255, 255); } }

      // Group
      public override Color GroupBgLight { get { return Color.FromArgb(215, 215, 229); } }
      public override Color GroupBgDark { get { return Color.FromArgb(216, 216, 230); } }
      public override Color GroupBgHoveredLight { get { return Color.FromArgb(215, 215, 229); } }
      public override Color GroupBgHoveredDark { get { return Color.FromArgb(216, 216, 230); } }
      public override Color GroupBorderLight { get { return Color.FromArgb(197, 199, 199); } }

      // Collapsed band
      public override Color BandCollapsedBg { get { return Color.FromArgb(238, 238, 244); } }

      public override Color PopupBandBackground { get { return Color.FromArgb(240, 241, 242); } }
   }
}