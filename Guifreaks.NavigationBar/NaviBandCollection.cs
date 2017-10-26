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
using Guifreaks.Common;

namespace Guifreaks.NavigationBar
{
   /// <summary>
   /// This class represents a collection of Navigation Bands
   /// </summary>
   public class NaviBandCollection : ChildControlCollection
   {
      #region Fields
      #endregion

      #region Constructor

      /// <summary>
      /// Initializes a new instance of the NaviBandCollection class
      /// </summary>
      public NaviBandCollection()
         : base()
      {
      }

      #endregion

      #region Properties
      #endregion

      #region Methods

      /// <summary>
      /// Gets or sets a NaviBand at a certain location
      /// </summary>
      /// <param name="index">The index</param>
      /// <returns>The item if found</returns>
      public NaviBand this[int index]
      {
         get { return ((NaviBand)List[index]); }
         set
         {
            List[index] = value;
         }
      }

      /// <summary>
      /// Adds a new NaviBand the the collection
      /// </summary>
      /// <param name="value">The new NaviBand to add</param>
      /// <exception cref="ArgumentNullExceptions">Raised when the band argument is null</exception>
      public void Add(NaviBand value)
      {
         if (value == null)
            throw new ArgumentNullException();

         // We need this to be able to reset the ordering of the bands
         value.OriginalOrder = base.List.Add(value);
      }

      /// <summary>
      /// Adds a new NaviBand the the collection without notifying parent
      /// </summary>
      /// <param name="value">The new NaviBand to add</param>
      /// <exception cref="ArgumentNullExceptions">Raised when the band argument is null</exception>
      internal void SilentAdd(NaviBand value)
      {
         if (value == null)
            throw new ArgumentNullException();
         try
         {
            base.notify = false;
            // We need this to be able to reset the ordering of the bands
            value.OriginalOrder = base.List.Add(value);
         }
         finally
         {
            base.notify = true;
         }
      }

      /// <summary>
      /// Removes a band from the collection of bands
      /// </summary>
      /// <param name="band">The band to remove</param>
      /// <exception cref="ArgumentNullExceptions">Raised when the band argument is null</exception>
      internal void Remove(NaviBand band)
      {
         if (band == null)
            throw new ArgumentNullException();
         base.List.Remove(band);
      }

      /// <summary>
      /// Determines whether the list contains a specific value
      /// </summary>
      /// <param name="band">The value</param>
      /// <returns>Returns true if the list contains the item; false otherwise</returns>
      public bool Contains(NaviBand band)
      {
         return base.List.Contains(band);
      }

      #endregion

      #region Overrides
      #endregion

      #region Event Handling
      #endregion
   }
}