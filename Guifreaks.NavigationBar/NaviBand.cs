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
   /// This class represents a Band which is a part of the Navigation bar
   /// </summary>
   /// <remarks>
   /// The band is the actual control container which will be displayed when the user clicks
   /// on the button which has been assigned to this band. 
   /// The size of this control is controlled by the layout engine. 
   /// </remarks>
   [
   Designer(typeof(NaviBandDesigner)),
   ToolboxItem(false)
   ]
   public partial class NaviBand : NaviControl
   {
      #region Fields

      NaviBandRenderer renderer;
      NaviButton button;
      Image largeImage;
      Image smallImage;
      NaviBandClientArea clientArea;
      int order;
      int originalOrder;

      #endregion

      #region Constructor

      /// <summary>
      /// Initializes a new instance of the Navigation band
      /// </summary>
      public NaviBand()
      {
         InitializeComponent();
         Initialize();
      }

      /// <summary>
      /// Initializes a new instance of the Navigation band
      /// </summary>
      public NaviBand(IContainer container)
      {
         container.Add(this);
         InitializeComponent();
         Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the position in a list of this band
      /// </summary>
      internal int Order
      {
         get { return order; }
         set { order = value; }
      }

      /// <summary>
      /// Gets or sets the original position in a list of this band
      /// </summary>
      internal int OriginalOrder
      {
         get { return originalOrder; }
         set { originalOrder = value; }
      }

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
            if (button != null)
               button.LargeImage = value;
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
            if (button != null)
               button.SmallImage = value;
            Invalidate();
         }
      }

      /// <summary>
      /// Gets the button which is associated with this band
      /// </summary>
      [
      Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
      ]
      public NaviButton Button
      {
         get { return button; }
         internal set { button = value; }
      }
      
      [
      Browsable(false), 
      DesignerSerializationVisibility(DesignerSerializationVisibility.Content)
      ]
      public NaviBandClientArea ClientArea
      {
         get { return clientArea; }
         set { clientArea = value; }
      }

      /// <summary>
      /// Gets or sets the renderer for this control
      /// </summary>
      [
      Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
      ]
      public NaviBandRenderer Renderer
      {
         get { return renderer; }
         set { renderer = value; }
      }

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

         clientArea = new NaviBandClientArea();
         clientArea.Name = "ClientArea";
         clientArea.Location = new Point(0, 0);
         clientArea.Size = Size;
         Controls.Add(clientArea);

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
         renderer.DrawBackground(e.Graphics, ClientRectangle);
      }

      /// <summary>
      /// Overriden. Raises the PaintBackground and draws the background of the Navigation band
      /// </summary>
      /// <param name="pevent">Additional paint info</param>
      protected override void OnPaintBackground(PaintEventArgs e)
      {
         base.OnPaintBackground(e);         
      }

      /// <summary>
      /// Overriden. Raises the Resize event and Invalidates the control
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnResize(EventArgs e)
      {
         base.OnResize(e);
         clientArea.Size = Size;
         Invalidate();
      }

      /// <summary>
      /// Overriden. Raises the TetChanged event
      /// </summary>
      /// <param name="e">Additional event info</param>
      protected override void OnTextChanged(EventArgs e)
      {
         base.OnTextChanged(e);
         if (button != null)
            button.Text = Text;
      }

      /// <summary>
      /// Overriden. Raises the LayoutStyleChanged event and changes the colorstyle on 
      /// childcontrols
      /// </summary>
      /// <param name="e">Additional event info</param>
      protected override void OnLayoutStyleChanged(EventArgs e)
      {
         base.OnLayoutStyleChanged(e);
         foreach (Control childControl in clientArea.Controls)
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

      #region Event Handling
      #endregion
   }
}
