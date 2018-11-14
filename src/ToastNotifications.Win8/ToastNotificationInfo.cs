using System;

namespace ToastNotifications.Win8
{
    /// <summary>
    /// 
    /// </summary>
    public class ToastNotificationInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string IconImagePath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AppId { get; set; }

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

        /// <summary>
        /// Occurs when an error is caused when Windows attempts to raise a toast notification.
        /// Apps that are running subscribe to this event.
        /// </summary>
        public EventHandler Failed;
    }

    /// <summary>
    /// 
    /// </summary>
    public class TwoLinesToastNotificationInfo : ToastNotificationInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string FirstLineText { get; set; }

        ///
        public string SecondLineText { get; set; }
    }
}
