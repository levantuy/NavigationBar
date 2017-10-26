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
   /// This class contains the drawing functionality for a NavigationBand
   /// </summary>
   public class NaviBandRendererOff7 : NaviBandRenderer
   {
      #region Fields

      NaviColorTableOff7 colorTable = new NaviColorTableOff7();

      #endregion

      #region Constructor

      public NaviBandRendererOff7()
      {
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the colors to draw the control with
      /// </summary>
      public override NaviColorTableOff7 ColorTable
      {
         get { return colorTable; }
         set { colorTable = value; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Draws the background of an Navigation band
      /// </summary>
      /// <param name="g">The graphics surface to draw on</param>
      /// <param name="bounds">The bounds that the drawing should apply to</param>
      /// <param name="state"></param>
      public override void DrawBackground(Graphics g, Rectangle bounds)
      {
         using (Brush b = new SolidBrush(colorTable.Background))
         {
            g.FillRectangle(b, bounds);
         }
      }

      /// <summary>
      /// Draws the background of the collapsed band
      /// </summary>
      /// <param name="g">The canvas to draw on</param>
      /// <param name="bounds">The bounds of the drawing</param>
      /// <param name="text">The text that should appear into the bar</param>
      /// <param name="font">The font to use when drawing the text</param>
      /// <param name="state">The inputstate of the collapsed band</param>
      public override void DrawCollapsedBand(Graphics g, Rectangle bounds, string text, Font font,
         bool rightToLeft, InputState state)
      {
         // TODO Right to left

         using (SolidBrush b = new SolidBrush(colorTable.BandCollapsedBg))
         {
            if (state == InputState.Hovered)
               b.Color = colorTable.BandCollapsedFocused;
            else if (state == InputState.Clicked)
               b.Color = colorTable.BandCollapsedClicked;

            g.FillRectangle(b, bounds);
         }

         // inner border
         using (Pen p = new Pen(colorTable.DarkBorder))
         {
            g.DrawLine(p, new Point(bounds.Left, bounds.Top), new Point(bounds.Right,
               bounds.Top));
            p.Color = colorTable.HeaderBgInnerBorder;
            if (state == InputState.Normal)
            {
               g.DrawLine(p, new Point(bounds.Left, bounds.Top + 1), new Point(bounds.Right,
                  bounds.Top + 1));
               g.DrawLine(p, new Point(bounds.Left, bounds.Top + 1), new Point(bounds.Left,
                  bounds.Bottom));
            }
         }

         using (Brush brush = new SolidBrush(colorTable.Text))
         {
            if (rightToLeft)
            {
               Point ptCenter = new Point(bounds.X + bounds.Width / 2 + 7, bounds.Y +
                  bounds.Height / 2);
               System.Drawing.Drawing2D.Matrix transform = g.Transform;
               transform.RotateAt(90, ptCenter);
               g.Transform = transform;
               using (StringFormat format = new StringFormat())
               {
                  format.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
                  g.DrawString(text, font, brush, ptCenter, format);
               }
            }
            else
            {
               Point ptCenter = new Point(bounds.X + bounds.Width / 2 - 7, bounds.Y +
                  bounds.Height / 2);
               System.Drawing.Drawing2D.Matrix transform = g.Transform;
               transform.RotateAt(270, ptCenter);
               g.Transform = transform;
               g.DrawString(text, font, brush, ptCenter);
            }
         }
      }

      /// <summary>
      /// Draws the background of the popped up band
      /// </summary>
      /// <param name="g">The canvas to draw on</param>
      /// <param name="bounds">The bounds of the drawing</param>
      public override void DrawPopupBand(Graphics g, Rectangle bounds)
      {
         // TODO Right to left
         using (Brush b = new SolidBrush(colorTable.PopupBandBackground))
         {
            g.FillRectangle(b, bounds);
         }
      }

      #endregion
   }
}
