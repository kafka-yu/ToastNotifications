namespace ToastNotifications.Share
{
    public class TwoLinesToastNotificationInfo : ToastNotificationInfo
    {
        /// <summary>
        /// First line text
        /// </summary>
        public string FirstLineText { get; set; }

        /// <summary>
        /// Second line text
        /// </summary>
        public string SecondLineText { get; set; }

        /// <summary>
        /// /
        /// </summary>
        public bool ShowLeftSideImage { get; set; }
    }
}
