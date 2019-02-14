using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToastNotifications.TestingForm
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var os = comboBox1.SelectedItem?.ToString();

            var appName = "RingCentral for Outlook";
            var appId = "com.ringcentral.rcoutlook";
            var appIco = @"C:\Program Files (x86)\RingCentralForOutlook\app.ico";
            ToastNotifications.Share.IToastNotificationRepresenter toastNotificationRepresenter = null;
            switch (os)
            {
                case "Win7":
                    toastNotificationRepresenter = new Win7.ToastNotificationRepresenter(appName);
                    break;
                default:
                case "Win8":
                    toastNotificationRepresenter = new Win8.ToastNotificationRepresenter(appId, appName, appIco);
                    break;
                case "Win10":
                    toastNotificationRepresenter = new Win10.ToastNotificationRepresenter(appId, appName, appIco);
                    break;
            }

            toastNotificationRepresenter.ShowTwoLines(new Share.TwoLinesToastNotificationInfo
            {
                BackgroundColor = "#464646",
                Tag = Guid.NewGuid().ToString(),
                Activated = (o, e1) => { },
                FirstLineText = "Incoming Call: SomethingNew1\r\n101",
                SecondLineText = string.Empty,
                AppId = appId,
                AppName = appName,
                IconImagePath = appIco,
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var os = comboBox1.SelectedItem?.ToString();

            var appName = "RingCentral for Outlook";
            var appId = "com.ringcentral.rcoutlook";
            var appIco = @"C:\Program Files (x86)\RingCentralForOutlook\app.ico";
            Share.IToastNotificationRepresenter toastNotificationRepresenter = null;
            switch (os)
            {
                case "Win7":
                    toastNotificationRepresenter = new Win7.ToastNotificationRepresenter(appName);
                    break;
                default:
                case "Win8":
                    toastNotificationRepresenter = new Win8.ToastNotificationRepresenter(appId, appName, appIco);
                    break;
                case "Win10":
                    toastNotificationRepresenter = new Win10.ToastNotificationRepresenter(appId, appName, appIco);
                    break;
            }

            toastNotificationRepresenter.ShowRichInterableNotification(new Share.TwoLinesToastNotificationInfo
            {
                BackgroundColor = "#464646",
                Tag = Guid.NewGuid().ToString(),
                Activated = (o, e1) =>
                {
                    MessageBox.Show("Clicked, args: " + e1.Arguements ?? "N/A");
                },
                Dismissed = (o, e1) =>
               {
                   MessageBox.Show("Clicked Dismissed");
               },
                FirstLineText = appName,
                AppName = appName,
                AppId = appId,
                IconImagePath = appIco,
                SecondLineText = "Incoming Call - SomethingNew1\r\n101",
            });
        }
    }
}
