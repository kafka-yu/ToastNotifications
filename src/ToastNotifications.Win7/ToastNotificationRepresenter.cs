using System;
using System.Collections.Generic;
using ToastNotifications.Share;

namespace ToastNotifications.Win7
{
    public class ToastNotificationRepresenter : IToastNotificationRepresenter
    {
        private readonly string _appName;

        private Dictionary<string, Notification> _notifications = new Dictionary<string, Notification>();

        public ToastNotificationRepresenter(string appName)
        {
            _appName = appName;
        }

        public void Dismiss(string tag)
        {
            Notification ntf = null;
            if (_notifications.TryGetValue(tag, out ntf))
            {
                if (!ntf.IsDisposed && !ntf.Disposing)
                {
                    ntf.Close();
                    _notifications.Remove(tag);
                }
            }
        }

        public void ShowIncomingCallNotification(IncomingCallNotificationInfo notification)
        {
            throw new NotImplementedException("Not Supported In Win7");
        }

        public void ShowTwoLines(TwoLinesToastNotificationInfo notification)
        {
            Notification ntf = new Notification(
                       new NotificationInfo()
                       {
                           Title = notification.FirstLineText,
                           Body = notification.SecondLineText,
                           AppName = _appName,
                           Duration = notification.Duration,
                           Animation = FormAnimator.AnimationMethod.Fade,
                           Direction = FormAnimator.AnimationDirection.Left,
                           BackgroundColor = notification.BackgroundColor,
                           Activated = notification.Activated,
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
    }
}
