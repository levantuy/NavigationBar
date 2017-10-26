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
using System.Windows.Forms;

namespace Guifreaks.NavigationBar
{
   /// <summary>
   /// Represents a control with customizable drawing and layout styles
   /// </summary>
   [ToolboxItem(false)]
   public partial class NaviControl : ContainerControl
   {
      NaviLayoutStyle layoutStyle = NaviLayoutStyle.Office2007Blue;
      EventHandler layoutStyleChanged;

      protected readonly object threadLock = new object();

      #region Constructors

      /// <summary>
      /// Initializes a new instance of the NaviControl
      /// </summary>
      public NaviControl()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Initializes a new instance of the NaviControl
      /// </summary>
      /// <param name="container">The parent container</param>
      public NaviControl(IContainer container)
      {
         container.Add(this);
         InitializeComponent();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Indicates how the control is presented to the user
      /// </summary>
      [DefaultValue(NaviLayoutStyle.Office2007Blue)]
      public NaviLayoutStyle LayoutStyle
      {
         get { return layoutStyle; }
         set
         {
            layoutStyle = value;
            OnLayoutStyleChanged(new EventArgs());
         }
      }

      #endregion

      #region Events

      /// <summary>
      /// Occurs after the layout style has been changed
      /// </summary>
      public event EventHandler LayoutStyleChanged
      {
         add { lock (threadLock) { layoutStyleChanged += value; } }
         remove { lock (threadLock) { layoutStyleChanged -= value; } }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Raises the LayoutStyleChanged event
      /// </summary>
      /// <param name="e">Additional event info</param>
      protected virtual void OnLayoutStyleChanged(EventArgs e)
      {
         EventHandler handler = layoutStyleChanged;
         if (handler != null)
            handler(this, e);
      }

      #endregion
   }
}