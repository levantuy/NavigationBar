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
   /// <summary>
   /// Contains the base class for all Bar drawing classes
   /// </summary>
   public abstract class NaviBarRenderer    
   {
      #region Constructor

      public NaviBarRenderer()
      {
      }

      #endregion

      #region Methods

      /// <summary>
      /// Draws the background of the NavigationBar
      /// </summary>
      /// <param name="g">The graphics surface to draw on</param>
      /// <param name="bounds">The bounds of the background</param>
      /// <remarks>Its sufficient to supply the ClientRectangle property of the control</remarks>
      public abstract void DrawBackground(Graphics g, Rectangle bounds);      

      /// <summary>
      /// Draws the background of the rectangle containing the small buttons on the bottom 
      /// of the NavigationBar
      /// </summary>
      /// <param name="g">The graphics surface to draw on</param>
      /// <param name="bounds">The bounds of the small rectangle</param>
      public abstract void DrawSmallButtonRegion(Graphics g, Rectangle bounds);
      
      /// <summary>
      /// Draws the header region on top of the NavigationBar
      /// </summary>
      /// <param name="g">The graphics surface to draw on</param>
      /// <param name="bounds">The bounds of the header</param>
      public abstract void DrawHeader(Graphics g, Rectangle bounds);

      /// <summary>
      /// Draws the text of the header region
      /// </summary>
      /// <param name="g">The canvas to draw on</param>
      /// <param name="bounds">The bounds of the text</param>
      /// <param name="text">The header text to draw</param>
      /// <param name="font">The font to use to draw the text</param>
      /// <param name="rightToLeft">indicates whether it's right to left or left to right layout</param>
      public abstract void DrawHeaderText(Graphics g, Rectangle bounds, string text, Font font, bool rightToLeft);

      #endregion
   }
}
