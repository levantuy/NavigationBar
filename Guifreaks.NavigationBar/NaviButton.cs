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
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Guifreaks.NavigationBar
{
   [
      //Designer(typeof(Guifreaks.NavigationBar.Design.NavigationBarButtonDesigner))
   DefaultEvent("Activated"),
   ]
   public partial class NaviButton : NaviControl
   {
      #region Fields

      EventHandler activated;

      Image largeImage;
      Image smallImage;

      bool small;
      bool collapsed;
      bool active;
      bool showImage;

      protected NaviButtonRenderer renderer;
      protected ControlState state;
      protected InputState inputState;
      protected NaviBand band;

      #endregion

      #region Constructor

      /// <summary>
      /// Initializes a new instance of the NaviButton
      /// </summary>
      public NaviButton()
      {
         InitializeComponent();
         Initialize();
      }

      /// <summary>
      /// Initializes a new instance of the NaviButton
      /// </summary>
      public NaviButton(IContainer container)
         : this()
      {
         container.Add(this);
         InitializeComponent();
      }

      #endregion

      #region Properties

      // Design time 

      /// <summary>
      /// Gets or sets the large image displayed when the button is not in minimized mode
      /// </summary>
      [
      DefaultValue(null),
      Localizable(true),
      Category("Appearance"),
      Description("The image displayed when the button is not displayed as a small button"),
      ]
      public Image LargeImage
      {
         get { return largeImage; }
         set
         {
            largeImage = value;
            Invalidate();
         }
      }

      /// <summary>
      /// Gets or set the image displayed when the button is in minimized mode
      /// </summary>
      [
      DefaultValue(null),
      Localizable(true),
      Category("The image displayed when the button is displayed as a small button"),
      ]
      public Image SmallImage
      {
         get { return smallImage; }
         set
         {
            smallImage = value;
            Invalidate();
         }
      }

      /// <summary>
      /// Gets or sets whether the image is visible or not
      /// </summary>
      [
      DefaultValue(true),
      Category("Indicates if the image is visible or not"),
      ]
      public bool ShowImage
      {
         get { return showImage; }
         set { showImage = value; Invalidate(); }
      }

      /// <summary>
      /// Gets or sets the band that is associated with this button
      /// </summary>
      [
      Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
      ]
      public NaviBand Band
      {
         get { return band; }
         internal set { band = value; }
      }

      // Non design time

      /// <summary>
      /// Gets or sets whether the button is currently the active button
      /// </summary>
      [
      Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      ]
      public bool Active
      {
         get { return active; }
         set
         {
            active = value;
            if (active)
            {
               state = ControlState.Active;
               OnActivated(new EventArgs());
            }
            else
            {
               state = ControlState.Normal;
               inputState = InputState.Normal;
            }
            Invalidate();
         }
      }

      /// <summary>
      /// Gets or sets whether the button should be drawn in the compact mode or the full mode
      /// </summary>
      [
      Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      ]
      public bool Small
      {
         get { return small; }
         set
         {
            small = value;
            Invalidate();
         }
      }

      /// <summary>
      /// Gets or sets whether the buttons should be drawn in minimized mode or not
      /// </summary>
      [
      Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      ]
      public virtual bool Collapsed
      {
         get { return collapsed; }
         set
         {
            collapsed = value;
            Invalidate();
         }
      }

      /// <summary>
      /// Gets or sets the renderer 
      /// </summary>
      [
      Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      ]
      public NaviButtonRenderer Renderer
      {
         get { return renderer; }
         set
         {
            if (value == null)
               throw new ArgumentNullException("Renderer");
            renderer = value;
            Invalidate();
         }
      }

      #endregion

      #region Events

      /// <summary>
      /// Occurs the button is activated
      /// </summary>
      public event EventHandler Activated
      {
         add { lock (threadLock) { activated += value; } }
         remove { lock (threadLock) { activated -= value; } }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Initializes the button for the first time
      /// </summary>
      private void Initialize()
      {
         SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
         SetStyle(ControlStyles.UserPaint, true);
         SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         SetStyle(ControlStyles.ResizeRedraw, true);

         Visible = true;
         small = false;
         collapsed = false;
         showImage = true;
         renderer = new NaviButtonRendererOff7();
      }

      /// <summary>
      /// Raises the Activated event
      /// </summary>
      /// <param name="e">Additional event info</param>
      protected virtual void OnActivated(EventArgs e)
      {
         EventHandler handler = activated;
         if (handler != null)
            handler(this, e);
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
         renderer.DrawBackground(e.Graphics, ClientRectangle, state, inputState);

         if (small)
         {
            if ((smallImage != null) && (showImage))
            {
               Point location = new Point((int)((Width / 2) - (smallImage.Width / 2)),
                  (int)((Height / 2) - (smallImage.Height / 2)));
               renderer.DrawImage(e.Graphics, location, smallImage);
            }
         }
         else
         {
            Rectangle bounds = ClientRectangle;
            if ((largeImage != null) && showImage)
            {
               Point location;

               int margin = 10;
               if (collapsed)
                  margin = 4;

               if (RightToLeft == RightToLeft.Yes)
                  location = new Point(Width - margin - largeImage.Width, (int)((Height / 2) - (largeImage.Height / 2)));
               else
                  location = new Point(margin, (int)((Height / 2) - (largeImage.Height / 2)));

               renderer.DrawImage(e.Graphics, location, largeImage);

               // Calculate bounds for text
               if (RightToLeft == RightToLeft.No)
               {
                  bounds.X += 32;
               }
               bounds.Width -= 32;
            }
            bounds.X += 10;
            bounds.Width -= 10;
            if (!collapsed)
               renderer.DrawText(e.Graphics, bounds, Font, Text, RightToLeft == RightToLeft.Yes);
         }
      }

      /// <summary>
      /// Overloaded. Raises the OnLayoutStyleChanged event
      /// </summary>
      /// <param name="e">Additional event info</param>
      protected override void OnLayoutStyleChanged(EventArgs e)
      {
         base.OnLayoutStyleChanged(e);
         switch (LayoutStyle)
         {
            case NaviLayoutStyle.Office2003Blue:
               renderer = new NaviButtonRendererOff3();
               ((NaviButtonRendererOff3)renderer).ColorTable = new NaviColorTableOff3();
               break;
            case NaviLayoutStyle.Office2003Green:
               renderer = new NaviButtonRendererOff3();
               ((NaviButtonRendererOff3)renderer).ColorTable = new NaviColorTableOff3Green();
               break;
            case NaviLayoutStyle.Office2003Silver:
               renderer = new NaviButtonRendererOff3();
               ((NaviButtonRendererOff3)renderer).ColorTable = new NaviColorTableOff3Silver();
               break;
            case NaviLayoutStyle.Office2007Blue:
               renderer = new NaviButtonRendererOff7();
               ((NaviButtonRendererOff7)renderer).ColorTable = new NaviColorTableOff7();
               break;
            case NaviLayoutStyle.Office2007Black:
               renderer = new NaviButtonRendererOff7();
               ((NaviButtonRendererOff7)renderer).ColorTable = new NaviColorTableOff7Black();
               break;
            case NaviLayoutStyle.Office2007Silver:
               renderer = new NaviButtonRendererOff7();
               ((NaviButtonRendererOff7)renderer).ColorTable = new NaviColorTableOff7Silver();
               break;
            //case NaviLayoutStyle.Office2010:
            //   renderer = new NaviButtonRendererOff10();
            //   break;
         }
         Invalidate();
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
         inputState = InputState.Normal;
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

      /// <summary>
      /// Overriden. Raises the TextChanged event
      /// </summary>
      /// <param name="e">Additional event info</param>
      protected override void OnTextChanged(EventArgs e)
      {
         base.OnTextChanged(e);
         Invalidate();
      }

      #endregion
   }
}
