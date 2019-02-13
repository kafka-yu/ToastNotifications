using System.Drawing;
using ToastNotifications.Share;
using static ToastNotifications.Win7.FormAnimator;

namespace ToastNotifications.Win7
{
    /// <summary>
    /// 
    /// </summary>
    public class NotificationInfo : ToastNotificationInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets a time, in milliseconds, that indicates how long will the notification block keep showing. Default is 0.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AnimationMethod Animation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AnimationDirection Direction { get; set; }

        /// <summary>
        /// Default is: 200
        /// </summary>
        public int AnimationDuration { get; set; } = 200;

        /// <summary>
        /// 
        /// </summary>
        public Image Icon { get; set; }

        public NotificationInfo()
        {
            BackgroundColor = "#123667";
        }
    }
}
