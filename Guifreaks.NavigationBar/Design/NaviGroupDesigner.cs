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

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Guifreaks.NavigationBar.Design
{
   internal class NaviGroupDesigner : ParentControlDesigner
   {
      #region Fields

      IComponentChangeService changeService = null;
      ISelectionService selectionService = null;
      NaviGroup m_designingControl;

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

      #region Constructor
      #endregion

      #region Properties
      #endregion

      #region Methods

      private void CheckHeaderClick(Point location)
      {
         if (m_designingControl.HeaderRegion.IsVisible(location))
         {
            if (selectionService.PrimarySelection == m_designingControl)
               SetControlProperty("Expanded", !m_designingControl.Expanded);
         }
      }

      private void InitializeServices()
      {
         if (changeService == null)
         {
            this.changeService =
               GetService(typeof(IComponentChangeService)) as IComponentChangeService;
         }
         if (selectionService == null)
         {
            this.selectionService =
               GetService(typeof(ISelectionService)) as ISelectionService;
         }
      }

      private void SetControlProperty(string propName, object value)
      {
         PropertyDescriptor propDesc =
            TypeDescriptor.GetProperties(m_designingControl)[propName];

         if (changeService != null)
         {
            // Raise event that we are about to change
            this.changeService.OnComponentChanging(m_designingControl, propDesc);
         }

         // Change to desired value
         object oldValue = propDesc.GetValue(m_designingControl);
         propDesc.SetValue(m_designingControl, value);

         if (changeService != null)
         {
            // Raise event that the component has been changed
            this.changeService.OnComponentChanged(m_designingControl, propDesc, oldValue, value);
         }
      }
      #endregion

      #region Overrides

      protected override void WndProc(ref Message m)
      {
         if (m.HWnd == Control.Handle)
         {
            switch (m.Msg)
            {
               case 0x202: //WM_LBUTTONUP
                  CheckHeaderClick(new Point(LoWord((int)m.LParam), HiWord((int)m.LParam)));
                  break;
               default:
                  break;
            }
         }
         base.WndProc(ref m);
      }

      public override void Initialize(System.ComponentModel.IComponent component)
      {
         base.Initialize(component);
         if (component is NaviGroup)
         {
            m_designingControl = (NaviGroup)component;
         }
         InitializeServices();
      }
      #endregion

      #region Event Handling

      #endregion
   }
}
