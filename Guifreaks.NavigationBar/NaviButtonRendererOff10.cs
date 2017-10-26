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

using System.Drawing;
using System.Windows.Forms;
using Guifreaks.Common;

namespace Guifreaks.NavigationBar
{
   /// <summary>
   /// This class contains drawing functionality for an button
   /// </summary>
   public class NaviButtonRendererOff10 : NaviButtonRenderer
   {
      #region Fields
      NaviColorTableOff10 colorTable = new NaviColorTableOff10();
      #endregion

      #region Constructor

      /// <summary>
      /// Initializes a new instance of the NaviButtonOfficeRenderer class
      /// </summary>
      public NaviButtonRendererOff10()
      {
         // Use by default the blue colors, override this with the property ColorTable
         colorTable = new NaviColorTableOff10();
      }

      #endregion

      #region Properties

      public NaviColorTableOff10 ColorTable
      {
         get { return colorTable; }
         set { colorTable = value; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Draws the background gradients of an Button
      /// </summary>
      /// <param name="g">The graphics surface to draw on</param>
      /// <param name="bounds">The bounds that the drawing should apply to</param>
      public override void DrawBackground(Graphics g, Rectangle bounds, ControlState state, InputState inputState)
      {
         Color[] endColors = new Color[1];

         if ((state == ControlState.Normal) && (inputState == InputState.Normal))
         {
            endColors = new Color[] { ColorTable.ButtonDark, ColorTable.ButtonDark };
         }
         else if ((state == ControlState.Normal) && (inputState == InputState.Hovered))
         {
            endColors = new Color[] { ColorTable.ButtonHoveredDark, ColorTable.ButtonHoveredLight };
         }
         else if ((state == ControlState.Active) && (inputState == InputState.Normal))
         {
            endColors = new Color[] { ColorTable.ButtonActiveDark, ColorTable.ButtonActiveLight };
         }
         else if ((inputState == InputState.Clicked)
            || ((state == ControlState.Active) && (inputState == InputState.Hovered)))
         {
            endColors = new Color[] { ColorTable.ButtonActiveLight, ColorTable.ButtonActiveDark };
         }

         float[] ColorPositions = { 0.0f, 1.0f };

         ExtDrawing.DrawGradient(g, bounds, endColors, ColorPositions);

         using (Pen p = new Pen(ColorTable.DarkOutlines))
         {
            g.DrawLine(p, bounds.Left, bounds.Top, bounds.Right, bounds.Top);
            p.Color = ColorTable.LightOutlines;
            g.DrawLine(p, bounds.Left, bounds.Top + 1, bounds.Right, bounds.Top + 1);
         }
      }

      /// <summary>
      /// Draws text on a graphics canvas
      /// </summary>
      /// <param name="g">The graphics surface to draw on</param>
      /// <param name="bounds">The bounds of the text</param>
      /// <param name="font">The font of the text</param>
      /// <param name="text">The text to draw</param>
      /// <param name="rightToLeft">Rigth to left or left to right layout</param>
      public override void DrawText(Graphics g, Rectangle bounds, Font font, string text, bool rightToLeft)
      {
         using (Brush brush = new SolidBrush(ColorTable.TextColor))
         {
            if (rightToLeft)
            {
               TextRenderer.DrawText(g, text, font, bounds, ColorTable.TextColor,
                  TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis
                  | TextFormatFlags.Right | TextFormatFlags.RightToLeft);
            }
            else
            {
               TextRenderer.DrawText(g, text, font, bounds, ColorTable.TextColor,
                  TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }
         }
      }

      /// <summary>
      /// Draws an image on the canvas at a given location
      /// </summary>
      /// <param name="g">The graphics canvas to draw on</param>
      /// <param name="location">The location of the image</param>
      /// <param name="image">The image</param>
      public override void DrawImage(Graphics g, Point location, Image image)
      {
         g.DrawImage(image, location);
      }

      #endregion

      #region Overrides

      /// <summary>
      /// Draws the surface of the options button
      /// </summary>
      /// <param name="g">The graphics canvas to draw on</param>
      /// <param name="bounds">The bounds of the text</param>
      public override void DrawOptionsTriangle(Graphics g, Rectangle bounds)
      {
         Point[] points = new Point[] { 
            new Point(bounds.Width /2 +3,bounds.Height /2 -1), 
            new Point(bounds.Width /2, bounds.Height /2 +2), 
            new Point(bounds.Width /2 -2,bounds.Height /2 -1) };

         Point[] pointsRec2 = new Point[] { 
            new Point(bounds.Width /2 +3,bounds.Height /2), 
            new Point(bounds.Width /2, bounds.Height /2 +3), 
            new Point(bounds.Width /2 -2,bounds.Height /2) };

         using (SolidBrush b = new SolidBrush(colorTable.ButtonOptionsInner))
         {
            g.FillPolygon(b, pointsRec2);
            b.Color = colorTable.ButtonOptionsOuter;
            g.FillPolygon(b, points);
         }
      }

      /// <summary>
      /// Draws the surface of the Collapse button
      /// </summary>
      /// <param name="g">The graphics surface to draw on</param>
      /// <param name="bounds">The bounds that the drawing should apply to</param>
      /// <param name="inputState">The input state of the control</param>
      /// <param name="rightToLeft">Right to left or left to right</param>
      /// <param name="collapsed">The bar is collasped or not</param>
      public override void DrawCollapseButton(Graphics g, Rectangle bounds, InputState inputState, bool rightToLeft,
         bool collapsed)
      {
         // TODO
      }

      #endregion

      #region Event Handling
      #endregion
   }
}
