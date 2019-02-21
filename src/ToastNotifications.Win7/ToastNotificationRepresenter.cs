using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ToastNotifications.Share;

namespace ToastNotifications.Win7
{
    /// <summary>
    /// An implementation of <see cref="IToastNotificationRepresenter"/>, to provide a customized win8-style notification.
    /// </summary>
    public class ToastNotificationRepresenter : ToastNotificationRepresenterBase
    {
        private readonly string _appName;

        private Dictionary<string, Notification> _notifications = new Dictionary<string, Notification>();

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<string> NotificationKeys => _notifications.Keys;

        public ToastNotificationRepresenter(string appName)
        {
            _appName = appName;
        }

        public override void Dismiss(string tag)
        {
            Notification ntf = null;
            if (_notifications.TryGetValue(tag, out ntf))
            {
                try
                {
                    if (!ntf.IsDisposed && !ntf.Disposing)
                    {
                        ntf.Close();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _notifications.Remove(tag);
                }
            }
        }

        public override void ShowIncomingCallNotification(IncomingCallNotificationInfo notification)
        {
            throw new NotImplementedException("Not Supported In Win7");
        }

        public override void ShowTwoLines(TwoLinesToastNotificationInfo notification)
        {
            Notification ntf = new Notification(
                       new NotificationInfo()
                       {
                           Title = notification.FirstLineText,
                           Body = notification.SecondLineText,
                           AppName = _appName,
                           Duration = notification.Duration,
                           DefaultAction = notification.DefaultAction,
                           Animation = FormAnimator.AnimationMethod.Fade,
                           Direction = FormAnimator.AnimationDirection.Left,
                           BackgroundColor = notification.BackgroundColor,
                           Activated = notification.Activated,
                           Icon = GetIconImage(notification.IconImagePath),
                           Dismissed = notification.Dismissed,
                       }
                   );

            _notifications[notification.Tag] = ntf;

            ntf.FormClosed += (o, e) =>
            {
                _notifications.Remove(notification.Tag);
            };

            ntf.Show();
        }

        private Image GetIconImage(string iconImagePath)
        {
            if (!string.IsNullOrWhiteSpace(iconImagePath) && File.Exists(iconImagePath))
            {
                return Image.FromFile(iconImagePath);
            }

            return null;
        }
    }
}
