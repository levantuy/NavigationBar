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

namespace Guifreaks.Common
{
   /// <summary>
   /// Represents an object which can observe other <see cref="IObservable"/> objects
   /// </summary>
   public interface IObserver
   {
      /// <summary>
      /// Handles the notification the <see cref="IObservable"/> sent. 
      /// </summary>
      /// <param name="obj">The observable object</param>
      /// <param name="id">An identification which caused this notification</param>
      /// <param name="arguments">Additional info</param>
      void Notify(IObservable obj, string id, object arguments);
   }
}
