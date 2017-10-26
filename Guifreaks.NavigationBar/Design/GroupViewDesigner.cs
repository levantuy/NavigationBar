﻿using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Guifreaks.NavigationBar.Design
{
   internal class GroupViewDesigner : ParentControlDesigner
   {
      #region Fields

      IComponentChangeService changeService = null;
      ISelectionService selectionService = null;
      GroupView m_designingControl;

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
         if (component is GroupView)
         {
            m_designingControl = (GroupView)component;
         }
         InitializeServices();
      }
      #endregion

      #region Event Handling

      #endregion
   }
}
