using System;

namespace ToastNotifications.Share
{
    /// <summary>
    /// 
    /// </summary>
    public class ToastNotificationInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// The Icon Image file path
        /// </summary>
        public string IconImagePath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// Only supported in Win7
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Occurs when user activates a toast notification through a click or touch. Apps
        ///     that are running subscribe to this event.
        /// </summary>
        public EventHandler<ToastActivatedEventArgs> Activated;

        /// <summary>  
        ///     Occurs when a toast notification leaves the screen, either by expiring or being
        ///    explicitly dismissed by the user. Apps that are running subscribe to this event.
        /// </summary>
        public EventHandler<ToastDismissedEventArgs> Dismissed;

        /// <summary>
        /// Occurs when an error is caused when Windows attempts to raise a toast notification.
        /// Apps that are running subscribe to this event.
        /// </summary>
        public EventHandler<ToastFailedEventArgs> Failed;
    }
}
