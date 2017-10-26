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
using System.Windows.Forms;

namespace Guifreaks.NavigationBar
{
   [ToolboxItem(false)]
   public partial class NaviBandClientArea : ContainerControl
   {
      #region Fields

      NaviBandRenderer renderer;

      #endregion 

      /// <summary>
      /// Initializes a new instance of the NaviBandClientArea
      /// </summary>
      public NaviBandClientArea()
      {
         InitializeComponent();
         Initialize();
      }

      /// <summary>
      /// Initializes a new instance of the NaviBandClientArea
      /// </summary>
      public NaviBandClientArea(IContainer container)
      {
         container.Add(this);
         InitializeComponent();
         Initialize();
      }

      #region Methods

      /// <summary>
      /// Initializes the control for the first time. 
      /// </summary>
      private void Initialize()
      {
         SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
         SetStyle(ControlStyles.UserPaint, true);
         SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         SetStyle(ControlStyles.ResizeRedraw, true);

         renderer = new NaviBandRendererOff7();
      }

      #endregion

      #region Overrides

      /// <summary>
      /// Overriden. Raises the Paint event
      /// </summary>
      /// <param name="e">Additional paint info</param>
      protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);
         renderer.DrawBackground(e.Graphics, ClientRectangle);
      }

      #endregion
   }
}
