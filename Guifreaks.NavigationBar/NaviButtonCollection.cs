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

using System.Collections;
using Guifreaks.Common;
using System;

namespace Guifreaks.NavigationBar
{
   /// <summary>
   /// This class represents a collection of <see cref="NaviButton"/> items
   /// </summary>
   public class NaviButtonCollection : ChildControlCollection
   {
      #region Constructor

      /// <summary>
      /// Initializes a new instance of the NaviButtonCollection class
      /// </summary>
      public NaviButtonCollection()
         : base()
      {
      }

      #endregion

      #region Methods

      /// <summary>
      /// Gets or sets a NavigationButton at a certain location
      /// </summary>
      /// <param name="index">The index</param>
      /// <returns>The item if found</returns>
      public NaviButton this[int index]
      {
         get { return ((NaviButton)List[index]); }
         set { List[index] = value; }
      }

      /// <summary>
      /// Adds a new button the the collection
      /// </summary>
      /// <param name="value">The new button to add</param>
      /// <exception cref="ArgumentNullExceptions">
      /// Raised when the button argument is null
      /// </exception>
      internal void Add(NaviButton value)
      {
         if (value == null)
            throw new ArgumentNullException();
         base.List.Add(value);
      }

      /// <summary>
      /// Removes an item from the list
      /// </summary>
      /// <param name="value">The button to remove</param>
      /// <exception cref="ArgumentNullExceptions">
      /// Raised when the button argument is null
      /// </exception>
      internal void Remove(NaviButton value)
      {
         if (value == null)
            throw new ArgumentNullException();
         base.List.Remove(value);
      }

      /// <summary>
      /// Determines whether the list contains a specific value
      /// </summary>
      /// <param name="band">The value</param>
      /// <returns>Returns true if the list contains the item; false otherwise</returns>
      public bool Contains(NaviButton button)
      {
         return base.List.Contains(button);
      }

      #endregion
   }
}
