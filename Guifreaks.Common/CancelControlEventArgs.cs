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

using System.Windows.Forms;

namespace Guifreaks.Common
{
   /// <summary>
   /// This class provides extra event info and is cancable
   /// </summary>
   public class CancelControlEventArgs : ControlEventArgs
   {
      private bool cancel = false;

      /// <summary>
      /// Initializes a new instance of the CancelControlEventArgs class
      /// </summary>
      public CancelControlEventArgs(Control control)   
         : base(control)
      {
      }

      /// <summary>
      /// Gets or sets whether this event is canceled or not
      /// </summary>
      public bool Cancel
      {
         get { return cancel; }
         set { cancel = value; }
      }
   }

   public delegate void CancelControlEventHandler(Control sender, ControlEventArgs e);
}