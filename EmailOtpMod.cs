using System.Text.RegularExpressions;

namespace EmailOtpModule
{
    public class EmailOtpMod
    {
        private string _otp;
        private int attempts;

        public EmailOtpMod()
        {
            _otp = string.Empty;
        }

        public string GenerateOtpEmailAsync(string userEmail)
        {
            // Assumes valid email addresses contain either one of these strings
            if (userEmail.Contains(".dso.org.sg") || userEmail.Contains("@dso.org.sg"))
            {
                // continue;
            }
            else
            {
                return StatusCodes.EmailInvalid;
            }
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            if (!Regex.IsMatch(userEmail, emailPattern))
            {
                return StatusCodes.EmailInvalid;
            }

            _otp = GenerateOtp();

            string emailBody = $"Your OTP Code is {_otp}. The code is valid for 1 minute";

            // Assumes SendEmail is working as expected
            string emailStatus = SendEmail(userEmail, emailBody);


            return emailStatus;
        }

        // SendEmail stub
        public string SendEmail(string emailAddress, string emailBody)
        {
            return StatusCodes.EmailOk;
        }

        public string CheckOtp(TextReader input)
        {
            attempts = 0;

            var timeoutTimer = new System.Timers.Timer(60000);
            timeoutTimer.Elapsed += (sender, e) => { timeoutTimer.Stop(); };
            timeoutTimer.Start();

            while (attempts < 10 && timeoutTimer.Enabled)
            {
                string userOtp = input.ReadOtp();

                if (userOtp == _otp)
                {
                    timeoutTimer.Stop();
                    return StatusCodes.OtpOk;
                }

                attempts++;
            }

            return timeoutTimer.Enabled ? StatusCodes.OtpFail : StatusCodes.OtpTimeout;
        }

        protected string GenerateOtp()
        {
            string characters = "1234567890";
            string otp = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }
    }
}