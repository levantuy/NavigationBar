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
   public class NaviColorTableOff3Silver : NaviColorTableOff3
   {
      // General colors 
      public override Color DarkBorder { get { return Color.FromArgb(124, 124, 148); } }
      public override Color Text { get { return Color.FromArgb(0, 0, 0); } }
      public override Color DarkOutlines { get { return Color.FromArgb(124, 124, 148); } }

      // NaviButton Normal
      public override Color ButtonLight { get { return Color.FromArgb(225, 226, 236); } }
      public override Color ButtonDark { get { return Color.FromArgb(149, 147, 177); } }

      // Splitter
      public override Color SplitterDark { get { return Color.FromArgb(119, 118, 151); } }
      public override Color SplitterLight { get { return Color.FromArgb(168, 167, 191); } }
      public override Color SplitterHighlights { get { return Color.FromArgb(255, 255, 255); } }

      // Header of band
      public override Color HeaderBgDark { get { return Color.FromArgb(114, 113, 147); } }
      public override Color HeaderBgLight { get { return Color.FromArgb(168, 167, 191); } }
      public override Color HeaderText { get { return Color.FromArgb(255, 255, 255); } }

      public override Color GroupBgLight { get { return Color.FromArgb(242, 244, 244); } }
      public override Color GroupBgDark { get { return Color.FromArgb(213, 219, 231); } }
      public override Color GroupBgHoveredLight { get { return Color.FromArgb(242, 244, 244); } }
      public override Color GroupBgHoveredDark { get { return Color.FromArgb(213, 219, 231); } }
      public override Color GroupBorderLight { get { return Color.FromArgb(197, 199, 199); } }

      // NaviButtonOptions Triangle color options button
      //public override  ButtonOptionsOuter { get { return Color.FromArgb(67, 113, 176); } }
      //public override  ButtonOptionsInner { get { return Color.FromArgb(255, 248, 203); } }
   }
}