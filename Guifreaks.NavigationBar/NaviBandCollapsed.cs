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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guifreaks.NavigationBar.Design;

namespace Guifreaks.NavigationBar
{
   /// <summary>
   /// This class represents a Band which is collapsed
   /// </summary>
   /// <remarks>
   /// The navigation pane contains one band which acts for all bands as the collapsed version. 
   /// The navigation pane brings the collapsed band to front when the user turns the navigation pane
   /// to collapsed mode. 
   /// </remarks>
   [
   Designer(typeof(NaviBandDesigner)),
   ToolboxItem(false)
   ]
   public partial class NaviBandCollapsed : NaviControl
   {
      #region Fields

      protected NaviBandRenderer renderer;
      Font headerFont;
      InputState inputState;

      #endregion

      #region Constructor

      /// <summary>
      /// Initializes a new instance of the Navigation band
      /// </summary>
      public NaviBandCollapsed()
      {
         Initialize();
      }

      /// <summary>
      /// Initializes a new instance of the Navigation band
      /// </summary>
      public NaviBandCollapsed(IContainer container)
      {
         container.Add(this);
         Initialize();
      }

      #endregion

      #region Properties
      #endregion

      #region Methods

      /// <summary>
      /// Initializes the control for the first time. 
      /// </summary>
      internal void Initialize()
      {
         SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
         SetStyle(ControlStyles.UserPaint, true);
         SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         SetStyle(ControlStyles.ResizeRedraw, true);

         renderer = new NaviBandRendererOff7();
         headerFont = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
         ResizeRedraw = true;
      }

      #endregion

      #region Overrides

      /// <summary>
      /// Overriden. Raises the Paint event
      /// </summary>
      /// <param name="e">Additional paint info</param>
      protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);
      }

      /// <summary>
      /// Overriden. Raises the Resize event and Invalidates the control
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnResize(EventArgs e)
      {
         base.OnResize(e);
         Invalidate();
      }

      /// <summary>
      /// Overriden. Raises the TetChanged event
      /// </summary>
      /// <param name="e">Additional event info</param>
      protected override void OnTextChanged(EventArgs e)
      {
         base.OnTextChanged(e);
         Invalidate();
      }

      /// <summary>
      /// Overriden. Raises the LayoutStyleChanged event and changes the colorstyle on 
      /// childcontrols
      /// </summary>
      /// <param name="e">Additional event info</param>
      protected override void OnLayoutStyleChanged(EventArgs e)
      {
         base.OnLayoutStyleChanged(e);
         foreach (Control childControl in Controls)
         {
            if (childControl is NaviControl)
            {
               ((NaviControl)childControl).LayoutStyle = LayoutStyle;
            }
         }

         switch (LayoutStyle)
         {
            case NaviLayoutStyle.Office2003Blue:
               // TODO 
               break;
            case NaviLayoutStyle.Office2007Blue:
               renderer = new NaviBandRendererOff7();
               ((NaviBandRenderer)renderer).ColorTable = new NaviColorTableOff7();
               break;
            case NaviLayoutStyle.Office2007Black:
               renderer = new NaviBandRendererOff7();
               ((NaviBandRenderer)renderer).ColorTable = new NaviColorTableOff7Black();
               break;
            case NaviLayoutStyle.Office2007Silver:
               renderer = new NaviBandRendererOff7();
               ((NaviBandRenderer)renderer).ColorTable = new NaviColorTableOff7Silver();
               break;
            //case NaviLayoutStyle.Office2010:
            // TODO renderer = new NaviButtonRendererOff10();
            //   break;
         }
         Invalidate();
      }

      /// <summary>
      /// Overriden. Raises the PaintBackground
      /// </summary>
      /// <param name="pevent">Additional paint info</param>
      protected override void OnPaintBackground(PaintEventArgs e)
      {
         base.OnPaintBackground(e);
         renderer.DrawCollapsedBand(e.Graphics, ClientRectangle, Text, headerFont,
             RightToLeft == RightToLeft.Yes, inputState);
      }

      /// <summary>
      /// Overriden. Raises the MouseEnter event
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnMouseEnter(EventArgs e)
      {
         base.OnMouseEnter(e);
         inputState = InputState.Hovered;
         Invalidate();
      }

      /// <summary>
      /// Overriden. Raises the MouseDown event
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnMouseDown(MouseEventArgs e)
      {
         base.OnMouseDown(e);
         inputState = InputState.Clicked;
         Invalidate();
      }

      /// <summary>
      /// Overriden. Raises the MouseUp event 
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnMouseUp(MouseEventArgs e)
      {
         base.OnMouseUp(e);
         inputState = InputState.Hovered;
         Invalidate();
      }

      /// <summary>
      /// Overriden. Raises the MouseLeave event
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnMouseLeave(EventArgs e)
      {
         base.OnMouseLeave(e);
         inputState = InputState.Normal;
         Invalidate();
      }

      #endregion

      #region Event Handling
      #endregion
   }
}

