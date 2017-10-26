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
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Guifreaks.Common
{
   /// <summary>
   /// Arguments to a <see cref="PopupCancelEvent"/>.  Provides a
   /// reference to the popup form that is to be closed and 
   /// allows the operation to be cancelled.
   /// </summary>
   public class PopupCancelEventArgs : EventArgs
   {
      /// <summary>
      /// Whether to cancel the operation
      /// </summary>
      private bool cancel = false;
      /// <summary>
      /// Mouse down location
      /// </summary>
      private Point location;
      /// <summary>
      /// Popup form.
      /// </summary>
      private Form popup = null;

      /// <summary>
      /// Constructs a new instance of this class.
      /// </summary>
      /// <param name="popup">The popup form</param>
      /// <param name="location">The mouse location, if any, where the
      /// mouse event that would cancel the popup occured.</param>
      public PopupCancelEventArgs(Form popup, Point location)
      {
         this.popup = popup;
         this.location = location;
         this.cancel = false;
      }

      /// <summary>
      /// Gets the popup form
      /// </summary>
      public Form Popup
      {
         get
         {
            return this.popup;
         }
      }

      /// <summary>
      /// Gets the location that the mouse down which would cancel this 
      /// popup occurred
      /// </summary>
      public Point CursorLocation
      {
         get
         {
            return this.location;
         }
      }

      /// <summary>
      /// Gets/sets whether to cancel closing the form. Set to
      /// <c>true</c> to prevent the popup from being closed.
      /// </summary>
      public bool Cancel
      {
         get
         {
            return this.cancel;
         }
         set
         {
            this.cancel = value;
         }
      }
   }

   /// <summary>
   /// Represents the method which responds to a <see cref="PopupCancel"/> event.
   /// </summary>
   public delegate void PopupCancelEventHandler(object sender, PopupCancelEventArgs e);
}
