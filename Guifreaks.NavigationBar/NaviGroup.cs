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
   /// Represents a container control which can be expanded or collapsed to a header bar only. 
   /// </summary>
   [
   Designer(typeof(NaviGroupDesigner)),
   ToolboxItem(true),
   ToolboxBitmap(typeof(NaviGroup))
   ]
   public partial class NaviGroup : NaviControl, ISupportInitialize
   {
      #region Fields

      Region m_headerRegion;
      Rectangle m_headerRectangle;
      Rectangle m_headerTextBounds;
      MouseEventHandler m_headerMouseClick;
      NaviGroupRenderer renderer;
      InputState viewState;
      ContextMenuStrip m_contextMenuStrip;
      ContextMenuStrip m_headerContextMenuStrip;

      string m_caption;
      bool m_expanded;
      int m_headerHeight;
      int m_expandedHeight;

      #endregion

      #region Constructor

      /// <summary>
      /// Initializes a new instance of the GroupView class
      /// </summary>
      public NaviGroup()
      {
         InitializeComponent();
         Initialize();
      }

      /// <summary>
      /// Initializes a new instance of the GroupView class
      /// </summary>
      /// <param name="container">The container to which this control belongs</param>
      public NaviGroup(IContainer container)
         : this()
      {
         container.Add(this);
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the text displayed in the header region
      /// </summary>
      public string Caption
      {
         get { return m_caption; }
         set { m_caption = value; }
      }

      /// <summary>
      /// Gets or sets the height of the header
      /// </summary>
      [
      DefaultValue(20)
      ]
      public int HeaderHeight
      {
         get { return m_headerHeight; }
         set
         {
            if (m_headerHeight != value)
            {
               CreateBounds(value);
            }
            m_headerHeight = value;
         }
      }

      /// <summary>
      /// Gets or sets whether the control is expanded or collapsed to the header only
      /// </summary>
      [
      DefaultValue(true)
      ]
      public bool Expanded
      {
         get { return m_expanded; }
         set
         {
            if (m_expanded != value)
            {
               if (value)
               {
                  Expand();
               }
               else
               {
                  Collapse();
               }
            }
            m_expanded = value;
         }
      }

      /// <summary>
      /// Gets or sets the height of the GroupView when it's expanded
      /// </summary>
      [
      DefaultValue(150),
      ]
      public int ExpandedHeight
      {
         get { return m_expandedHeight; }
         set { m_expandedHeight = value; }
      }

      /// <summary>
      /// Overriden. Gets or sets the current height of the GroupView
      /// </summary>
      public new int Height
      {
         get { return base.Height; }
         set
         {
            base.Height = value;
            // Make sure expanded hight is always as much as the height when a control 
            // is expanded. 
            if (m_expanded)
               m_expandedHeight = value;
         }
      }

      /// <summary>
      /// Overriden. Gets or sets the ContextMenuStrip associated with this control
      /// </summary>
      public new ContextMenuStrip ContextMenuStrip
      {
         get { return m_contextMenuStrip; }
         set { m_contextMenuStrip = value; }
      }

      /// <summary>
      /// Gets or sets the shortcut menu to display when the user right-clicks the header. 
      /// </summary>
      public ContextMenuStrip HeaderContextMenuStrip
      {
         get { return m_headerContextMenuStrip; }
         set { m_headerContextMenuStrip = value; }
      }

      /// <summary>
      /// Gets the region used for the header
      /// </summary>
      [Browsable(false)]
      public Region HeaderRegion
      {
         get { return m_headerRegion; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Initializes the control for the first time
      /// </summary>
      private void Initialize()
      {
         SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
         SetStyle(ControlStyles.UserPaint, true);
         SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         SetStyle(ControlStyles.ResizeRedraw, true);

         m_expanded = true;
         m_headerHeight = 20;
         m_expandedHeight = 150;
         renderer = new NaviGroupRendererOff7();
         viewState = InputState.Normal;
         Padding = new Padding(1, 1, 1, 1);
      }

      /// <summary>
      /// Creates a new Region for the header using a specified Height. 
      /// </summary>
      /// <param name="height">The height of the header</param>
      private void CreateBounds(int height)
      {
         m_headerRectangle = new Rectangle(0, 0, Width, height);
         m_headerRegion = new Region(m_headerRectangle);
         m_headerTextBounds = m_headerRectangle;
         if (RightToLeft == RightToLeft.Yes)
         {
            m_headerTextBounds.Width -= 19;
            m_headerTextBounds.X += 16;
         }
         else
         {
            m_headerTextBounds.Width -= 16;
            m_headerTextBounds.X += 3;
         }
         Padding = new Padding(Padding.Left, m_headerHeight + 2, Padding.Right, Padding.Bottom);
      }

      /// <summary>
      /// Expands the view to full height
      /// </summary>
      public void Expand()
      {
         m_expanded = true;
         Height = m_expandedHeight;
      }

      /// <summary>
      /// Collapses the view to the header only
      /// </summary>
      public void Collapse()
      {
         m_expanded = false;
         Height = m_headerHeight;
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
         renderer.DrawHeader(e.Graphics, m_headerRectangle, viewState, m_expanded,
            RightToLeft == RightToLeft.Yes);
         renderer.DrawText(e.Graphics, m_headerTextBounds, this.Font, m_caption,
            RightToLeft == RightToLeft.Yes);

         if (DesignMode)
         {
            Rectangle containerRect = ClientRectangle;
            containerRect.X++;
            containerRect.Y += m_headerHeight + 1;
            containerRect.Width -= 3;
            containerRect.Height -= (m_headerHeight + 3);

            renderer.DrawHatchedPanel(e.Graphics, containerRect);
         }
      }

      /// <summary>
      /// Overriden. Raises the PaintBackground event 
      /// </summary>
      /// <param name="e">Additional paint info</param>
      protected override void OnPaintBackground(PaintEventArgs e)
      {
         base.OnPaintBackground(e);
         renderer.DrawBackground(e.Graphics, ClientRectangle);
      }

      /// <summary>
      /// Overriden. Raises the MouseClick event
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnMouseClick(MouseEventArgs e)
      {
         bool headerClicked = m_headerRegion.IsVisible(new Point(e.X, e.Y));
         if (headerClicked)
         {
            base.OnMouseClick(e);
            OnHeaderMouseClick(e);
         }
         else
         {
            base.OnMouseClick(e);
            if ((m_contextMenuStrip != null) && (e.Button == MouseButtons.Right))
            {
               m_contextMenuStrip.Show(this, e.Location);
            }
         }
      }

      /// <summary>
      /// Overriden. Raises the MouseMove event and shows a hand when the mouse is moved over the header
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnMouseMove(MouseEventArgs e)
      {
         base.OnMouseMove(e);
         if (m_headerRegion.IsVisible(new Point(e.X, e.Y)))
         {
            Cursor = Cursors.Hand;
            viewState = InputState.Hovered;
            Invalidate();
         }
         else
         {
            Cursor = Cursors.Default;
            viewState = InputState.Normal;
            Invalidate();
         }
      }

      /// <summary>
      /// Overriden. Raises the MouseLeave event and changes the current cursor to the default. 
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnMouseLeave(EventArgs e)
      {
         base.OnMouseLeave(e);
         Cursor = Cursors.Default;
         viewState = InputState.Normal;
         Invalidate();
      }

      /// <summary>
      /// Overriden. Raises the Resize event and reinitializes the bounds of the header
      /// </summary>
      /// <param name="e"></param>
      protected override void OnResize(EventArgs e)
      {
         base.OnResize(e);
         CreateBounds(m_headerHeight);
         Invalidate();
      }

      protected override void OnLayoutStyleChanged(EventArgs e)
      {
         base.OnLayoutStyleChanged(e);
         switch (LayoutStyle)
         {
            case NaviLayoutStyle.Office2003Blue:
               renderer = new NaviGroupRendererOff3();
               ((NaviGroupRendererOff3)renderer).ColorTable = new NaviColorTableOff3();
               break;
            case NaviLayoutStyle.Office2003Green:
               renderer = new NaviGroupRendererOff3();
               ((NaviGroupRendererOff3)renderer).ColorTable = new NaviColorTableOff3Green();
               break;
            case NaviLayoutStyle.Office2003Silver:
               renderer = new NaviGroupRendererOff3();
               ((NaviGroupRendererOff3)renderer).ColorTable = new NaviColorTableOff3Silver();
               break;
            case NaviLayoutStyle.Office2007Blue:
               renderer = new NaviGroupRendererOff7();
               ((NaviGroupRendererOff7)renderer).ColorTable = new NaviColorTableOff7();
               break;
            case NaviLayoutStyle.Office2007Black:
               renderer = new NaviGroupRendererOff7();
               ((NaviGroupRendererOff7)renderer).ColorTable = new NaviColorTableOff7Black();
               break;
            case NaviLayoutStyle.Office2007Silver:
               renderer = new NaviGroupRendererOff7();
               ((NaviGroupRendererOff7)renderer).ColorTable = new NaviColorTableOff7Silver();
               break;
            //case NaviLayoutStyle.Office2010:
            //   // TODO renderer = new NaviButtonRendererOff10();
            //   break;
         }
         Invalidate();
      }

      #endregion

      #region Event Handling

      /// <summary>
      /// Occurs when the user clicks with the mouse inside the header region
      /// </summary>
      public event MouseEventHandler HeaderMouseClick
      {
         add { lock (threadLock) { m_headerMouseClick += value; } }
         remove { lock (threadLock) { m_headerMouseClick -= value; } }
      }

      /// <summary>
      /// Occurs when the user clicks with the mouse inside the header region
      /// </summary>
      /// <param name="e">Additional mouse event info</param>
      protected virtual void OnHeaderMouseClick(MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            if (m_expanded)
            {
               Collapse();
            }
            else
            {
               Expand();
            }
         }
         else if (e.Button == MouseButtons.Right)
         {
            if (m_headerContextMenuStrip != null)
            {
               m_headerContextMenuStrip.Show(this, e.Location);
            }
         }
         MouseEventHandler handler = m_headerMouseClick;
         if (handler != null)
         {
            handler(this, e);
         }
      }

      #endregion

      #region ISupportInitialize Members

      /// <summary>
      /// Starts the initialization for the control
      /// </summary>
      public void BeginInit()
      {
      }

      /// <summary>
      /// Automatically creates the bounds for the control based on the current header height.
      /// </summary>
      public void EndInit()
      {
         CreateBounds(m_headerHeight);
      }

      #endregion
   }
}