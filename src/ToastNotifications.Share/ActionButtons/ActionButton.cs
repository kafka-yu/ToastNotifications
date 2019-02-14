namespace ToastNotifications.Share.ActionButtons
{
    public class ActionButton
    {
        private string _Content;

        public string Content
        {
            get { return _Content ?? string.Empty; }
            set { _Content = value; }
        }

        private string _IconUrl;

        public string IconUrl
        {
            get { return _IconUrl ?? string.Empty; }
            set { _IconUrl = value; }
        }

        private string _Arguements;

        public string Arguements
        {
            get { return _Arguements ?? string.Empty; }
            set { _Arguements = value; }
        }

        public ActivationType ActivationType { get; set; }
    }
}
