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

using System.Windows.Forms.Layout;
using Guifreaks.Common;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Guifreaks.NavigationBar
{
   [TypeConverter(typeof(ExpandableObjectConverter))]
   public abstract class NaviLayout : Component, IObserver
   {
      #region IObserver Members

      /// <summary>
      /// Overriden. Handles the Notification the observable object sent
      /// </summary>
      /// <param name="obj">The observable object</param>
      /// <param name="id">An identification which caused this notification</param>
      /// <param name="arguments">Additional info</param>
      public abstract void Notify(IObservable obj, string id, object arguments);

      #endregion

      /// <summary>
      /// Gets the amount of visible buttons
      /// </summary>
      public abstract int VisibleButtons { get; }

      /// <summary>
      /// Draws the Navigation pane
      /// </summary>
      /// <param name="g">Graphics object providing drawing functionality</param>
      public abstract void Draw(Graphics g);

      /// <summary>
      /// Draws the background of the Navigation pane
      /// </summary>
      /// <param name="g">Graphics object providing drawing functionality</param>
      public abstract void DrawBackground(Graphics g);

      /// <summary>
      /// Requests that the layout engine should perform a layout operation
      /// </summary>
      /// <param name="container">The container </param>
      /// <param name="layoutEventArgs">Additional event info</param>
      /// <returns></returns>
      public abstract bool Layout(object container, LayoutEventArgs layoutEventArgs);

      /// <summary>
      /// Initializes the child controls, only call once. 
      /// </summary>
      public abstract void InitializeChildControls();

      /// <summary>
      /// Handles additional functionality at the end of the initialization
      /// </summary>
      public abstract void EndInit();

      /// <summary>
      /// Changes the navigation bar to collapsed view 
      /// </summary>     
      public abstract void SwitchCollapsion(bool collapse, bool oldCollapsed);

      /// <summary>
      /// Gets or sets the Navigationbar
      /// </summary>
      public NaviBar Bar;
   }
}
