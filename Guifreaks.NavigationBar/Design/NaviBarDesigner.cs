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
using System.Windows.Forms.Design;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Drawing;
using System;
using Guifreaks.Common;
using System.Collections;

namespace Guifreaks.NavigationBar.Design
{
   [ToolboxItemFilterAttribute("System.Windows.Forms", ToolboxItemFilterType.Custom)]
   internal class NaviBarDesigner : ParentControlDesigner
   {
      #region Fields

      NaviBar designingControl;
      ISelectionService selectionService;
      IComponentChangeService componentChangeService;
      IDesignerHost host;

      #endregion

      #region Constructor
      #endregion

      #region Properties
      #endregion

      #region Methods

      /// <summary>
      /// Sets the value for a given property
      /// </summary>
      /// <param name="propName">The name of the property</param>
      /// <param name="value">The new value of the property</param>
      private void SetValue(string propName, object value)
      {
         PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(designingControl);
         PropertyDescriptor property = properties.Find(propName, true);
         if (property != null)
         {
            property.SetValue(designingControl, value);
         }
      }

      /// <summary>
      /// Gets the value of a given property
      /// </summary>
      /// <param name="propName">The name of the property</param>
      private object GetValue(string propName)
      {
         PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(designingControl);
         PropertyDescriptor property = properties.Find(propName, true);
         if (property != null)
         {
            return property.GetValue(designingControl);
         }
         else
         {
            return null;
         }
      }

      /// <summary>
      /// Initializes the layout engine of the Navigation pane
      /// </summary>
      private void InitializeLayout()
      {
         if (designingControl.NaviLayout != null)
         {
            host.DestroyComponent(designingControl.NaviLayout);
         }

         switch (designingControl.LayoutStyle)
         {
            case NaviLayoutStyle.Office2003Blue:
            case NaviLayoutStyle.Office2007Silver:
            case NaviLayoutStyle.Office2007Black:
            case NaviLayoutStyle.Office2007Blue:
               break;
            default:
               throw new SystemException("Invalid value for property LayoutStyle");
         }
         designingControl.Invalidate();
      }

      private void InitializeServices()
      {
         selectionService = GetService(typeof(ISelectionService)) as ISelectionService;
         if (selectionService != null)
         {
            selectionService.SelectionChanged += new System.EventHandler(selectionService_SelectionChanged);
         }

         componentChangeService = GetService(typeof(IComponentChangeService))
            as IComponentChangeService;
         if (componentChangeService != null)
         {
            componentChangeService.ComponentChanged += new ComponentChangedEventHandler(componentChangeService_ComponentChanged);
         }

         host = (IDesignerHost)GetService(typeof(IDesignerHost));
      }

      private bool HandleClickEvent(int x, int y)
      {
         if (designingControl != null)
         {
            foreach (NaviBand band in designingControl.Bands)
            {
               if ((band.Button != null)
               && (band.Button.Bounds.Contains(x, y)))
               {
                  ArrayList list = new ArrayList();
                  list.Add(band);
                  if (selectionService != null)
                  {
                     selectionService.SetSelectedComponents(list);
                     return true;
                  }
               }
            }
         }
         return false;
      }

      #endregion

      #region Overrides

      public override void Initialize(IComponent component)
      {
         base.Initialize(component);
         designingControl = component as NaviBar;
         InitializeServices();
      }

      public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
      {
         designingControl.BeginInit();
         base.InitializeNewComponent(defaultValues);
         InitializeLayout();

         // For some reason ISupportInitialize.EndInit is never called when creating a control
         designingControl.EndInit();
      }

      public override DesignerVerbCollection Verbs
      {
         get
         {
            DesignerVerb[] verbs = new DesignerVerb[] { 
               new DesignerVerb("Add band..", 
                  new EventHandler(AddBandVerbClicked)) };
            return new DesignerVerbCollection(verbs);
         }
      }

      protected override void Dispose(bool disposing)
      {
         base.Dispose(disposing);

         if (componentChangeService != null)
         {
            componentChangeService.ComponentChanged -= new ComponentChangedEventHandler(componentChangeService_ComponentChanged);
         }

         if (selectionService != null)
         {
            selectionService.SelectionChanged -= new System.EventHandler(selectionService_SelectionChanged);
         }
      }

      protected override void WndProc(ref Message m)
      {
         switch (m.Msg)
         {
            case NativeMethods.WM_LBUTTONUP:
               if (!HandleClickEvent(NativeMethods.LoWord(m.LParam),
                  NativeMethods.HiWord(m.LParam)))
               {
                  base.WndProc(ref m);
               }
               break;
            default:
               base.WndProc(ref m);
               break;
         }
      }

      #endregion

      #region Event Handling

      void selectionService_SelectionChanged(object sender, System.EventArgs e)
      {
         if (selectionService.PrimarySelection is NaviBand)
         {
            designingControl.SetActiveBand(
               selectionService.PrimarySelection as NaviBand);
         }
      }

      void AddBandVerbClicked(object sender, EventArgs e)
      {
         NaviBand band = host.CreateComponent(typeof(NaviBand)) as NaviBand;
         if (band != null)
         {
            designingControl.AddBand(band);
         }
      }

      void componentChangeService_ComponentChanged(object sender, ComponentChangedEventArgs e)
      {
         if (e.Component == designingControl)
         {
            if ((e.Member != null)
            && (e.Member.Name == "LayoutStyle"))
            {
               InitializeLayout();
            }
         }
      }

      #endregion
   }
}