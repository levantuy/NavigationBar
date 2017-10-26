using System.ComponentModel;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Drawing;

namespace Guifreaks.NavigationBar.Design
{
   internal class NavigationBarDesigner : ParentControlDesigner
   {
      #region Fields

      NavigationBar m_designingControl;
      ISelectionService selectionService;

      #endregion

      #region Constructor
      #endregion

      #region Static

      public static int LoWord(int dwValue)
      {
         return dwValue & 0xFFFF;
      }

      public static int HiWord(int dwValue)
      {
         return (dwValue >> 16) & 0xFFFF;
      }

      #endregion

      #region Properties
      #endregion

      #region Methods

      private void InitializeServices()
      {
         selectionService = (ISelectionService)GetService(typeof(ISelectionService));
         if (selectionService != null)
         {
            selectionService.SelectionChanged += new System.EventHandler(selectionService_SelectionChanged);
         }
      }

      #endregion

      #region Overrides

      public override void Initialize(IComponent component)
      {
         base.Initialize(component);
         m_designingControl = component as NavigationBar;
         InitializeServices();
      }

      #endregion

      #region Event Handling

      void selectionService_SelectionChanged(object sender, System.EventArgs e)
      {
         if (selectionService.PrimarySelection is NavigationBarBandButton)
         {
            m_designingControl.SetActiveBand(
               ((NavigationBarBandButton)selectionService.PrimarySelection).BarBand);
         }
      }

      #endregion
   }
}
