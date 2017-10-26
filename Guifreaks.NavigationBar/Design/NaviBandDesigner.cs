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
using System.Windows.Forms.Design;

namespace Guifreaks.NavigationBar.Design
{
   public class NaviBandDesigner : ParentControlDesigner
   {
      NaviBand designingComponent;

      public override void Initialize(System.ComponentModel.IComponent component)
      {
         base.Initialize(component);
         if (component is NaviBand)
            designingComponent = (NaviBand)component;

         EnableDesignMode(designingComponent.ClientArea, "ClientArea");
      }
   }
}
