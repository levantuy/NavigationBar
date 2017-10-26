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
using System.Drawing.Drawing2D;

namespace Guifreaks.NavigationBar
{
   /// <summary>
   /// Contains drawing functionality for the splitter
   /// </summary>
   public abstract class NaviSplitterRenderer   
   {
      #region Methods

      /// <summary>
      /// Draws the background of the gradient splitter class to a graphics surface
      /// </summary>
      /// <param name="g">The graphics surface to draw on</param>
      /// <param name="bounds">The bounds of the drawing relative to the graphics surface</param>
      public abstract void DrawBackground(Graphics g, Rectangle bounds);

      #endregion
   }
}
