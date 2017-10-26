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

namespace Guifreaks.NavigationBar
{
   /// <summary>
   /// Indicates what input has been given to the control
   /// </summary>
   public enum InputState
   {
      /// <summary>
      /// Indicates that no input has been given
      /// </summary>
      Normal,

      /// <summary>
      /// Indicates that the user is currently clicking on the control
      /// </summary>
      Clicked,

      /// <summary>
      /// Indicates that the user is currently hovering the control with the mouse
      /// </summary>
      Hovered,
   }
}
