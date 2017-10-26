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
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Guifreaks.Common;
using System.Drawing;

namespace Guifreaks.NavigationBar
{
   [
   Designer(typeof(Guifreaks.NavigationBar.Design.NaviBarDesigner)),
   DefaultEvent("activeBandChanged"),
   DefaultProperty("Bands"),
   ToolboxItem(true),
   ToolboxBitmap(typeof(NaviBar))
   ]
   public partial class NaviBar : NaviControl, IObservable, ISupportInitialize
   {
      #region Fields

      NaviBandCollection bands;
      NaviButtonCollection buttons;
      NaviLayout naviLayout;
      NaviBand activeBand;

      NaviBandEventHandler activeBandChanging;
      EventHandler activeBandChanged;
      EventHandler layoutChanged;
      ControlEventHandler bandAdded;
      NaviBarSettings settings;

      bool initializing = true;
      bool showMinimizeButton = true;
      bool showMoreOptionsButton = true;
      bool collapsed = false;
      bool showCollapseButton = true;
      int headerHeight = 27;
      int minimizedButtonWidth = 25;
      int minimizedPanelHeight = 32;
      int buttonHeight = 32;
      int visibleLargeButtons;

      #endregion

      #region Constructor

      /// <summary>
      /// Initializes a new instance of the NaviBar class
      /// </summary>
      public NaviBar()
      {
         InitializeComponent();
         Initialize();
      }

      /// <summary>
      /// Iniializes a new instance of the NaviBar class
      /// </summary>
      /// <param name="container"></param>
      public NaviBar(IContainer container)
      {
         container.Add(this);
         Initialize();
         InitializeComponent();
      }

      #endregion

      #region Properties

      // Design time visible

      /// <summary>
      /// Gets or sets the collection of Bands
      /// </summary>
      [
      Browsable(true),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
      ]
      public NaviBandCollection Bands
      {
         get { return bands; }
         set { bands = value; }
      }

      /// <summary>
      /// Gets or sets the active band
      /// </summary>
      [
      Browsable(true),
      ]
      public NaviBand ActiveBand
      {
         get { return activeBand; }
         set
         {
            SetActiveBand(value);
         }
      }

      /// <summary>
      /// Gets or sets the layout
      /// </summary>
      [
      Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
      ]
      public NaviLayout NaviLayout
      {
         get { return naviLayout; }
         set
         {
            if (value == null)
               throw new ArgumentNullException();
            naviLayout = value;
            naviLayout.Bar = this;
            observers.Add(naviLayout);
         }
      }

      /// <summary>
      /// Gets or sets the collection of buttons
      /// </summary>
      [
      Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
      ]
      public NaviButtonCollection Buttons
      {
         get { return buttons; }
         set { buttons = value; }
      }

      /// <summary>
      /// Gets or sets the settings file
      /// </summary>
      [
      Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
      ]
      public NaviBarSettings Settings
      {
         get
         {
            if (settings == null)
               settings = new NaviBarSettings();
            settings.BandSettings.Clear();
            settings.VisibleButtons = visibleLargeButtons;
            settings.Collapsed = collapsed;

            foreach (NaviBand band in bands)
            {
               NaviBandSetting setting = new NaviBandSetting();
               
               setting.Name = band.Text;
               setting.Order = band.Order;
               setting.Visible = band.Visible;

               settings.BandSettings.Add(setting);
            }

            return settings;
         }
         set
         {
            settings = value;
         }
      }

      /// <summary>
      /// Gets or sets the height of the header containing the title
      /// </summary>
      [
      Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(27)
      ]
      public int HeaderHeight
      {
         get { return headerHeight; }
         set
         {
            headerHeight = value;

            if (!initializing)
               OnLayout(new LayoutEventArgs(this, "HeaderHeight"));
         }
      }

      /// <summary>
      /// Gets or sets the height of the minimized buttons panel
      /// </summary>
      [
      Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(32)
      ]
      public int MinimizedPanelHeight
      {
         get { return minimizedPanelHeight; }
         set
         {
            minimizedPanelHeight = value;
            if (!initializing)
               OnLayout(new LayoutEventArgs(this, "MinimizedPanelHeight"));
            Invalidate();
         }
      }

      /// <summary>
      /// TODO Gets or sets the font of the header
      /// </summary>
      //[
      //Browsable(true),
      //NotifyParentProperty(true),
      //EditorBrowsable(EditorBrowsableState.Always),
      //DefaultValue(typeof(Font), "Arial; 11,25pt; style=Bold")
      //]
      //public Font HeaderFont
      //{
      //   get { return headerFont; }
      //   set
      //   {
      //      headerFont = value;
      //      Bar.Invalidate();
      //   }
      //}

      /// <summary>
      /// Gets or sets the default height of the buttons
      /// </summary>
      [
      Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(32)
      ]
      public int ButtonHeight
      {
         get { return buttonHeight; }
         set
         {
            buttonHeight = value;
            if (!initializing)
               OnLayout(new LayoutEventArgs(this, "ButtonHeight"));
         }
      }

      /// <summary>
      /// Gets or sets whether to show the more options button or not
      /// </summary>
      [
      Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(true)
      ]
      public bool ShowMoreOptionsButton
      {
         get { return showMoreOptionsButton; }
         set
         {
            showMoreOptionsButton = value;
            if (!initializing)
               OnLayout(new LayoutEventArgs(this, "ShowMoreOptionsButton"));
         }
      }

      /// <summary>
      /// Gets or sets whether the pane is minimized or not
      /// </summary>
      [
      Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(false)
      ]
      public bool Collapsed
      {
         get { return collapsed; }
         set
         {
            bool oldCollapsed = collapsed;
            collapsed = value;
            naviLayout.SwitchCollapsion(value, oldCollapsed);
            if (!initializing)
               OnLayout(new LayoutEventArgs(this, "Collapsed"));
            Invalidate();
         }
      }

      /// <summary>
      /// Gets or sets whether the pane is minimized or not
      /// </summary>
      [
      Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(true)
      ]
      public bool ShowCollapseButton
      {
         get { return showCollapseButton; }
         set
         {
            showCollapseButton = value;
            if (!initializing)
               OnLayout(new LayoutEventArgs(this, "ShowCollapseButton"));
            Invalidate();
         }
      }

      /// <summary>
      /// Gets or sets whether the minimize button should be visible
      /// </summary>
      [
      Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(true)
      ]
      public bool ShowMinimizeButton
      {
         get { return showMinimizeButton; }
         set { showMinimizeButton = value; }
      }

      /// <summary>
      /// Gets or sets the width of the minimized buttons
      /// </summary>
      [
      Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(25)
      ]
      public int MinimizedButtonWidth
      {
         get { return minimizedButtonWidth; }
         set { minimizedButtonWidth = value; }
      }

      /// <summary>
      /// Gets or sets the amount of visible buttons
      /// </summary>
      [
      Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(0)
      ]
      public int VisibleLargeButtons
      {
         get { return visibleLargeButtons; }
         set
         {
            if (!initializing)
            {
               if (value < 0)
               {
                  visibleLargeButtons = 0;
               }
               else if (value > naviLayout.VisibleButtons)
               {
                  visibleLargeButtons = naviLayout.VisibleButtons;
               }
               else
               {
                  visibleLargeButtons = value;
               }
               OnLayout(new LayoutEventArgs(this, "VisibleLargeButtos"));
            }
            else
            {
               visibleLargeButtons = value;
            }
            Invalidate();
         }
      }

      // Design time not visible

      #endregion

      #region Events

      /// <summary>
      /// Occurs before the active band is changed
      /// </summary>
      public event NaviBandEventHandler ActiveBandChanging
      {
         add { lock (threadLock) { activeBandChanging += value; } }
         remove { lock (threadLock) { activeBandChanging -= value; } }
      }

      /// <summary>
      /// Occurs after the active band has been changed
      /// </summary>
      public event EventHandler ActiveBandChanged
      {
         add { lock (threadLock) { activeBandChanged += value; } }
         remove { lock (threadLock) { activeBandChanged -= value; } }
      }

      /// <summary>
      /// Occurs when the layout has been changed
      /// </summary>
      public event EventHandler LayoutChanged
      {
         add { lock (threadLock) { layoutChanged += value; } }
         remove { lock (threadLock) { layoutChanged -= value; } }
      }

      /// <summary>
      /// Occurs after a new band has been added to the collection of bands
      /// </summary>
      public event ControlEventHandler BandAdded
      {
         add { lock (threadLock) { bandAdded += value; } }
         remove { lock (threadLock) { bandAdded -= value; } }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Initializes the Control for the first time
      /// </summary>
      private void Initialize()
      {
         SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
         SetStyle(ControlStyles.UserPaint, true);
         SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         SetStyle(ControlStyles.ResizeRedraw, true);

         bands = new NaviBandCollection();
         bands.ItemAdded += new CollectionEventHandler(bands_ItemAdded);
         bands.ItemRemoved += new CollectionEventHandler(bands_ItemRemoved);
         buttons = new NaviButtonCollection();
      }

      /// <summary>
      /// Creates the 2007 office layout objects
      /// </summary>
      private void Initialize2007Layout()
      {
         if (!(naviLayout is NaviLayoutOff))
         {
            if (naviLayout != null)
               naviLayout.Dispose();
            NaviLayout = new NaviLayoutOff();
            naviLayout.Bar = this;
            naviLayout.InitializeChildControls();
            NaviLayout.EndInit();
         }

         NaviLayoutOff offLayout = (NaviLayoutOff)naviLayout;
         offLayout.ShowNeverCollapse = false;
         if (!(offLayout.Renderer is NaviBarRendererOff7))
            offLayout.Renderer = new NaviBarRendererOff7();

         if (!(offLayout.SplitterRenderer is NaviSplitterRendererOff7))
            offLayout.SplitterRenderer = new NaviSplitterRendererOff7();

      }

      /// <summary>
      /// Creates the 2003 office layout objects
      /// </summary>
      private void Initialize2003Layout()
      {
         if (!(naviLayout is NaviLayoutOff))
         {
            if (naviLayout != null)
               naviLayout.Dispose();
            NaviLayout = new NaviLayoutOff();
            naviLayout.Bar = this;
            naviLayout.InitializeChildControls();
         }

         NaviLayoutOff offLayout = (NaviLayoutOff)naviLayout;
         offLayout.ShowNeverCollapse = true;
         if (!(offLayout.Renderer is NaviBarRendererOff3))
            offLayout.Renderer = new NaviBarRendererOff3();

         if (!(offLayout.SplitterRenderer is NaviSplitterRendererOff3))
            offLayout.SplitterRenderer = new NaviSplitterRendererOff3();
      }

      internal void ReInitializeLayout()
      {
         NaviLayoutOff offLayout;
         switch (LayoutStyle)
         {
            case NaviLayoutStyle.Office2003Blue:
               Initialize2003Layout();
               offLayout = (NaviLayoutOff)naviLayout;

               ((NaviSplitterRendererOff3)offLayout.SplitterRenderer).ColorTable =
                  new NaviColorTableOff3();
               ((NaviBarRendererOff3)offLayout.Renderer).ColorTable = new NaviColorTableOff3();
               break;
            case NaviLayoutStyle.Office2003Green:
               Initialize2003Layout();
               offLayout = (NaviLayoutOff)naviLayout;

               ((NaviSplitterRendererOff3)offLayout.SplitterRenderer).ColorTable =
                  new NaviColorTableOff3Green();
               ((NaviBarRendererOff3)offLayout.Renderer).ColorTable = new NaviColorTableOff3Green();
               break;
            case NaviLayoutStyle.Office2003Silver:
               Initialize2003Layout();
               offLayout = (NaviLayoutOff)naviLayout;

               ((NaviSplitterRendererOff3)offLayout.SplitterRenderer).ColorTable =
                  new NaviColorTableOff3Silver();

               ((NaviBarRendererOff3)offLayout.Renderer).ColorTable = new NaviColorTableOff3Silver();
               break;
            case NaviLayoutStyle.Office2007Blue:
               Initialize2007Layout();
               offLayout = (NaviLayoutOff)naviLayout;

               ((NaviSplitterRendererOff7)offLayout.SplitterRenderer).ColorTable =
                  new NaviColorTableOff7();
               ((NaviBarRendererOff7)offLayout.Renderer).ColorTable = new NaviColorTableOff7();
               break;
            case NaviLayoutStyle.Office2007Black:
               Initialize2007Layout();
               offLayout = (NaviLayoutOff)naviLayout;

               ((NaviSplitterRendererOff7)offLayout.SplitterRenderer).ColorTable =
                  new NaviColorTableOff7Black();

               ((NaviBarRendererOff7)offLayout.Renderer).ColorTable = new NaviColorTableOff7Black();

               break;
            case NaviLayoutStyle.Office2007Silver:
               Initialize2007Layout();
               offLayout = (NaviLayoutOff)naviLayout;

               ((NaviSplitterRendererOff7)offLayout.SplitterRenderer).ColorTable =
                  new NaviColorTableOff7Silver();

               ((NaviBarRendererOff7)offLayout.Renderer).ColorTable = new NaviColorTableOff7Silver();
               break;
         }
         if (!initializing)
            OnLayout(new LayoutEventArgs(this, "Collapsed"));
         Invalidate();
      }

      /// <summary>
      /// Raises the ActiveBandChanging event
      /// </summary>
      /// <param name="e">Additional event info</param>
      internal void OnActiveBandChanging(NaviBandEventArgs e)
      {
         NaviBandEventHandler handler = activeBandChanging;
         if (handler != null)
         {
            handler(this, e);
         }
      }

      /// <summary>
      /// Raises the ActiveBandChanged event
      /// </summary>
      /// <param name="e">Additional event info</param>
      internal void OnActiveBandChanged(EventArgs e)
      {
         EventHandler handler = activeBandChanged;
         if (handler != null)
         {
            handler(this, e);
         }
      }

      /// <summary>
      /// Raises the LayoutChanged event
      /// </summary>
      /// <param name="e">Additional event info</param>
      internal void OnLayoutChanged(EventArgs e)
      {
         EventHandler handler = layoutChanged;
         if (handler != null)
         {
            handler(this, e);
         }
      }

      /// <summary>
      /// Raises the BandAdded event
      /// </summary>
      /// <param name="e">Additional event info</param>
      internal void OnBandAdded(ControlEventArgs e)
      {
         ControlEventHandler handler = bandAdded;
         if (handler != null)
         {
            handler(this, e);
         }
      }

      /// <summary>
      /// Adds a new band to the collection of bands
      /// </summary>
      /// <param name="band">The new band</param>
      internal void AddBand(NaviBand band)
      {
         if (!Controls.Contains(band))
            Controls.Add(band);

         if (!bands.Contains(band))
            bands.SilentAdd(band);

         AddButton(band);
         band.VisibleChanged += new EventHandler(band_VisibleChanged);

         band.LayoutStyle = LayoutStyle;
         band.Button.LayoutStyle = LayoutStyle;

         OnBandAdded(new ControlEventArgs(band));
      }

      /// <summary>
      /// Changes the currently active band to a new band
      /// </summary>
      /// <param name="band">The band to change to</param>
      public void SetActiveBand(NaviBand newBand)
      {
         NaviBandEventArgs e = new NaviBandEventArgs(newBand);
         OnActiveBandChanging(e);
         if (!e.Canceled)
         {
            if (activeBand != newBand)
            {
               foreach (NaviBand band in bands)
               {
                  if ((band != newBand) && (band.Button != null))
                  {
                     band.Button.Active = false;
                  }
               }
            }
            if ((newBand != null) && (newBand.Button != null))
            {
               newBand.Button.Active = true;
            }

            activeBand = newBand;

            OnLayout(new LayoutEventArgs(this, "ActiveBand"));
            OnActiveBandChanged(new EventArgs());
            Invalidate();
         }
         else
         {
            // Lost focus but did not recieve an mouse leave event. So force redraw
            newBand.Button.Active = false;
         }
      }

      /// <summary>
      /// Adds the band button to the collection of controls
      /// </summary>
      /// <param name="band">The band</param>
      private void AddButton(NaviBand band)
      {
         if (band.Button == null)
         {
            NaviButton button = new NaviButton();

            button.SmallImage = band.SmallImage;
            button.LargeImage = band.LargeImage;
            button.Text = band.Text;
            button.Click += new EventHandler(button_Click);

            band.Button = button;
         }
         if (!Controls.Contains(band.Button))
         {
            Controls.Add(band.Button);
         }
         if (!buttons.Contains(band.Button))
         {
            buttons.Add(band.Button);
         }
      }

      /// <summary>
      /// Removes a band from te collection of bands
      /// </summary>
      /// <param name="band">The band to remove</param>
      public void RemoveBand(NaviBand band)
      {
         if (band.Button != null)
         {
            band.Button.Click -= new EventHandler(button_Click);
            band.VisibleChanged -= new EventHandler(band_VisibleChanged);
         }

         if (Controls.Contains(band.Button))
            Controls.Remove(band.Button);
         if (buttons.Contains(band.Button))
            buttons.Remove(band.Button);

         if (Controls.Contains(band))
            Controls.Remove(band);
         if (bands.Contains(band))
            bands.Remove(band);
      }

      /// <summary>
      /// Applies the settings currently loaded in the Settings property
      /// </summary>
      /// <remarks>
      /// It's possible that no setting exist for this particular band. For example a new
      /// version has been released. Then this band is added at the end of the collection 
      /// and visible is set to true
      /// </remarks>
      public void ApplySettings()
      {
         if (settings == null) 
            return;
         
         foreach (NaviBand band in bands)
         {
            // try to find the setting
            NaviBandSetting setting = null;
            foreach (NaviBandSetting tmpSetting in settings.BandSettings)
            {
               if (tmpSetting.Name.ToLower() == band.Text.ToLower())
                  setting = tmpSetting;
            }

            // It's possible that no setting exist for this particular band. For example a new
            // version has been released. Then this band is added at the end of the collection 
            // and visible is set to true
            if (setting == null)
            {
               band.Order = 999;
               band.Visible = true;
            }
            else
            {
               band.Visible = setting.Visible;
               band.Order = setting.Order;
            }   
         }

         VisibleLargeButtons = settings.VisibleButtons;
         Collapsed = settings.Collapsed;
         bands.Sort(new NaviBandOrderComparer());

         // Rebuild ordering values. This is to prevent 999 and duplicate values from showing 
         // up in the settings file
         for (int i = 0; i < bands.Count; i++)
            bands[i].Order = i;
         OnLayout(new LayoutEventArgs(this, "Band.Visible"));
      }

      #endregion

      #region Overrides

      /// <summary>
      /// Overriden. Raises the ControlAdded event
      /// </summary>
      /// <param name="e">Additional event info</param>
      protected override void OnControlAdded(System.Windows.Forms.ControlEventArgs e)
      {
         base.OnControlAdded(e);
         if ((e.Control is NaviBand)
         && !(e.Control is NaviBandCollapsed))
         {
            AddBand(e.Control as NaviBand);
            OnLayout(new LayoutEventArgs(this, "Bands"));
         }
      }

      /// <summary>
      /// Overriden. Raises the ControlRemoved event
      /// </summary>
      /// <param name="e">Additional event info</param>
      protected override void OnControlRemoved(System.Windows.Forms.ControlEventArgs e)
      {
         base.OnControlRemoved(e);
         if (e.Control is NaviBand)
         {
            RemoveBand(e.Control as NaviBand);
         }
      }

      /// <summary>
      /// Overriden. Raises the Paint event
      /// </summary>
      /// <param name="e">Additional paint info</param>
      protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);
         if (!initializing)
            naviLayout.Draw(e.Graphics);
      }

      /// <summary>
      /// Overriden. Raises the PaintBackground
      /// </summary>
      /// <param name="pevent">Additional paint info</param>
      protected override void OnPaintBackground(PaintEventArgs pevent)
      {
         if (!initializing)
            naviLayout.DrawBackground(pevent.Graphics);
      }

      /// <summary>
      /// Overriden. Raises the MouseDown event
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnMouseDown(MouseEventArgs e)
      {
         base.OnMouseDown(e);
         NotifyObservers(this, "MouseDown", e);
      }

      /// <summary>
      /// Overriden. Raises the MouseDown event.
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnMouseMove(MouseEventArgs e)
      {
         base.OnMouseMove(e);
         NotifyObservers(this, "MouseMove", e);
      }

      /// <summary>
      /// Overriden. Raises the MouseLeave event and changes the cursor back to default
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnMouseLeave(EventArgs e)
      {
         base.OnMouseLeave(e);
         NotifyObservers(this, "MouseLeave", e);
      }

      /// <summary>
      /// Overriden. Raises the MouseUp event
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnMouseUp(MouseEventArgs e)
      {
         base.OnMouseUp(e);
         NotifyObservers(this, "MouseUp", e);
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
         ReInitializeLayout();
      }

      /// <summary>
      /// Overriden. Raises the Resize event
      /// </summary>
      /// <param name="e">Additional mouse info</param>
      protected override void OnResize(EventArgs e)
      {
         base.OnResize(e);
         OnLayout(new LayoutEventArgs(this, "Size"));
      }

      /// <summary>
      /// Overriden. Raises the RightToLeftChanged event
      /// </summary>
      /// <param name="e">Additional event info</param>
      protected override void OnRightToLeftChanged(EventArgs e)
      {
         base.OnRightToLeftChanged(e);
         OnLayout(new LayoutEventArgs(this, "RightToLeft"));
      }

      /// <summary>
      /// Overriden. Raises the OnLayout event
      /// </summary>
      /// <param name="e"></param>
      protected override void OnLayout(LayoutEventArgs e)
      {
         base.OnLayout(e);
         if ((NaviLayout != null)
         && (!initializing))
         {
            NaviLayout.Layout(this, e);
         }
      }

      #endregion

      #region Event Handling

      void bands_ItemRemoved(object sender, ChildCollectionEventArgs e)
      {
         RemoveBand(e.Item as NaviBand);
      }

      void bands_ItemAdded(object sender, ChildCollectionEventArgs e)
      {
         AddBand(e.Item as NaviBand);
      }

      /// <summary>
      /// Changes the active button to the button on which this event occured
      /// </summary>
      /// <param name="sender">The button on which this event occured</param>
      /// <param name="e">Additional info</param>
      void button_Click(object sender, EventArgs e)
      {
         NaviButton button = sender as NaviButton;
         if (button != null)
         {
            foreach (NaviBand band in bands)
            {
               if (band.Button == button)
               {
                  SetActiveBand(band);
                  return;
               }
            }
         }
      }

      /// <summary>
      /// Relayouts the control
      /// </summary>
      /// <param name="sender">The band which triggered this event</param>
      /// <param name="e">Additional event info</param>
      void band_VisibleChanged(object sender, EventArgs e)
      {
         NaviBand band = sender as NaviBand;
         if ((band != null) && (band.Button != null))
         {
            band.Button.Visible = band.Visible;
         }
         OnLayout(new LayoutEventArgs(this, "Band.Visible"));
         Invalidate();
      }

      #endregion

      #region IObservable Members

      List<IObserver> observers = new List<IObserver>();

      /// <summary>
      /// Gets the list of observers
      /// </summary>
      public List<IObserver> Observers
      {
         get { return observers; }
      }

      /// <summary>
      /// Notifies the Observers
      /// </summary>
      /// <param name="obj">The observable object</param>
      /// <param name="id">An identification which caused this notification</param>
      /// <param name="arguments">Additional arguments</param>
      public void NotifyObservers(IObservable obj, string id, object arguments)
      {
         foreach (IObserver observer in observers)
            observer.Notify(obj, id, arguments);
      }

      #endregion

      #region ISupportInitialize Members

      public void BeginInit()
      {
         initializing = true;
      }

      public void EndInit()
      {
         ReInitializeLayout();
         initializing = false;
         naviLayout.EndInit();
         Invalidate();
      }

      #endregion
   }
}
