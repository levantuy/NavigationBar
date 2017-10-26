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
   public class NaviColorTableOff3
   {
      // General colors 
      public virtual Color DarkBorder { get { return Color.FromArgb(0, 45, 150); } }
      public virtual Color Text { get { return Color.FromArgb(0, 0, 0); } }
      public virtual Color DarkOutlines { get { return Color.FromArgb(0, 58, 162); } }
      public virtual Color Background { get { return Color.FromArgb(255, 255, 255); } }
      public virtual Color ShapesFront { get { return Color.FromArgb(0, 45, 150); } }

      // NaviButton Normal
      public virtual Color ButtonLight { get { return Color.FromArgb(210, 229, 252); } }
      public virtual Color ButtonDark { get { return Color.FromArgb(139, 176, 228); } }

      // NaviButton hovered
      public virtual Color ButtonHoveredLight { get { return Color.FromArgb(255, 255, 220); } }
      public virtual Color ButtonHoveredDark { get { return Color.FromArgb(255, 215, 103); } }

      // NaviButton active
      public virtual Color ButtonActiveLight { get { return Color.FromArgb(252, 233, 160); } }
      public virtual Color ButtonActiveDark { get { return Color.FromArgb(240, 161, 30); } }

      // Splitter
      public virtual Color SplitterDark { get { return Color.FromArgb(14, 66, 156); } }
      public virtual Color SplitterLight { get { return Color.FromArgb(89, 135, 214); } }
      public virtual Color SplitterHighlights { get { return Color.FromArgb(255, 255, 255); } }

      // Header of band
      public virtual Color HeaderBgDark { get { return Color.FromArgb(7, 59, 150); } }
      public virtual Color HeaderBgLight { get { return Color.FromArgb(89, 135, 214); } }
      public virtual Color HeaderText { get { return Color.FromArgb(255, 255, 255); } }

      // Group
      public virtual Color GroupBgLight { get { return Color.FromArgb(196, 218, 250); } }
      public virtual Color GroupBgDark { get { return Color.FromArgb(160, 191, 245); } }
      public virtual Color GroupBgHoveredLight { get { return Color.FromArgb(196, 218, 250); } }
      public virtual Color GroupBgHoveredDark { get { return Color.FromArgb(160, 191, 245); } }
      public virtual Color GroupBorderLight { get { return Color.FromArgb(158, 190, 245); } }

      // NaviButtonOptions Triangle color options button
      public Color ButtonOptionsOuter { get { return Color.FromArgb(67, 113, 176); } }
      public Color ButtonOptionsInner { get { return Color.FromArgb(255, 248, 203); } }

      // Groupview
      public virtual Color DashedLineColor { get { return Color.FromArgb(194, 194, 194); } }
   }
}
