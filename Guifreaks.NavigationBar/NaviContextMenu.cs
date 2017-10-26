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
using System.Windows.Forms;
using System.ComponentModel;

namespace Guifreaks.NavigationBar
{
   [ToolboxItem(false)]
   public class NaviContextMenu : ContextMenuStrip
   {
      ToolStripRenderer renderer;
      ProfessionalColorTable colorTable;

      #region Constructor

      public NaviContextMenu()
         : base()
      {
         Initialize();
      }

      #endregion

      #region Methods

      private void Initialize()
      {
         colorTable = new NaviToolstripOffice07ColorTable();
         renderer = new NaviToolstripOffice07Renderer(colorTable);
         base.Renderer = renderer;
      }

      #endregion
   }
}
