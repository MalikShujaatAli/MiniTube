using MiniTube.ModelsEAD;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System;
using System.Collections.Generic;
using Azure;
using Azure.Communication.Email;
using System.Net.Mail;
using System.Net;



namespace MiniTube.View
{
    public partial class RegisterationViewIn : Window
    {
        private string? person;
        private DispatcherTimer? _timer;
        private int _countdown;
        int otp = 0;

        // ----- Constructor -----
        public RegisterationViewIn()
        {
            InitializeComponent();
        }

        public RegisterationViewIn(string s)
        {
            InitializeComponent();
            person = s;
        }

        // ----- Mouse Down Event for Dragging the Window -----
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        // ----- Minimize Button Click -----
        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // ----- Close Button Click -----
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // ----- Key Down Event for Text Boxes -----
        private void txt_username_KeyDown(object sender, KeyEventArgs e) => HandleEnterKey(e);
        private void txt_password_KeyDown(object sender, KeyEventArgs e) => HandleEnterKey(e);
        private void txt_confirm_password_KeyDown(object sender, KeyEventArgs e) => HandleEnterKey(e);
        private void txt_email_KeyDown(object sender, KeyEventArgs e) => HandleEnterKey(e);

        // ----- Handle Enter Key Press -----
        private void HandleEnterKey(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_register_Click(this, new RoutedEventArgs());
            }
        }

        // ----- Back Button Click -----
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RegisterationView registerationView = new RegisterationView();
                registerationView.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating back: {ex.Message}");
            }
        }

        // ----- Email Validity Check -----
        static bool EmailValidity(string mailAddress)
        {
            return Regex.IsMatch(mailAddress, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        // ----- Register Button Click -----
        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            string email = txt_email.Text;
            string uname = txt_username.Text;
            string pass = txt_password.Password;
            string cpass = txt_confirm_password.Password;
            int ootp= Convert.ToInt32( txtboxOtp.Text);

            // ----- Validate Input -----
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(uname) ||
                string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(cpass) || string.IsNullOrWhiteSpace(Convert.ToString(ootp))) 
            {
                ShowError("Fill every box");
                return;
            }

            if(ootp<1000 && ootp > 10000)
            {
                ShowError("Otp must be of 4 digits");
                return;
            }

            if (!EmailValidity(email))
            {
                ShowError("Enter valid email");
                return;
            }

            if (pass != cpass)
            {
                ShowError("Passwords don't match");
                return;
            }
            if (ootp!=otp)
            {
                ShowError("OTP doesn't match");
                return;
            }


            // ----- Register User -----
            try
            {
                using (var context = new MiniTubeContext())
                {
                    User? existingUser = context.Users.FirstOrDefault(x => x.Email == email);
                    if (existingUser == null)
                    {
                        User user = new User
                        {
                            Email = email,
                            Username = uname,
                            Password = pass,
                            Role = "Viewer"
                        };

                        context.Users.Add(user);
                        context.SaveChanges();

                        LoginViewIn loginViewIn = new LoginViewIn("Registration Successful");
                        loginViewIn.Show();
                        this.Close();
                    }
                    else
                    {
                        ShowError("User  already exists");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Registration failed: {ex.Message}");
            }
        }
        //    private void btnotp_Click(object sender, RoutedEventArgs e)
        //    {
        //        string email = txt_email.Text;

        //        // Validate email input
        //        if (string.IsNullOrWhiteSpace(email) || !EmailValidity(email))
        //        {
        //            ShowError("Enter a valid email");
        //            return;
        //        }

        //        // Generate OTP
        //        Random random = new Random();
        //         otp = random.Next(1000, 10000);

        //        // Store OTP securely (e.g., in memory or database)
        //        Application.Current.Properties["GeneratedOTP"] = otp;

        //        // Start the countdown
        //        timer.Visibility = Visibility.Visible;
        //        text1.Visibility = Visibility.Visible;
        //        text2.Visibility = Visibility.Visible;
        //        btnotp.Visibility = Visibility.Hidden;
        //        btnotp.IsEnabled = false;
        //        StartCountdown(30);
        //        txtboxOtp.IsEnabled = true;

        //        try
        //        {
        //            // Azure Communication Services email sending
        //            string connectionString = "endpoint=https://mymailapi.unitedstates.communication.azure.com/;accesskey=6I4vdZOaSzHtAh1VagfaQf1bkBcB6iqOvgxnmQYxsULcrNtnukKbJQQJ99ALACULyCpJtr7XAAAAAZCSlZnP";
        //            var emailClient = new EmailClient(connectionString);

        //            // Create the email message
        //            var emailMessage = new EmailMessage(
        //                    senderAddress: "DoNotReply@b9249a72-1ff3-4bca-9dba-f5866d537be3.azurecomm.net",
        //                        content: new EmailContent("MiniTube Verification")
        //{
        //                    PlainText = $"Your OTP is: {otp}",
        //                    Html = $@"
        //                <html>
        //                                <head>
        //                                    <style>
        //                                        body {{
        //                                            font-family: Arial, sans-serif;
        //                                            background-color: #ffffff;
        //                                            color: #333333;
        //                                            margin: 0;
        //                                            padding: 20px;
        //                                        }}
        //                                        .container {{
        //                                            max-width: 600px;
        //                                            margin: auto;
        //                                            border: 1px solid #9a06f0;
        //                                            border-radius: 8px;
        //                                            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
        //                                            overflow: hidden;
        //                                        }}
        //                                        .header {{
        //                                            background-color: #9a06f0;
        //                                            color: white;
        //                                            padding: 20px;
        //                                            text-align: center;
        //                                        }}
        //                                        .content {{
        //                                            padding: 20px;
        //                                        }}
        //                                        .footer {{
        //                                            text-align: center;
        //                                            padding: 10px;
        //                                            font-size: 12px;
        //                                            color: #777777;
        //                                        }}
        //                                        .otp {{
        //                                            font-size: 24px;
        //                                            font-weight: bold;
        //                                            color: #9a06f0;
        //                                        }}
        //                                        .note {{
        //                                            margin-top: 20px;
        //                                            font-size: 14px;
        //                                            color: #555555;
        //                                        }}
        //                                    </style>
        //                                </head>
        //                                <body>
        //                                    <div class='container'>
        //                                        <div class='header'>
        //                                            <h1>MiniTube Verification</h1>
        //                                        </div>
        //                                        <div class='content'>
        //                                            <p>Your OTP is: <span class='otp'>{otp}</span></p>
        //                                            <p>Please use this code to verify your account. Do not share it with anyone.</p>
        //                                            <p class='note'>If you did not request this email, please ignore it.</p>
        //                                        </div>
        //                                        <div class='footer'>
        //                                            <p>&copy; {DateTime.Now.Year} MiniTube. All rights reserved.</p>
        //                                        </div>
        //                                    </div>
        //                                </body>
        //                            </html>"
        //                        },
        //                recipients: new EmailRecipients(
        //                    new List<EmailAddress> { new EmailAddress(email) }
        //                )
        //            );

        //            // Send the email
        //            EmailSendOperation emailSendOperation = emailClient.Send(
        //                WaitUntil.Completed,
        //                emailMessage
        //            );

        //            ShowError("OTP sent successfully.");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Failed to send OTP: {ex.Message}");
        //        }
        //    }

        private void btnotp_Click(object sender, RoutedEventArgs e)
        {
            string email = txt_email.Text;

            // Validate email input
            if (string.IsNullOrWhiteSpace(email) || !EmailValidity(email))
            {
                ShowError("Enter a valid email");
                return;
            }

            // Generate OTP
            Random random = new Random();
            otp = random.Next(1000, 10000);

            // Start the countdown
            timer.Visibility = Visibility.Visible;
            text1.Visibility = Visibility.Visible;
            text2.Visibility = Visibility.Visible;
            btnotp.Visibility = Visibility.Hidden;
            btnotp.IsEnabled = false;
            StartCountdown(30);
            txtboxOtp.IsEnabled = true;

            try
            {

                string from = Environment.GetEnvironmentVariable("SENDER_EMAIL") ?? throw new InvalidOperationException("SENDER_EMAIL is not set.");
                string pass = ("gybkxoaljucpabvr");

                string subject = "MiniTube Verification";
                string messageBody = $@"
            <html>
                <head>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            background-color: #ffffff;
                            color: #333333;
                            margin: 0;
                            padding: 20px;
                        }}
                        .container {{
                            max-width: 600px;
                            margin: auto;
                            border: 1px solid #9a06f0;
                            border-radius: 8px;
                            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
                            overflow: hidden;
                        }}
                        .header {{
                            background-color: #9a06f0;
                            color: white;
                            padding: 20px;
                            text-align: center;
                        }}
                        .content {{
                            padding: 20px;
                        }}
                        .footer {{
                            text-align: center;
                            padding: 10px;
                            font-size: 12px;
                            color: #777777;
                        }}
                        .otp {{
                            font-size: 24px;
                            font-weight: bold;
                            color: #9a06f0;
                        }}
                        .note {{
                            margin-top: 20px;
                            font-size: 14px;
                            color: #555555;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>MiniTube Verification</h1>
                        </div>
                        <div class='content'>
                            <p>Your OTP is: <span class='otp'>{otp}</span></p>
                            <p>Please use this code to verify your account. Do not share it with anyone.</p>
                            <p class='note'>If you did not request this email, please ignore it.</p>
                        </div>
                        <div class='footer'>
                            <p>&copy; {DateTime.Now.Year} MiniTube. All rights reserved.</p>
                        </div>
                    </div>
                </body>
            </html>";

                MailMessage message = new MailMessage();
                message.To.Add(email);
                if (string.IsNullOrEmpty(from))
                {
                    throw new InvalidOperationException("Sender email cannot be null or empty.");
                }
                message.From = new MailAddress(from, "Don't Reply");
                message.Subject = subject;
                message.Body = messageBody;
                message.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(from, pass),
                    EnableSsl = true
                };

                smtp.Send(message);
                ShowError("OTP sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send OTP: {ex.Message}");
            }
        }

        private void StartCountdown(int seconds)
        {
            _countdown = seconds;
            timer.Text = _countdown.ToString("D2"); // Display initial countdown time

            // Initialize and start the DispatcherTimer
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1); // Tick every second
            _timer.Tick += Timer_Tick; // Event handler for timer ticks
            _timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            _countdown--;

            // Update the countdown display
            timer.Text = _countdown.ToString("D2");

            if (_countdown <= 0)
            {
                _timer.Stop();  // Stop the timer

                btnotp.IsEnabled = true;
                btnotp.Visibility = Visibility.Visible;// Optionally, enable "Send OTP" button again if needed
            }
        }
        // ----- Show Error Message -----
        private void ShowError(string message)
        {
            txt_error.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
            txt_error.TextAlignment = TextAlignment.Center;
            txt_error.Text = message;
        }

        private void txtboxOtp_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}