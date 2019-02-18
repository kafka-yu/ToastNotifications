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

        private string _Arguments;

        public string Arguments
        {
            get { return _Arguments ?? string.Empty; }
            set { _Arguments = value; }
        }

        public ActivationType ActivationType { get; set; }
    }
}
