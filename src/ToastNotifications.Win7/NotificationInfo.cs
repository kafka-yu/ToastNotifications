using System;
using System.Drawing;
using static ToastNotifications.Win7.FormAnimator;

namespace ToastNotifications.Win7
{
    /// <summary>
    /// 
    /// </summary>
    public class NotificationInfo
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
        /// The Application Name shown in the notification.
        /// </summary>
        public string AppName { get; set; }

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
        /// Default is: #123667
        /// </summary>
        public string BackgroundColor { get; set; } = "#123667";

        /// <summary>
        /// Default is: 200
        /// </summary>
        public int AnimationDuration { get; set; } = 200;

        /// <summary>
        /// 
        /// </summary>
        public Image Icon { get; set; }

        /// <summary>
        /// Occurs when user activates a toast notification through a click or touch. Apps
        ///     that are running subscribe to this event.
        /// </summary>
        public EventHandler Activated;

        /// <summary>  
        ///     Occurs when a toast notification leaves the screen, either by expiring or being
        ///    explicitly dismissed by the user. Apps that are running subscribe to this event.
        /// </summary>
        public EventHandler Dismissed;
    }
}
