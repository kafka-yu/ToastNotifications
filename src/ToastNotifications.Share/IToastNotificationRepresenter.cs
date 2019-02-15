using System.Collections.Generic;

namespace ToastNotifications.Share
{
    public interface IToastNotificationRepresenter
    {
        /// <summary>
        /// Gets current all keys.
        /// </summary>
        IEnumerable<string> NotificationKeys { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        void ShowTwoLines(TwoLinesToastNotificationInfo notification);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        void ShowIncomingCallNotification(IncomingCallNotificationInfo notification);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        void Dismiss(string tag);

        /// <summary>
        /// 
        /// </summary>
        void DismissAll();
    }
}
