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

using System.Drawing;
using System.Windows.Forms;

namespace Guifreaks.NavigationBar
{
   public class NaviToolstripOffice07ColorTable : ProfessionalColorTable
   {
      /// <summary>
      /// Overriden. Gets the color of the border of an menu item
      /// </summary>
      public override Color MenuItemBorder
      {
         get { return Color.FromArgb(255, 189, 105); }
      }

      /// <summary>
      /// Overriden. Gets the color of selected menu item
      /// </summary>
      public override Color MenuItemSelected
      {
         get { return Color.FromArgb(255, 231, 162); }
      }

      /// <summary>
      /// Overriden. Gets the color of the image margin 
      /// </summary>
      public override Color ImageMarginGradientBegin
      {
         get { return Color.FromArgb(233, 238, 238); }
      }

      /// <summary>
      /// Overriden. Gets the color of the image margin
      /// </summary>
      public override Color ImageMarginGradientMiddle
      {
         get { return Color.FromArgb(233, 238, 238); }
      }

      /// <summary>
      /// Overriden. Gets the color of image margin
      /// </summary>
      public override Color ImageMarginGradientEnd
      {
         get { return Color.FromArgb(233, 238, 238); }
      }

      /// <summary>
      /// Overriden. Gets the background color of an menu item check
      /// </summary>
      public override Color CheckBackground
      {
         get { return Color.FromArgb(255, 189, 105); }
      }

      /// <summary>
      /// Overriden. Gets the background color of an pressed menu item check
      /// </summary>
      public override Color CheckPressedBackground
      {
         get { return Color.FromArgb(251, 140, 60); }
      }

      /// <summary>
      /// Overriden. Gets the background color of an selected menu item check
      /// </summary>
      public override Color CheckSelectedBackground
      {
         get { return Color.FromArgb(251, 140, 60); }
      }

      /// <summary>
      /// Overriden. Gets the color of the border of the item check
      /// </summary>
      public override Color ButtonSelectedBorder
      {
         get { return Color.FromArgb(255, 0, 0); }
      }      
   }
}