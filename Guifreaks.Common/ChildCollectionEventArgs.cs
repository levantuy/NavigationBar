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

namespace Guifreaks.Common
{
   /// <summary>
   /// This class contains additional info about an add or remove operation
   /// For more information see <see cref="ChildControlCollection"/>
   /// </summary>
   public class ChildCollectionEventArgs : EventArgs
   {
      #region Fields

      private Object m_item;

      #endregion

      #region Constructor

      /// <summary>
      /// Initializes a new instance of the CollectionEventArgs class
      /// </summary>
      public ChildCollectionEventArgs()
      {
      }

      /// <summary>
      /// Initializes a new instance of the CollectionEventArgs class
      /// </summary>
      /// <param name="item">Item which changed the collection</param>
      public ChildCollectionEventArgs(object item)
      {
         m_item = item;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the item which changed the collection
      /// </summary>
      public Object Item
      {
         get { return m_item; }
         set { m_item = value; }
      }

      #endregion
   }

   public delegate void CollectionEventHandler(object sender, ChildCollectionEventArgs e);
}
