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
   public class NaviColorTableOff3Green : NaviColorTableOff3
   {
      // General colors 
      public override Color DarkBorder { get { return Color.FromArgb(96, 128, 88); } }
      public override Color Text { get { return Color.FromArgb(0, 0, 0); } }
      public override Color DarkOutlines { get { return Color.FromArgb(96, 128, 88); } }

      // NaviButton Normal
      public override Color ButtonLight { get { return Color.FromArgb(234, 240, 207); } }
      public override Color ButtonDark { get { return Color.FromArgb(177, 192, 140); } }

      // Splitter
      public override Color SplitterDark { get { return Color.FromArgb(73, 91, 67); } }
      public override Color SplitterLight { get { return Color.FromArgb(120, 142, 111); } }
      public override Color SplitterHighlights { get { return Color.FromArgb(255, 255, 255); } }

      // Header of band
      public override Color HeaderBgDark { get { return Color.FromArgb(102, 125, 71); } }
      public override Color HeaderBgLight { get { return Color.FromArgb(175, 192, 130); } }
      public override Color HeaderText { get { return Color.FromArgb(255, 255, 255); } }

      // Group
      public override Color GroupBgLight { get { return Color.FromArgb(242, 241, 228); } }
      public override Color GroupBgDark { get { return Color.FromArgb(218, 218, 170); } }
      public override Color GroupBgHoveredLight { get { return Color.FromArgb(242, 241, 228); } }
      public override Color GroupBgHoveredDark { get { return Color.FromArgb(218, 218, 170); } }
      public override Color GroupBorderLight { get { return Color.FromArgb(217, 217, 167); } }

      // NaviButtonOptions Triangle color options button
      //public override  ButtonOptionsOuter { get { return Color.FromArgb(67, 113, 176); } }
      //public override  ButtonOptionsInner { get { return Color.FromArgb(255, 248, 203); } }
   }
}