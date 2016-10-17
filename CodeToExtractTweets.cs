using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweetinvi.Streams;
using System.IO;
using System.Windows.Forms;
using System.Web;
using WindowsFormsApplication1;
using System.Threading;

namespace WindowsFormsApplication1
{
  public class Twitter
    {
        string AccessToken = "476949496-baVg4dPfAPpdUbYNhpgKuSFcFKWP7MeeCjYjk3Ar";
        string AccessSecret = "dyZN67l7QDojScX6Wuoa5vKQITpFAGYM3kknuwoIouCc0";
        string Cosnumerkey = "6AiWhBYAJaCmdyMlmSiQFgkM4";
        string ConsumerSecret = "m1DUOCFwxxdGSRR6WH0MTI7TvA3tmYjxjzENZW8ak9MEMYNeHg";
        FilteredStream stream = null;
        int CounterVariable = 0;
        string FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Tweets.txt");
        ToolStripLabel ToolLabel = null;

        public TwitterCredentials GetCredentials
        {

            get
            {
                try
                {
                    TwitterCredentials objCred = new TwitterCredentials(Cosnumerkey, ConsumerSecret, AccessToken, AccessSecret);
                    return objCred;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                
            }
                      
        }

        public void SetCredentials()
        {
            try
            {
                Auth.SetCredentials(GetCredentials);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public String getUserName()
        {
            string UserName = string.Empty;
            try
            {
                var user = User.GetLoggedUser(GetCredentials);
                UserName = user.ScreenName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UserName;
        }

        public void GetTweets(string Search_Variable)
        {
            try
            {
             stream = (FilteredStream)Tweetinvi.Stream.CreateFilteredStream(GetCredentials);
             stream.AddTrack(Search_Variable);
               stream.JsonObjectReceived += Stream_JsonObjectReceived;
             stream.StartStreamMatchingAnyCondition();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Stream_JsonObjectReceived(object sender, Tweetinvi.Core.Events.EventArguments.JsonObjectEventArgs e)
        {
            try
            {
                CounterVariable++;
                string JsonData = e.Json.ToString();
                WritetoFile(JsonData);
                SetCounterControl.Text = "Tweet Count: " + CounterVariable.ToString();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        public void stopStream()
        {
            try
            {
                stream.StopStream();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int GetTweetCount
        {
            
            get
            {
                try
                {
                    return CounterVariable;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }

        private void WritetoFile(string Data)
        {
            try
            {
               
                if (!File.Exists(FileName))
                {
                    FileStream StreamData = File.Create(FileName);
                    StreamData.Close();
                }
                StreamWriter Stream = new StreamWriter(FileName, true);
                Stream.WriteLine(Data);
                Stream.WriteLine(Environment.NewLine);
                Stream.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ToolStripLabel SetCounterControl
        {
           
            get
            {
                
                try
                {
                    return ToolLabel;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            set
            {
                try
                {
                    ToolLabel = value;
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
        }
       
    }
}
