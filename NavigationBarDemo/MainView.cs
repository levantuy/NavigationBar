using System.Windows.Forms;
using System;
using Guifreaks.NavigationBar;
using System.Xml;
using Microsoft.Xml.Serialization.GeneratedAssembly;
using System.IO;

namespace NavigationBarDemo
{
   public partial class MainView : Form
   {
      public MainView()
      {
         InitializeComponent();

         checkBoxActivated.DataBindings.Add(new Binding("Checked", naviButton1, "Active",
            true, DataSourceUpdateMode.OnPropertyChanged));
         checkBoxMinimized.DataBindings.Add(new Binding("Checked", naviButton1, "Collapsed",
            true, DataSourceUpdateMode.OnPropertyChanged));
         checkBoxShowImage.DataBindings.Add(new Binding("Checked", naviButton1, "ShowImage",
            true, DataSourceUpdateMode.OnPropertyChanged));
         checkBox1.DataBindings.Add(new Binding("Checked", naviBand1, "Visible",
            true, DataSourceUpdateMode.OnPropertyChanged));
         textBoxButtonHeight.DataBindings.Add(new Binding("Text", naviBar1,
            "ButtonHeight", true, DataSourceUpdateMode.OnPropertyChanged));
         textBoxHeaderHeight.DataBindings.Add(new Binding("Text", naviBar1,
            "HeaderHeight", true, DataSourceUpdateMode.OnPropertyChanged));
         textBoxVisibleButtons.DataBindings.Add(new Binding("Text", naviBar1,
            "VisibleLargeButtons", true, DataSourceUpdateMode.OnValidation));
         textBoxSmallButtonsHeight.DataBindings.Add(new Binding("Text", naviBar1,
            "MinimizedPanelHeight", true, DataSourceUpdateMode.OnValidation));
         checkBoxMoreOptions.DataBindings.Add(new Binding("Checked", naviBar1, "ShowMoreOptionsButton",
            true, DataSourceUpdateMode.OnPropertyChanged));
         checkBoxCollapsed.DataBindings.Add(new Binding("Checked", naviBar1, "Collapsed",
            true, DataSourceUpdateMode.OnPropertyChanged));
         checkBoxShowCollapseButton.DataBindings.Add(new Binding("Checked", naviBar1,
            "ShowCollapseButton", true, DataSourceUpdateMode.OnPropertyChanged));
         checkBoxGroupExpanded.DataBindings.Add(new Binding("Checked", naviGroup3,
            "Expanded", true, DataSourceUpdateMode.OnPropertyChanged));
      }

      private void naviButton1_Activated(object sender, System.EventArgs e)
      {
         textBox1.AppendText("Activated" + Environment.NewLine);
      }

      private void naviButton1_Click(object sender, System.EventArgs e)
      {
         textBox1.AppendText("Click" + Environment.NewLine);
      }

      private void naviBar1_BandAdded(object sender, ControlEventArgs e)
      {
         textBoxBarLog.AppendText("BandAdded" + Environment.NewLine);
      }

      private void naviBar1_ActiveBandChanging(object sender, NaviBandEventArgs e)
      {
         textBoxBarLog.AppendText("BandChanging" + Environment.NewLine);
         if (e.NewActiveBand == naviBand2)
         {
            if (MessageBox.Show("Do you want to change to Band 2?", "Confirm",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
               e.Canceled = true;
            }
         }
      }

      private void naviBar1_ActiveBandChanged(object sender, EventArgs e)
      {
         textBoxBarLog.AppendText("BandChanged" + Environment.NewLine);
      }

      private void button1_Click(object sender, EventArgs e)
      {
         if (naviBar1.NaviLayout is NaviLayoutOff)
         {
            naviBar1.VisibleLargeButtons++;
         }
      }

      private void button2_Click(object sender, EventArgs e)
      {
         if (naviBar1.NaviLayout is NaviLayoutOff)
         {
            naviBar1.VisibleLargeButtons--;
         }
      }

      private void checkBoxRightToLeft_CheckedChanged(object sender, EventArgs e)
      {
         if (checkBoxRightToLeft.Checked)
            RightToLeft = RightToLeft.Yes;
         else
            RightToLeft = RightToLeft.No;
      }

      private void ComboBoxLayoutBar_SelectedIndexChanged(object sender, EventArgs e)
      {
         switch (ComboBoxLayoutBar.SelectedItem.ToString())
         {
            case "Office 2003 Blue":
               naviBar1.LayoutStyle = NaviLayoutStyle.Office2003Blue;
               break;
            case "Office 2003 Green":
               naviBar1.LayoutStyle = NaviLayoutStyle.Office2003Green;
               break;
            case "Office 2003 Silver":
               naviBar1.LayoutStyle = NaviLayoutStyle.Office2003Silver;
               break;
            case "Office 2007 Blue":
               naviBar1.LayoutStyle = NaviLayoutStyle.Office2007Blue;
               break;
            case "Office 2007 Black":
               naviBar1.LayoutStyle = NaviLayoutStyle.Office2007Black;
               break;
            case "Office 2007 Silver":
               naviBar1.LayoutStyle = NaviLayoutStyle.Office2007Silver;
               break;
            case "Office 2010":
               break;
            case "Office Guifreaks":
               break;
         }
      }

      private void ButtonActivateBand_Click(object sender, EventArgs e)
      {
         naviBar1.ActiveBand = naviBar1.Bands[0];
      }

      private void ButtonAddBand_Click(object sender, EventArgs e)
      {
         NaviBand band = new NaviBand();

         band.Text = "NaviBand" + (naviBar1.Bands.Count + 1).ToString();
         band.SmallImage = Properties.Resources.bookmark1;
         band.LargeImage = Properties.Resources.bookmark;

         naviBar1.Bands.Add(band);
      }

      private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
      {

      }

      private void buttonSaveSettings_Click(object sender, EventArgs e)
      {
         if (saveFileDialogSettings.ShowDialog() == DialogResult.OK)
         {
            try
            {
               string fileName = saveFileDialogSettings.FileName;
               NaviBarSettingsSerializer serial = new NaviBarSettingsSerializer();
               using (TextWriter w = new StreamWriter(fileName))
               {
                  serial.Serialize(w, naviBar1.Settings);
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
         }
      }

      private void buttonLoadSettings_Click(object sender, EventArgs e)
      {
         if (openFileDialogSettings.ShowDialog() == DialogResult.OK)
         {
            try
            {
               string fileName = openFileDialogSettings.FileName;
               NaviBarSettingsSerializer serial = new NaviBarSettingsSerializer();
               using (StreamReader reader = new StreamReader(fileName))
               {
                  NaviBarSettings settings = serial.Deserialize(reader) as NaviBarSettings;
                  if (settings != null)
                  {
                     naviBar1.Settings = settings;
                     naviBar1.ApplySettings();
                  }
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
         }
      }
   }
}
