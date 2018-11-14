// =====COPYRIGHT=====
// Code originally retrieved from http://www.vbforums.com/showthread.php?t=547778 - no license information supplied
// =====COPYRIGHT=====
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ToastNotifications.Win7
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Notification : Form
    {
        private static readonly List<Notification> OpenNotifications = new List<Notification>();
        private bool _allowFocus;
        private readonly FormAnimator _animator;
        private IntPtr _currentForegroundWindow;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        public Notification(NotificationInfo notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            InitializeComponent();

            var duration = notification.Duration;

            if (duration <= 0)
                duration = int.MaxValue;

            lifeTimer.Tag = notification;
            lifeTimer.Interval = duration;
            labelTitle.Text = notification.Title;
            labelBody.Text = notification.Body;

            var hasBody = true;
            if (string.IsNullOrWhiteSpace(notification.Body))
            {
                hasBody = false;
                labelBody.Visible = false;
            }

            this.labelAppName.Text = notification.AppName;
            this.BackColor = ColorTranslator.FromHtml(notification.BackgroundColor);
            this.TopMost = true;

            _animator = new FormAnimator(this, notification.Animation, notification.Direction, notification.AnimationDuration);

            SizeF measuredSize = TextRenderer.MeasureText(notification.Title, this.labelTitle.Font, this.labelTitle.Size);

            var height = 21;
            if (measuredSize.Width > this.labelTitle.Width)
            {
                this.labelTitle.Location = new Point(this.labelTitle.Location.X, this.labelTitle.Location.Y - 2);
                this.labelTitle.Height = (int)(this.labelTitle.Height * 2);

                this.Height = this.Height + 18;
                if (hasBody)
                {
                    this.labelBody.Location = new Point(this.labelBody.Location.X, this.labelBody.Location.Y + height);
                    this.labelAppName.Location = new Point(this.labelAppName.Location.X, this.labelAppName.Location.Y + height);
                }
                else
                {
                    this.labelAppName.Location = new Point(this.labelAppName.Location.X, this.labelAppName.Location.Y + 3);
                }

            }
            else
            {
                if (!hasBody)
                {
                    this.labelTitle.Location = new Point(this.labelTitle.Location.X, this.labelTitle.Location.Y + 3);
                    this.labelAppName.Location = new Point(this.labelAppName.Location.X, this.labelAppName.Location.Y - 8);
                }
            }

            if (notification.Icon != null)
            {
                this.appIcon.Image = notification.Icon;
            }

            Region = Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width - 10, Height - 10, 0, 0));

            _closeActiveIcon = ((System.Drawing.Image)(resources.GetObject("closeButtonBox.InitialImage")));
            _closeIcon = ((System.Drawing.Image)(resources.GetObject("closeButtonBox.Image")));

        }

        #region Methods

        /// <summary>
        /// Displays the form
        /// </summary>
        /// <remarks>
        /// Required to allow the form to determine the current foreground window before being displayed
        /// </remarks>
        public new void Show()
        {
            // Determine the current foreground window so it can be reactivated each time this form tries to get the focus
            _currentForegroundWindow = NativeMethods.GetForegroundWindow();

            base.Show();
        }

        #endregion // Methods

        #region Event Handlers

        private void Notification_Load(object sender, EventArgs e)
        {
            // Display the form just above the system tray.
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width,
                                      Screen.PrimaryScreen.WorkingArea.Height - Height);

            // Move each open form upwards to make room for this one
            foreach (Notification openForm in OpenNotifications)
            {
                openForm.Top -= Height;
            }

            OpenNotifications.Add(this);
            lifeTimer.Start();
        }

        private void Notification_Activated(object sender, EventArgs e)
        {
            // Prevent the form taking focus when it is initially shown
            if (!_allowFocus)
            {
                // Activate the window that previously had focus
                NativeMethods.SetForegroundWindow(_currentForegroundWindow);
            }
        }

        private void Notification_Shown(object sender, EventArgs e)
        {
            // Once the animation has completed the form can receive focus
            _allowFocus = true;

            // Close the form by sliding down.
            _animator.Duration = 0;
            _animator.Direction = FormAnimator.AnimationDirection.Down;
        }

        private void Notification_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Move down any open forms above this one
            foreach (Notification openForm in OpenNotifications)
            {
                if (openForm == this)
                {
                    // Remaining forms are below this one
                    break;
                }
                openForm.Top += Height;
            }

            OpenNotifications.Remove(this);
        }

        private void lifeTimer_Tick(object sender, EventArgs e)
        {
            NotifyNotificationClosed(NotificationResponse.Dismissed);
            Close();
        }


        private void Notification_Click(object sender, EventArgs e)
        {
            NotifyNotificationClosed(NotificationResponse.Actived);
            Close();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelRO_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NotifyNotificationClosed(NotificationResponse response = NotificationResponse.Dismissed)
        {
            var sender = this;
            var notification = this.lifeTimer.Tag as NotificationInfo;
            if (notification != null)
            {
                switch (response)
                {
                    case NotificationResponse.Dismissed:
                        notification.Dismissed?.Invoke(sender, new EventArgs());
                        break;
                    case NotificationResponse.Expired:
                        notification.Dismissed?.Invoke(sender, new EventArgs());
                        break;
                    case NotificationResponse.Actived:
                        notification.Activated?.Invoke(sender, new EventArgs());
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion // Event Handlers

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notification));
        private Image _closeActiveIcon;
        private Image _closeIcon;

        private void closeButtonBox_Click(object sender, EventArgs e)
        {
            NotifyNotificationClosed();
            Close();
        }


        private void closeButtonBox_MouseHover(object sender, EventArgs e)
        {
            closeButtonBox.Image = _closeActiveIcon;
        }

        private void closeButtonBox_MouseLeave(object sender, EventArgs e)
        {
            closeButtonBox.Image = _closeIcon;
        }
    }
}