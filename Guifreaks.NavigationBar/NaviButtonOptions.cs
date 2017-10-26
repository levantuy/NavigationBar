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
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Guifreaks.NavigationBar
{
   [ToolboxItem(false)]
   public partial class NaviButtonOptions : NaviButton
   {
      #region Overrides

      protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
      {
         base.OnPaint(e);
         base.Renderer.DrawOptionsTriangle(e.Graphics, ClientRectangle);
      }

      #endregion

      #region Event Handling
      #endregion
   }
}
