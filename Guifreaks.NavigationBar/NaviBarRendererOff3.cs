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
using System.Windows.Forms;

namespace Guifreaks.NavigationBar
{
   /// <summary>
   /// This class contains drawing functionality for the Navigation pane in the Outlook 2003
   /// style
   /// </summary>
   public class NaviBarRendererOff3 : NaviBarRenderer
   {
      #region Fields

      protected NaviColorTableOff3 colorTable;

      #endregion

      #region Constructor

      public NaviBarRendererOff3()
      {
         colorTable = new NaviColorTableOff3();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the table of colors
      /// </summary>
      public NaviColorTableOff3 ColorTable
      {
         get { return colorTable; }
         set { colorTable = value; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Draws the background of the NavigationBar
      /// </summary>
      /// <param name="g">The graphics surface to draw on</param>
      /// <param name="bounds">The bounds of the background</param>
      /// <remarks>Its sufficient to supply the ClientRectangle property of the control</remarks>
      public override void DrawBackground(Graphics g, Rectangle bounds)
      {
         bounds.Width -= 1;
         bounds.Height -= 1;

         using (Brush b = new SolidBrush(Color.White))
         using (Pen p = new Pen(colorTable.DarkBorder))
         {
            g.FillRectangle(b, bounds);
            g.DrawRectangle(p, bounds);
         }
      }

      /// <summary>
      /// Draws the background of the rectangle containing the small buttons on the bottom 
      /// of the NavigationBar
      /// </summary>
      /// <param name="g">The graphics surface to draw on</param>
      /// <param name="bounds">The bounds of the small rectangle</param>
      public override void DrawSmallButtonRegion(Graphics g, Rectangle bounds)
      {
         // Background
         Color[] EndColors = { ColorTable.ButtonDark, ColorTable.ButtonLight };
         float[] ColorPositions = { 0.0f, 1.0f };

         ColorBlend blend = new ColorBlend();

         blend.Colors = EndColors;
         blend.Positions = ColorPositions;

         if (bounds.Height == 0)
            bounds.Height = 1; // its to prevent an out of memory exception
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

         using (Pen p = new Pen(colorTable.DarkBorder))
         {
            g.DrawLine(p, bounds.Left, bounds.Top, bounds.Right, bounds.Top);
         }
      }

      /// <summary>
      /// Draws the header region on top of the NavigationBar
      /// </summary>
      /// <param name="g">The graphics surface to draw on</param>
      /// <param name="bounds">The bounds of the header</param>
      public override void DrawHeader(Graphics g, Rectangle bounds)
      {
         Color[] endColors = new Color[] { colorTable.HeaderBgDark, colorTable.HeaderBgLight };
         float[] ColorPositions = { 0.0f, 1.0f };

         ColorBlend blend = new ColorBlend();

         blend.Colors = endColors;
         blend.Positions = ColorPositions;

         if (bounds.Height == 0)
            bounds.Height = 1; // its to prevent an out of memory exception
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

      /// <summary>
      /// Draws the text of the header region
      /// </summary>
      /// <param name="g">The canvas to draw on</param>
      /// <param name="bounds">The bounds of the text</param>
      /// <param name="text">The header text to draw</param>
      /// <param name="font">The font to use to draw the text</param>
      /// <param name="rightToLeft">indicates whether it's right to left or left to right layout</param>
      public override void DrawHeaderText(Graphics g, Rectangle bounds, string text, Font font, bool rightToLeft)
      {
         using (Brush brush = new SolidBrush(colorTable.Text))
         {
            if (rightToLeft)
            {
               TextRenderer.DrawText(g, text, font, bounds, colorTable.HeaderText,
                  TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis
                  | TextFormatFlags.Right | TextFormatFlags.RightToLeft);
            }
            else
            {
               TextRenderer.DrawText(g, text, font, bounds, colorTable.HeaderText,
                  TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }
         }
      }

      #endregion
   }
}
