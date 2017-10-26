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
using System.Windows.Forms;

namespace Guifreaks.NavigationBar
{
   /// <summary>
   /// This class contains the drawing functionality for a NavigationBand
   /// </summary>
   public abstract class NaviBandRenderer
   {
      #region Properties

      /// <summary>
      /// Gets or sets the colors to draw the control with
      /// </summary>
      public abstract NaviColorTableOff7 ColorTable { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Draws the background of an Navigation band
      /// </summary>
      /// <param name="g">The graphics surface to draw on</param>
      /// <param name="bounds">The bounds that the drawing should apply to</param>
      /// <param name="state"></param>
      public abstract void DrawBackground(Graphics g, Rectangle bounds);

      /// <summary>
      /// Draws the background of the collapsed band
      /// </summary>
      /// <param name="g">The canvas to draw on</param>
      /// <param name="bounds">The bounds of the drawing</param>
      /// <param name="text">The text that should appear into the bar</param>
      /// <param name="font">The font to use when drawing the text</param>
      /// <param name="state">The inputstate of the collapsed band</param>
      public abstract void DrawCollapsedBand(Graphics g, Rectangle bounds, string text, Font font,
         bool rightToLeft, InputState state);

      /// <summary>
      /// Draws the background of the popped up band
      /// </summary>
      /// <param name="g">The canvas to draw on</param>
      /// <param name="bounds">The bounds of the drawing</param>
      public abstract void DrawPopupBand(Graphics g, Rectangle bounds);

      #endregion
   }
}
