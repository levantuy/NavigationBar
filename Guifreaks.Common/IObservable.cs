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

using System.Collections.Generic;

namespace Guifreaks.Common
{
   /// <summary>
   /// Represents an object which can be observed by <see cref="IObserver"/> objects. 
   /// </summary>
   /// <remarks>
   /// The IObservable object is responsible for notifying the objects that observes 
   /// the object by calling the Notify method 
   /// </remarks>
   public interface IObservable
   {
      /// <summary>
      /// Contains the observers currently observing this object
      /// </summary>
      List<IObserver> Observers { get; }


      /// <summary>
      /// Notifies the observer in the available in the list <see cref="Observers"/>
      /// </summary>
      /// <param name="obj">The observable object</param>
      /// <param name="id">An identification which caused this notification</param>
      /// <param name="arguments">Additional arguments</param>
      void NotifyObservers(IObservable obj, string id, object arguments);
   }
}
