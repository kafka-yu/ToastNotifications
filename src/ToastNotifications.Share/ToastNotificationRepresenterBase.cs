using System.Collections.Generic;
using System.Linq;

namespace ToastNotifications.Share
{
    public abstract class ToastNotificationRepresenterBase : IToastNotificationRepresenter
    {
        /// <summary>
        /// Gets current all keys.
        /// </summary>
        public abstract IEnumerable<string> NotificationKeys { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        public abstract void ShowTwoLines(TwoLinesToastNotificationInfo notification);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        public abstract void ShowIncomingCallNotification(IncomingCallNotificationInfo notification);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        public abstract void Dismiss(string tag);

        /// <summary>kn  
        /// 
        /// </summary>
        public void DismissAll()
        {
            foreach (var key in NotificationKeys.ToList())
            {
                this.Dismiss(key);
            }
        }
    }
}
