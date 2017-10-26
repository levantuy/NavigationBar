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
   /// Indicates how a control is presented to the user. 
   /// </summary>
   public enum NaviLayoutStyle
   {
      /// <summary>
      /// Presents the control in the Blue Office 2003 colour and layout style
      /// </summary>
      Office2003Blue,

      /// <summary>
      /// Presents the control in the Green Office 2003 colour and layout style
      /// </summary>
      Office2003Green,

      /// <summary>
      /// Presents the control in the Silver Office 2003 colour and layout style
      /// </summary>
      Office2003Silver,

      /// <summary>
      /// Indicates that the control should be presented as the blue Ms Office 2007 Navigation pane
      /// </summary>
      Office2007Blue,

      /// <summary>
      /// Indicates that the control should be presented as the silver Ms Office 2007 Navigation pane
      /// </summary>
      Office2007Silver,

      /// <summary>
      /// Indicates that the control should be presented as the black Ms Office 2007 Navigation pane
      /// </summary>
      Office2007Black,
   }
}
