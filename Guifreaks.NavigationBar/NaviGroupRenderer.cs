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

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Guifreaks.NavigationBar
{
   public abstract class NaviGroupRenderer
   {
      #region Methods

      public abstract void DrawBackground(Graphics g, Rectangle bounds);

      public abstract void DrawText(Graphics g, Rectangle bounds, Font font, string headerText, bool rightToLeft);

      public abstract void DrawHeader(Graphics g, Rectangle bounds, InputState state, bool expanded, bool rightToLeft);

      public abstract void DrawHatchedPanel(Graphics g, Rectangle bounds);
      
      #endregion
   }
}
