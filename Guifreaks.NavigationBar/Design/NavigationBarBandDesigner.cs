using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Design;

namespace Guifreaks.NavigationBar.Design
{
   public class NavigationBarBandDesigner : ParentControlDesigner
   {
      #region Overrides

      public override SelectionRules SelectionRules
      {
         get { return SelectionRules.Locked; }
      }

      #endregion
   }
}
