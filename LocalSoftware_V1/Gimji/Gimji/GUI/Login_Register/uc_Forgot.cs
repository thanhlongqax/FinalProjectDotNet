using Azure.Identity;
using Gimji.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Login_Register
{
    public partial class uc_Forgot : UserControl
    {
        String htmlBody = "";
        public event EventHandler btn_forgotClick;
        public event EventHandler btn_forgotBack;
        public uc_Forgot()
        {
            InitializeComponent();
        }

        private bool ValidateGmail(string email)
        {
            string pattern = @"^\w+([-+.']\w+)*@(gmail\.com|example\.com)$"; // Regular expression pattern for Gmail address
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }
        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_gmail.Text))
            {
                MessageBox.Show("Vui lòng nhập gmail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (ValidateGmail(txt_gmail.Text))
            {
                // Your code for handling a valid Gmail address goes here

                ForgotPasswordBLL forgotPasswordBLL = new ForgotPasswordBLL();
                String userName_Password = forgotPasswordBLL.checkGmailBLL(txt_gmail.Text);
                if(userName_Password != null)
                {
                    string[] parts = userName_Password.Split('_');
                    // Access the separated parts
                    string username = parts[0]; // Contains the username
                    string password = parts[1]; // Contains the password
                    try
                    {
                        string senderEmail = "vandinhdung2003@gmail.com"; // Your Gmail address
                        string Password = "aopm geak txdz xvhg"; // Your Gmail password

                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress(senderEmail);
                        //mail.To.Add(txt_gmail.Text); // Email address of the recipient
                        mail.To.Add(txt_gmail.Text);
                        mail.Subject = "Account Information"; // Email subject
                        mail.Body = HtmlBody(username,password); // Email body
                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential(senderEmail, Password);
                        smtp.EnableSsl = true;

                        smtp.Send(mail);

                        MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        onSuccesfullForgot(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to send email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                
            }
            else
            {
                // Handle the case when the entered email is not a valid Gmail address
                MessageBox.Show("Vui lòng nhập gmail phù hợp", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
 

        }

        public void onSuccesfullForgot(object sender, EventArgs e)
        {
            btn_forgotClick?.Invoke(this, e); 
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            btn_forgotBack?.Invoke(this, e);
        }

        public string HtmlBody(String username,String password)
        {
            htmlBody = @"<html>
            <head>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <style>
                    body {
                        font-family: Arial, sans-serif;
                        margin: 0;
                        padding: 0;
                        background-color: #f4f4f4; /* Background color */
                    }
                    .container {
                        max-width: 600px;
                        margin: 20px auto; /* Add some margin from the top */
                        background-color: #fff;
                        padding: 20px;
                        border-radius: 8px;
                        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                    }
                    h1 {
                        text-align: center;
                        color: #333;
                    }
                    p {
                        color: #555;
                        line-height: 1.5; /* Adjust line spacing */
                    }
                    .email-img {
                        display: block;
                        margin: 20px auto;
                        width: 80%;
                        height: auto;
                        max-width: 80%;
                    }
                    .contact {
                        font-style: italic;
                        text-align: center;
                        margin-top: 30px;
                    }
                    .signature {
                        text-align: center;
                        margin-top: 20px;
                        font-size: 14px;
                    }
                </style>
            </head>
            <body>
                <div class='container'>
                    <h1>Welcome!</h1>
                    <p>Hello,</p>
                    <p>Thank you for signing up. Here are your account details:</p>
                    <img class='email-img' src='https://gimji.vn/webs_image/uploads/website/e87f904f-22a8-43ea-b96d-1b77a601ba8b.jpeg' alt='Embedded Image'>
                    <p><strong>Username:</strong> " + username + @"</p>
                    <p><strong>Password:</strong> " + password + @"</p>
                    <p class='contact'>For any assistance, feel free to contact us.</p>
                    <p class='signature'>Regards,<br>Gimji Restaurant</p>
                </div>
            </body>
            </html>";
            return htmlBody;
        }
        
    }
}
