using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using MS.WindowsAPICodePack.Internal;
using System;
using System.Diagnostics;
using System.IO;
using ToastNotifications.Win8.ShellHelpers;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace ToastNotifications.Win8
{
    /// <summary>
    /// 
    /// </summary>
    public class ToastNotificationCreator
    {
        private const String APP_ID = "Microsoft.Samples.DesktopToastsSample";

        #region Init

        // In order to display toasts, a desktop application must have a shortcut on the Start menu.
        // Also, an AppUserModelID must be set on that shortcut.
        // The shortcut should be created as part of the installer. The following code shows how to create
        // a shortcut and assign an AppUserModelID using Windows APIs. You must download and include the 
        // Windows API Code Pack for Microsoft .NET Framework for this code to function
        //
        // Included in this project is a wxs file that be used with the WiX toolkit
        // to make an installer that creates the necessary shortcut. One or the other should be used.
        private static bool TryCreateShortcut(string pszIconPath)
        {
            String shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\RingCentral for Outlook.lnk";
            if (!File.Exists(shortcutPath))
            {
                InstallShortcut(shortcutPath, pszIconPath);
                return true;
            }
            return false;
        }

        private static void InstallShortcut(String shortcutPath, string pszIconPath)
        {
            // Find the path to the current executable
            String exePath = Process.GetCurrentProcess().MainModule.FileName;
            IShellLinkW newShortcut = (IShellLinkW)new CShellLink();

            // Create a shortcut to the exe
            ShellHelpers.ErrorHelper.VerifySucceeded(newShortcut.SetIconLocation(pszIconPath, 0));
            ShellHelpers.ErrorHelper.VerifySucceeded(newShortcut.SetPath(exePath));
            ShellHelpers.ErrorHelper.VerifySucceeded(newShortcut.SetArguments(""));

            // Open the shortcut property store, set the AppUserModelId property
            IPropertyStore newShortcutProperties = (IPropertyStore)newShortcut;

            using (PropVariant appId = new PropVariant(APP_ID))
            {
                ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutProperties.SetValue(SystemProperties.System.AppUserModel.ID, appId));
                ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutProperties.Commit());
            }

            // Commit the shortcut to disk
            IPersistFile newShortcutSave = (IPersistFile)newShortcut;

            ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutSave.Save(shortcutPath, true));
        }

        #endregion

        public static void Setup(string appId, string appName, string iconPath)
        {
            TryCreateShortcut(iconPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        public static void ShowTwoLines(TwoLinesToastNotificationInfo notification)
        {
            // Get a toast XML template
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText02);

            // Fill in the text elements
            XmlNodeList stringElements = toastXml.GetElementsByTagName("text");

            stringElements[0].AppendChild(toastXml.CreateTextNode(notification.FirstLineText));
            stringElements[1].AppendChild(toastXml.CreateTextNode(notification.SecondLineText));

            // Specify the absolute path to an image
            String imagePath = "file:///" + Path.GetFullPath(notification.IconImagePath);
            XmlNodeList imageElements = toastXml.GetElementsByTagName("image");
            imageElements[0].Attributes.GetNamedItem("src").NodeValue = imagePath;

            // Create the toast and attach event listeners
            ToastNotification toast = new ToastNotification(toastXml);
            toast.Activated += (s, e) => notification.Activated?.Invoke(s, new EventArgs());
            toast.Dismissed += (s, e) => notification.Dismissed?.Invoke(s, new EventArgs());
            toast.Failed += (s, e) => notification.Failed?.Invoke(s, new EventArgs());

            // Show the toast. Be sure to specify the AppUserModelId on your application's shortcut!
            ToastNotificationManager.CreateToastNotifier(notification.AppId).Show(toast);
        }
    }
}
