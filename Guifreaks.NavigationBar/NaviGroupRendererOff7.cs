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
   public class NaviGroupRendererOff7 : NaviGroupRenderer   
   {
      #region Fields

      NaviColorTableOff7 colorTable;

      #endregion

      #region Constructor

      public NaviGroupRendererOff7()
      {
         colorTable = new NaviColorTableOff7();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the colors to draw the control with
      /// </summary>
      public NaviColorTableOff7 ColorTable
      {
         get { return colorTable; }
         set { colorTable = value; }
      }

      #endregion

      #region Methods

      public override void DrawBackground(Graphics g, Rectangle bounds)
      {
         using (Brush b = new SolidBrush(colorTable.Background))
         {
            g.FillRectangle(b, bounds);
         }
      }

      public override void DrawText(Graphics g, Rectangle bounds, Font font, string headerText, bool rightToLeft)
      {
         using (Brush brush = new SolidBrush(colorTable.Text))
         {
            if (rightToLeft)
            {
               TextRenderer.DrawText(g, headerText, font, bounds, colorTable.Text,
                  TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis |
                  TextFormatFlags.Right | TextFormatFlags.RightToLeft);
            }
            else
            {
               TextRenderer.DrawText(g, headerText, font, bounds, colorTable.Text,
                  TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }
         }
      }

      public override void DrawHeader(Graphics g, Rectangle bounds, InputState state, bool expanded, bool rightToLeft)
      {
         Color dark, light;
         bounds.Height--;

         if (state == InputState.Hovered)
         {
            dark = colorTable.GroupBgHoveredDark;
            light = colorTable.GroupBgHoveredLight;
         }
         else
         {
            dark = colorTable.GroupBgDark;
            light = colorTable.GroupBgLight;
         }

         // Background
         Color[] EndColors = { dark, light, dark };
         float[] ColorPositions = { 0.0f, .50f, 1.0f };

         ColorBlend blend = new ColorBlend();

         blend.Colors = EndColors;
         blend.Positions = ColorPositions;

         if (bounds.Width == 0)
            bounds.Width = 1; // its to prevent an out of memory exception

         //Make the linear brush and assign the custom blend to it
         using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0),
                                                           new Point(bounds.Width, 0),
                                                           Color.White,
                                                           Color.Black))
         {
            brush.InterpolationColors = blend;
            g.FillRectangle(brush, bounds);
         }

         using (Pen pen = new Pen(colorTable.DarkBorder))
         {
            // Dark border
            //g.DrawRectangle(pen, bounds);
            g.DrawLine(pen, new Point(0, 0), new Point(bounds.Width, 0));

            // Light line bottom
            pen.Color = colorTable.GroupBorderLight;
            g.DrawLine(pen, new Point(0, bounds.Height),
               new Point(bounds.Width, bounds.Height));

            // Light inner border
            pen.Color = colorTable.GroupInnerBorder;
            g.DrawLine(pen, new Point(0, 1), new Point(bounds.Width, 1));
            g.DrawLine(pen, new Point(0, 1), new Point(0, bounds.Height - 1));

            // Arrows
            pen.Color = colorTable.ShapesFront;

            //width-7
            //(height/2)+1
            // w=7 h=4
            pen.Width = 1.5f;
            float x = 0;
            float y = 0;

            if (bounds.Height != 0)
               y = (bounds.Height / 2) - 3; // + 1px border and - 4 size

            if (rightToLeft)
               x = 7;
            else
               x = bounds.Width - 7 - 7; // 7 px spacing and - 7 width            

            if (expanded)
            {
               PointF[] points = { new PointF(x, y + 3 + 4), 
                               new PointF(x + 3,y + 4), 
                               new PointF(x + 3 + 3, y + 3 + 4) };
               g.DrawLines(pen, points);

               PointF[] points2 = { new PointF(x, y + 3), 
                               new PointF(x + 3,y ), 
                               new PointF(x + 3 + 3, y + 3) };
               g.DrawLines(pen, points2);
            }
            else
            {
               PointF[] points = { new PointF(x, y + 4), 
                               new PointF(x + 3,y + 3 + 4), 
                               new PointF(x + 3 + 3, y + 4) };
               g.DrawLines(pen, points);

               PointF[] points2 = { new PointF(x, y ), 
                               new PointF(x + 3,y + 3 ), 
                               new PointF(x + 3 + 3, y) };
               g.DrawLines(pen, points2);
            }
         }

      }

      public override void DrawHatchedPanel(Graphics g, Rectangle bounds)
      {
         using (Pen pen = new Pen(colorTable.DashedLineColor))
         {
            pen.DashStyle = DashStyle.Dash;
            g.DrawRectangle(pen, bounds);
         }
      }
      #endregion

      #region Event Handling
      #endregion
   }
}
