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
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Guifreaks.NavigationBar
{
   public class NaviSplitterRendererOff3 : NaviSplitterRenderer
   {
      #region Fields

      NaviColorTableOff3 colorTable;

      #endregion

      #region Constructor

      /// <summary>
      /// Initializes a new instance of the GradientSplitterProRenderer class 
      /// </summary>
      public NaviSplitterRendererOff3()
      {
         colorTable = new NaviColorTableOff3();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the colors to draw with
      /// </summary>
      public NaviColorTableOff3 ColorTable
      {
         get { return colorTable; }
         set { colorTable = value; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Draws the background of the gradient splitter class to a graphics surface
      /// </summary>
      /// <param name="g">The graphics surface to draw on</param>
      /// <param name="bounds">The bounds of the drawing relative to the graphics surface</param>
      public override void DrawBackground(Graphics g, Rectangle bounds)
      {
         bool vertical = bounds.Width > bounds.Height;

         // Background
         Color[] EndColors = { colorTable.SplitterLight, colorTable.SplitterDark };
         float[] ColorPositions = { 0.0f, 1.0f };

         ColorBlend blend = new ColorBlend();

         blend.Colors = EndColors;
         blend.Positions = ColorPositions;

         if (bounds.Height == 0)
            bounds.Height = 1;
         if (bounds.Width == 0)
            bounds.Width = 1; // its to prevent an out of memory exception

         Point beginPoint;
         Point endPoint;
         if (vertical)
         {
            beginPoint = new Point(0, bounds.Top);
            endPoint = new Point(0, bounds.Bottom);
         }
         else
         {
            beginPoint = new Point(bounds.Left, 0);
            endPoint = new Point(bounds.Right, 0);
         }

         // Make the linear brush and assign the custom blend to it
         using (LinearGradientBrush brush = new LinearGradientBrush(beginPoint,
                                                           endPoint,
                                                           Color.White,
                                                           Color.Black))
         {
            brush.InterpolationColors = blend;
            g.FillRectangle(brush, bounds);
         }

         int centerX = bounds.Right - (bounds.Width / 2);
         int centerY = bounds.Bottom - (bounds.Height / 2);

         using (SolidBrush b = new SolidBrush(colorTable.DarkBorder))
         {
            if (vertical)
            {
               g.FillRectangle(b, centerX - 8, centerY - 1, 2, 2);
               g.FillRectangle(b, centerX - 4, centerY - 1, 2, 2);
               g.FillRectangle(b, centerX, centerY - 1, 2, 2);
               g.FillRectangle(b, centerX + 4, centerY - 1, 2, 2);
               g.FillRectangle(b, centerX + 8, centerY - 1, 2, 2);

               b.Color = colorTable.SplitterHighlights;

               g.FillRectangle(b, centerX - 7, centerY, 2, 2);
               g.FillRectangle(b, centerX - 3, centerY, 2, 2);
               g.FillRectangle(b, centerX + 1, centerY, 2, 2);
               g.FillRectangle(b, centerX + 5, centerY, 2, 2);
               g.FillRectangle(b, centerX + 9, centerY, 2, 2);
            }
            else
            {
               g.FillRectangle(b, centerX - 1, centerY - 8, 2, 2);
               g.FillRectangle(b, centerX - 1, centerY - 4, 2, 2);
               g.FillRectangle(b, centerX - 1, centerY, 2, 2);
               g.FillRectangle(b, centerX - 1, centerY + 4, 2, 2);
               g.FillRectangle(b, centerX - 1, centerY + 8, 2, 2);

               b.Color = colorTable.SplitterHighlights;

               g.FillRectangle(b, centerX, centerY - 7, 2, 2);
               g.FillRectangle(b, centerX, centerY - 3, 2, 2);
               g.FillRectangle(b, centerX, centerY + 1, 2, 2);
               g.FillRectangle(b, centerX, centerY + 5, 2, 2);
               g.FillRectangle(b, centerX, centerY + 9, 2, 2);
            }
         }
      }

      #endregion
   }
}
