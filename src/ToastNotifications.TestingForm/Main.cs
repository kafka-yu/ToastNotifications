using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToastNotifications.Share;

namespace ToastNotifications.TestingForm
{
    public partial class Main : Form
    {
        private IToastNotificationRepresenter _toastNotificationRepresenter;

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

        private async void button2_Click(object sender, EventArgs e)
        {
            var appName = "RingCentral for Outlook";
            var appId = "com.ringcentral.rcoutlook";
            var appIco = @"C:\Program Files (x86)\RingCentralForOutlook\app.ico";
            var os = comboBox1.SelectedItem?.ToString();

            if (_toastNotificationRepresenter == null)
            {
                _toastNotificationRepresenter = GetNotifier(os);
            }

            var id = Guid.NewGuid().ToString();

            _toastNotificationRepresenter.DismissAll();
            _toastNotificationRepresenter.ShowIncomingCallNotification(new Share.IncomingCallNotificationInfo
            {
                DefaultAction = "action=answer&amp;callId=938163",
                BackgroundColor = "#464646",
                Tag = id,
                //Timeout = 7 * 1000,
                //AttributeText = "RingCentral for Outlook",
                ActionButtons = new Share.ActionButtons.ActionButton[] {
                     new Share.ActionButtons.ActionButton{
                          Content = "To voicemail",
                           IconUrl = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"reminder.png"),
                           Arguements = "action=tovoicemail",
                     },
                     new Share.ActionButtons.ActionButton{
                          Content = "Ignore",
                           IconUrl = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"cancel.png"),
                           Arguements = "sessionid=1234",
                     },
                     new Share.ActionButtons.ActionButton{
                          Content = "Answer",
                           IconUrl = @"C:\Program Files (x86)\RingCentralForOutlook\icons\telephone.png", },
                },
                Activated = (o, e1) =>
                {
                    //MessageBox.Show("Clicked, args: " + e1.Arguements ?? "N/A");
                },
                Dismissed = (o, e1) =>
               {
                   //MessageBox.Show("Clicked Dismissed");
               },
                FirstLineText = "Alice Zhang",
                AppName = appName,
                AppId = appId,
                IconImagePath = appIco,
                SecondLineText = "Incoming Call - SomethingNew1\r\n101",
            });

            await Task.Run(async () =>
            {
                await Task.Delay(5 * 1000);

                this.BeginInvoke(new Action(() =>
                {
                    _toastNotificationRepresenter.Dismiss(id);
                }));
            });
        }

        private IToastNotificationRepresenter GetNotifier(string os)
        {
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

            return toastNotificationRepresenter;
        }
    }
}
