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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Guifreaks.NavigationBar
{
   public partial class NaviOptionsForm : Form
   {
      NaviBar bar;

      public NaviOptionsForm()
      {
         InitializeComponent();
      }

      public void Initialize(NaviBar bar)
      {
         this.bar = bar;
         checkedListBox1.Items.Clear();
         foreach (NaviBand band in bar.Bands)
         {
            checkedListBox1.Items.Add(band.Text, band.Visible);
         }
      }

      private void buttonOk_Click(object sender, EventArgs e)
      {
         // Set the new order
         for (int i = 0; i < bar.Bands.Count; i++)
         {
            int loc = checkedListBox1.Items.IndexOf(bar.Bands[i].Text);
            bar.Bands[i].Visible = checkedListBox1.CheckedItems.Contains(bar.Bands[i].Text);
            bar.Bands[i].Order = loc;
         }

         // And sort the list based on the new order
         bar.Bands.Sort(new NaviBandOrderComparer());
      }

      private void buttonMoveUp_Click(object sender, EventArgs e)
      {
         if (checkedListBox1.SelectedIndex != 0)
         {
            object oldItem = checkedListBox1.Items[checkedListBox1.SelectedIndex - 1];
            checkedListBox1.Items[checkedListBox1.SelectedIndex - 1] =
               checkedListBox1.SelectedItem;
            checkedListBox1.Items[checkedListBox1.SelectedIndex] = oldItem;
            checkedListBox1.SelectedIndex -= 1;
         }
      }

      private void buttonMoveDown_Click(object sender, EventArgs e)
      {
         if (checkedListBox1.SelectedIndex < checkedListBox1.Items.Count - 1)
         {
            object oldItem = checkedListBox1.Items[checkedListBox1.SelectedIndex + 1];
            checkedListBox1.Items[checkedListBox1.SelectedIndex + 1] =
               checkedListBox1.SelectedItem;
            checkedListBox1.Items[checkedListBox1.SelectedIndex] = oldItem;
            checkedListBox1.SelectedIndex += 1;
         }
      }

      private void buttonReset_Click(object sender, EventArgs e)
      {
         // Sort list based on original order
         bar.Bands.Sort(new NaviBandOrgOrderComparer());
         Initialize(bar);
      }

      private void buttonCancel_Click(object sender, EventArgs e)
      {
         // Reset ordering posibly caused by reset button
         bar.Bands.Sort(new NaviBandOrderComparer());
      }
   }
}
