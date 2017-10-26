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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Guifreaks.NavigationBar
{
   [ToolboxItem(false)]
   public partial class NaviButtonCollapse : NaviButton
   {
      #region Fields

      bool collapsed;
      
      #endregion

      #region Constructor

      /// <summary>
      /// Initializes a new instance of the NavigationBarButton
      /// </summary>
      public NaviButtonCollapse()
      {
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets whether the buttons should be drawn in minimized mode or not
      /// </summary>
      [
      Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      ]
      public override bool Collapsed
      {
         get { return collapsed; }
         set
         {
            // We need an explicit override with Invalidate otherwise the control is not 
            // invalidated properly. 
            collapsed = value;
            Invalidate();
         }
      }

      #endregion

      #region Overrides

      /// <summary>
      /// Overriden. Raises the Paint event 
      /// </summary>
      /// <param name="e">Additional paint info</param>
      protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);
         renderer.DrawCollapseButton(e.Graphics, ClientRectangle, inputState,
            RightToLeft == RightToLeft.Yes, collapsed);
      }

      #endregion
   }
}