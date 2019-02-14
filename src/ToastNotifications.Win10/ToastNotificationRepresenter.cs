using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using MS.WindowsAPICodePack.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ToastNotifications.Share;
#if WIN8
using ToastNotifications.Win8.ShellHelpers;
#endif
#if WIN10
using ToastNotifications.Win10.ShellHelpers;
#endif

using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

#if WIN8
namespace ToastNotifications.Win8
#endif
#if WIN10
namespace ToastNotifications.Win10
#endif

{
    /// <summary>
    /// 
    /// </summary>
    public class ToastNotificationRepresenter : IToastNotificationRepresenter
    {
        private readonly string _appId;

        private Dictionary<string, ToastNotification> _notifications = new Dictionary<string, ToastNotification>();

        public ToastNotificationRepresenter(string appId, string appName, string defaultIconFilePath)
        {
            Setup(appId, appName, defaultIconFilePath);
            _appId = appId;
        }

        #region Init

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="shortcutPath"></param>
        /// <param name="pszIconPath"></param>
        private void InstallShortcut(string appId, string shortcutPath, string pszIconPath)
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

            using (PropVariant appIdPv = new PropVariant(appId))
            {
                ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutProperties.SetValue(SystemProperties.System.AppUserModel.ID, appIdPv));
                ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutProperties.Commit());
            }

            // Commit the shortcut to disk
            IPersistFile newShortcutSave = (IPersistFile)newShortcut;

            ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutSave.Save(shortcutPath, true));
        }

        // In order to display toasts, a desktop application must have a shortcut on the Start menu.
        // Also, an AppUserModelID must be set on that shortcut.
        // The shortcut should be created as part of the installer. The following code shows how to create
        // a shortcut and assign an AppUserModelID using Windows APIs. You must download and include the 
        // Windows API Code Pack for Microsoft .NET Framework for this code to function
        //
        // Included in this project is a wxs file that be used with the WiX toolkit
        // to make an installer that creates the necessary shortcut. One or the other should be used.
        public bool Setup(string appId, string appName, string defaultIconFilePath)
        {
            string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $"\\Microsoft\\Windows\\Start Menu\\Programs\\{appName}.lnk";
            if (!File.Exists(shortcutPath))
            {
                InstallShortcut(appId, shortcutPath, defaultIconFilePath);
                return true;
            }
            return false;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        public void ShowTwoLines(TwoLinesToastNotificationInfo notification)
        {
            // Get a toast XML template
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText02);

            // Fill in the text elements
            XmlNodeList stringElements = toastXml.GetElementsByTagName("text");

            stringElements[0].AppendChild(toastXml.CreateTextNode(notification.FirstLineText));
            stringElements[1].AppendChild(toastXml.CreateTextNode(notification.SecondLineText ?? string.Empty));

            // Specify the absolute path to an image
            String imagePath = "file:///" + Path.GetFullPath(notification.IconImagePath);
            XmlNodeList imageElements = toastXml.GetElementsByTagName("image");
            imageElements[0].Attributes.GetNamedItem("src").NodeValue = imagePath;

            // Create the toast and attach event listeners
            Display(notification, toastXml);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        public void ShowRichInterableNotification(TwoLinesToastNotificationInfo notification)
        {
            var toastContent = new XmlDocument();

            toastContent.LoadXml($@"<toast launch=""action=answer&amp;callId=938163"" scenario=""incomingCall"">

  <visual>
    <binding template=""ToastGeneric"">
      <text>{notification.FirstLineText}</text>
      <text>{notification.SecondLineText}</text>
      <image hint-crop=""circle"" src=""https://unsplash.it/100?image=883""/>
    </binding>
  </visual>

  <actions>

    <action
      content=""Text reply""
      imageUri=""file:///C:/Projects/RukaiYu/ToastNotifications/src/ToastNotifications.TestingForm/bin/Debug/message.png""
      activationType=""foreground""
      arguments=""action=textReply&amp;callId=938163""/>

    <action
      content=""Reminder""
      imageUri=""file:///C:/Projects/RukaiYu/ToastNotifications/src/ToastNotifications.TestingForm/bin/Debug/reminder.png""
      activationType=""background""
      arguments=""action=reminder&amp;callId=938163""/>

    <action
      content=""Ignore""
      imageUri=""file:///C:/Projects/RukaiYu/ToastNotifications/src/ToastNotifications.TestingForm/bin/Debug/cancel.png""
      activationType=""background""
      arguments=""action=ignore&amp;callId=938163""/>

    <action
      content=""Answer""
      imageUri=""file:///C:/Projects/RukaiYu/ToastNotifications/src/ToastNotifications.TestingForm/bin/Debug/telephone.png""
      arguments=""action=answer&amp;callId=938163""/>

  </actions>

</toast>");

            // Create the toast notification
            Display(notification, toastContent);
        }

        private void Display(ToastNotificationInfo notification, XmlDocument toastContent)
        {
            var toastNotif = new ToastNotification(toastContent);

#if WIN10
            toastNotif.Tag = notification.Tag;
#endif

            toastNotif.Activated += (o, e) => notification.Activated?.Invoke(o, new Share.ToastActivatedEventArgs
            {
                Arguements = (e as Windows.UI.Notifications.ToastActivatedEventArgs)?.Arguments,
                Tag = notification.Tag,
            });

            toastNotif.Dismissed += (o, e) => notification.Dismissed?.Invoke(o, new Share.ToastDismissedEventArgs
            {
                Reason = ConvertReason(e.Reason),
            });

            toastNotif.Failed += (o, e) => notification.Failed?.Invoke(this, new Share.ToastFailedEventArgs() { ErrorCode = e.ErrorCode });

            if (!string.IsNullOrWhiteSpace(notification.Tag))
            {
                _notifications[notification.Tag] = toastNotif;
            }

            // And send the notification
            ToastNotificationManager.CreateToastNotifier(notification.AppId).Show(toastNotif);
        }

        private Share.ToastDismissalReason ConvertReason(Windows.UI.Notifications.ToastDismissalReason reason)
        {
            switch (reason)
            {
                case Windows.UI.Notifications.ToastDismissalReason.UserCanceled:
                    return Share.ToastDismissalReason.UserCanceled;
                case Windows.UI.Notifications.ToastDismissalReason.ApplicationHidden:
                    return Share.ToastDismissalReason.ApplicationHidden;
                case Windows.UI.Notifications.ToastDismissalReason.TimedOut:
                    return Share.ToastDismissalReason.TimedOut;
                default:
                    return Share.ToastDismissalReason.Other;
            }
        }

        public void Dismiss(string tag)
        {
            if (tag != null && _notifications.ContainsKey(tag))
            {
                ToastNotificationManager.CreateToastNotifier(_appId).Hide(_notifications[tag]);

                _notifications.Remove(tag);
            }
        }
    }
}
