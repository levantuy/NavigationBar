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
   public class NaviColorTableOff7
   {
      // General colors 
      public virtual Color DarkBorder { get { return Color.FromArgb(101, 147, 207); } }
      public virtual Color Text { get { return Color.FromArgb(21, 66, 139); } }
      public virtual Color Background { get { return Color.FromArgb(255, 255, 255); } }
      public virtual Color ShapesFront { get { return Color.FromArgb(86, 125, 177); } }

      // NaviButton Normal
      public virtual Color ButtonLight { get { return Color.FromArgb(192, 219, 255); } }
      public virtual Color ButtonDark { get { return Color.FromArgb(173, 209, 255); } }
      public virtual Color ButtonHighlightDark { get { return Color.FromArgb(196, 221, 255); } }
      public virtual Color ButtonHighlightLight { get { return Color.FromArgb(227, 239, 255); } }

      // NaviButton hovered
      public virtual Color ButtonHoveredLight { get { return Color.FromArgb(255, 230, 159); } }
      public virtual Color ButtonHoveredDark { get { return Color.FromArgb(255, 215, 103); } }
      public virtual Color ButtonHoveredHighlightDark { get { return Color.FromArgb(255, 233, 168); } }
      public virtual Color ButtonHoveredHighlightLight { get { return Color.FromArgb(255, 254, 228); } }

      // NaviButton active
      public virtual Color ButtonActiveLight { get { return Color.FromArgb(254, 225, 122); } }
      public virtual Color ButtonActiveDark { get { return Color.FromArgb(255, 171, 63); } }
      public virtual Color ButtonActiveHighlightDark { get { return Color.FromArgb(255, 188, 111); } }
      public virtual Color ButtonActiveHighlightLight { get { return Color.FromArgb(255, 217, 170); } }

      // NaviButton clicked
      public virtual Color ButtonClickedLight { get { return Color.FromArgb(255, 211, 101); } }
      public virtual Color ButtonClickedDark { get { return Color.FromArgb(251, 140, 60); } }
      public virtual Color ButtonClickedHighlightDark { get { return Color.FromArgb(255, 173, 67); } }
      public virtual Color ButtonClickedHighlightLight { get { return Color.FromArgb(255, 189, 105); } }

      // Popuped band backcolor
      public virtual Color PopupBandBackground { get { return Color.FromArgb(227, 239, 255); } }

      // Splitter
      public virtual Color SplitterDark { get { return Color.FromArgb(182, 214, 255); } }
      public virtual Color SplitterLight { get { return Color.FromArgb(255, 255, 255); } }
      public virtual Color SplitterHighlights { get { return Color.FromArgb(255, 255, 255); } }

      // Options button
      public virtual Color ButtonOptionsOuter { get { return Color.FromArgb(67, 113, 176); } }
      public virtual Color ButtonOptionsInner { get { return Color.FromArgb(255, 248, 203); } }

      // Header of band
      public virtual Color HeaderBgDark { get { return Color.FromArgb(175, 210, 255); } }
      public virtual Color HeaderBgLight { get { return Color.FromArgb(227, 239, 255); } }
      public virtual Color HeaderBgInnerBorder { get { return Color.FromArgb(255, 255, 255); } }

      // Group
      public virtual Color GroupBgLight { get { return Color.FromArgb(226, 238, 255); } }
      public virtual Color GroupBgDark { get { return Color.FromArgb(214, 232, 255); } }
      public virtual Color GroupBgHoveredLight { get { return Color.FromArgb(255, 255, 255); } }
      public virtual Color GroupBgHoveredDark { get { return Color.FromArgb(227, 239, 255); } }
      public virtual Color GroupBorderLight { get { return Color.FromArgb(173, 209, 255); } }
      public virtual Color GroupInnerBorder { get { return Color.FromArgb(255, 255, 255); } }
      
      // Collapse button       
      public virtual Color CollapseButtonHoveredDark { get { return Color.FromArgb(248, 194, 94); } }
      public virtual Color CollapseButtonHoveredLight { get { return Color.FromArgb(255, 255, 220); } }
      public virtual Color CollapseButtonDownDark { get { return Color.FromArgb(232, 127, 8); } }
      public virtual Color CollapseButtonDownLight { get { return Color.FromArgb(247, 217, 121); } }

      // Collapsed band
      public virtual Color BandCollapsedBg { get { return Color.FromArgb(213, 228, 242); } }
      public virtual Color BandCollapsedFocused { get { return Color.FromArgb(255, 231, 162); } }
      public virtual Color BandCollapsedClicked { get { return Color.FromArgb(251, 140, 60); } }

      // Groupview
      public virtual Color DashedLineColor { get { return Color.FromArgb(194, 194, 194); } }
   }
}
