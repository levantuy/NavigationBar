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

namespace Guifreaks.NavigationBar
{
   public delegate void NaviBandEventHandler(object sender, NaviBandEventArgs e);

   public class NaviBandEventArgs : EventArgs
   {
      #region Fields

      NaviBand newActiveBand;
      bool cancel = false;

      #endregion

      #region Constructor

      /// <summary>
      /// Initializes a new instance of the NaviBandEventArgs class
      /// </summary>
      /// <param name="newActiveButton">The new active band</param>
      public NaviBandEventArgs(NaviBand newActiveBand)
         : base()
      {
         this.newActiveBand = newActiveBand;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the new active band
      /// </summary>
      public NaviBand NewActiveBand
      {
         get { return newActiveBand; }
         set { newActiveBand = value; }
      }

      /// <summary>
      /// Gets or sets whether the event is canceled
      /// </summary>
      public bool Canceled
      {
         get { return cancel; }
         set { cancel = value; }
      }

      #endregion
   }
   
}
