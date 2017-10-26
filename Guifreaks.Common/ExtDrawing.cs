﻿#region License and Copyright

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

namespace Guifreaks.Common
{
   public class ExtDrawing
   {
      /// <summary>
      /// Draws a gradient on a Graphics canvas
      /// </summary>
      /// <param name="g">The graphics canvas</param>
      /// <param name="bounds">The bounds of the gradient</param>
      /// <param name="colors">The colors of the gradient</param>
      /// <param name="positions">The position of the colors inside the gradient</param>
      public static void DrawGradient(Graphics g, Rectangle bounds, Color[] colors,
         float[] positions)
      {
         ColorBlend blend = new ColorBlend();

         blend.Colors = colors;
         blend.Positions = positions;

         // To prevent out of memory exceptions when the width or height is 0
         if (bounds.Height == 0)
            bounds.Height = 1; 
         if (bounds.Width == 0)
            bounds.Width = 1;

         // Make the linear brush and assign the custom blend to it
         using (LinearGradientBrush brush = new LinearGradientBrush(new Point(bounds.Left, bounds.Bottom),
                                                           new Point(bounds.Left, bounds.Top),
                                                           Color.White,
                                                           Color.Black))
         {
            brush.InterpolationColors = blend;
            g.FillRectangle(brush, bounds);
         }
      }
   }
}
