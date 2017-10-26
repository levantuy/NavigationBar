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
using System.Drawing;
using System.Windows.Forms;

namespace Guifreaks.NavigationBar
{
   public partial class NaviBandPopup : NaviForm
   {
      NaviBandRenderer renderer = new NaviBandRendererOff7();

      bool resizable;
      Point startDrag;
      bool dragging;
      Control content;
      Rectangle resizeBounds;

      public Control Content
      {
         get { return content; }
         set
         {
            content = value;
            if (content != null)
            {
               Controls.Clear();
               content.Dock = DockStyle.Fill;
               Controls.Add(content);
            }
         }
      }

      public bool Resizable
      {
         get { return resizable; }
         set { resizable = value; }
      }

      public NaviBandRenderer Renderer
      {
         get { return renderer; }
         set { renderer = value; }
      }

      protected override CreateParams CreateParams
      {
         get
         {
            CreateParams param = base.CreateParams;
            //param.ClassStyle += NativeMethods.CS_DROPSHADOW;
            return param;
         }
      }

      public NaviBandPopup()
      {
         InitializeComponent();
         ResizeRedraw = true;

         SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
         SetStyle(ControlStyles.UserPaint, true);
         SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         SetStyle(ControlStyles.ResizeRedraw, true);

         Padding = new Padding(3);
      }

      #region Overrides

      /// <summary>
      /// Overriden. Raises the Paint event
      /// </summary>
      /// <param name="e">Additional paint info</param>
      protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);
      }

      protected override bool ShowWithoutActivation
      {
         get { return true; }
      }

      /// <summary>
      /// Overriden. Raises the PaintBackground and draws the background of the Navigation band
      /// </summary>
      /// <param name="pevent">Additional paint info</param>
      protected override void OnPaintBackground(PaintEventArgs e)
      {
         base.OnPaintBackground(e);
         renderer.DrawPopupBand(e.Graphics, ClientRectangle);
      }

      /// <summary>
      /// Overriden. Raises the MouseDown event
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnMouseDown(MouseEventArgs e)
      {
         base.OnMouseDown(e);
         if ((e.Button == MouseButtons.Left)
         && (e.Clicks == 1))
         {
            if (resizeBounds.Contains(e.Location))
            {
               startDrag = e.Location;
               dragging = true;
            }
         }
         else
            dragging = false;
      }

      /// <summary>
      /// Overriden. Raises the MouseDown event.
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnMouseMove(MouseEventArgs e)
      {
         base.OnMouseMove(e);
         if (dragging)
         {
            Size = new Size(e.Location.X + 3, Size.Height);
            Cursor = Cursors.SizeWE;
         }
         else if (resizeBounds.Contains(e.Location))
         {
            Cursor = Cursors.SizeWE;
         }
         else
         {
            Cursor = Cursors.Default;
         }
      }

      /// <summary>
      /// Overriden. Raises the MouseLeave event and changes the cursor back to default
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnMouseLeave(EventArgs e)
      {
         base.OnMouseLeave(e);
         dragging = false;
      }

      protected override void OnResize(EventArgs e)
      {
         base.OnResize(e);
         resizeBounds = new Rectangle(Width - 3, 0, 3, Height);
      }

      /// <summary>
      /// Overriden. Raises the MouseUp event
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnMouseUp(MouseEventArgs e)
      {
         base.OnMouseUp(e);
         dragging = false;
      }

      /// <summary>
      /// Overloaded. Raises the LayoutStyleChanged event
      /// </summary>
      /// <param name="e"></param>
      protected override void OnLayoutStyleChanged(EventArgs e)
      {
         base.OnLayoutStyleChanged(e);
         
         switch (LayoutStyle)
         {
            case NaviLayoutStyle.Office2003Blue:
               // TODO 
               break;
            case NaviLayoutStyle.Office2007Blue:
               renderer = new NaviBandRendererOff7();
               renderer.ColorTable = new NaviColorTableOff7();
               break;
            case NaviLayoutStyle.Office2007Black:
               renderer = new NaviBandRendererOff7();
               renderer.ColorTable = new NaviColorTableOff7Black();
               break;
            case NaviLayoutStyle.Office2007Silver:
               renderer = new NaviBandRendererOff7();
               renderer.ColorTable = new NaviColorTableOff7Silver();
               break;
            //case NaviLayoutStyle.Office2010:
            //   // TODO renderer = new NaviButtonRendererOff10();
            //   break;
         }
         Invalidate();
      }

      #endregion
   }
}
