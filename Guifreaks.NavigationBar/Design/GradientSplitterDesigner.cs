using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace Guifreaks.NavigationBar.Design
{
   internal class GradientSplitterDesigner
      : ControlDesigner
   {
      #region Fields

      GradientSplitter m_designingControl;
      IComponentChangeService changeService = null;

      #endregion

      #region Constructor
      #endregion

      #region Properties

      #endregion

      #region Methods

      private void InitializeServices()
      {
         if (changeService == null)
         {
            this.changeService =
               GetService(typeof(IComponentChangeService)) as IComponentChangeService;
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

      public override void Initialize(IComponent component)
      {
         base.Initialize(component);
         m_designingControl = Component as GradientSplitter;
      }

      public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
      {
         base.InitializeNewComponent(defaultValues);
         m_designingControl = Component as GradientSplitter;
         SetControlProperty("Dock", DockStyle.Bottom);
      }

      #endregion

      #region Event Handling
      #endregion
   }
}
