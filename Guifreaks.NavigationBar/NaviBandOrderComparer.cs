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
using System.Collections;

namespace Guifreaks.NavigationBar
{
   public class NaviBandOrderComparer : IComparer
   {
      #region IComparer Members

      public int Compare(object x, object y)
      {
         if (!(x is NaviBand) || !(y is NaviBand))
            throw new ArgumentException("Both of the argument should be of type NaviBand");

         NaviBand bandx = (NaviBand)x;
         NaviBand bandy = (NaviBand)y;

         return bandx.Order.CompareTo(bandy.Order);
      }

      #endregion
   }
}
