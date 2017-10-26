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

namespace Guifreaks.Common
{
   /// <summary>
   /// Contains event information for a <see cref="PopupClosed"/> event.
   /// </summary>
   public class PopupClosedEventArgs : EventArgs
   {
      /// <summary>
      /// The popup form.
      /// </summary>
      private Form popup = null;

      /// <summary>
      /// Gets the popup form which is being closed.
      /// </summary>
      public Form Popup
      {
         get { return popup; }
      }

      /// <summary>
      /// Constructs a new instance of this class for the specified
      /// popup form.
      /// </summary>
      /// <param name="popup">Popup Form which is being closed.</param>
      public PopupClosedEventArgs(Form popup)
      {
         this.popup = popup;
      }
   }

   /// <summary>
   /// Represents the method which responds to a <see cref="PopupClosed"/> event.
   /// </summary>
   public delegate void PopupClosedEventHandler(object sender, PopupClosedEventArgs e);
}
