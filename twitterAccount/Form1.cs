
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TweetSharp;
using TweetSharp.Model;




namespace twitterAccount
{
    public partial class Form1 : Form
    {
        TwitterService servis;
        public Form1()
        {
            
            InitializeComponent();
            
            servis = new TwitterService("dTMK6m1S5ESaAYOkD7uO01Way", "DSRXujpG26GIbttWc0Zxc4zUA6hyWeo04Ik3P3dMabHN9GDQXp", "609285151-2YteSBo7xkv1PoGGQlukfMH1yi9J3QL3adYKJbbV", "mv1gUKpT66dCQBcWAI0itFKYYdjNU1B2kRubqx4psWoGE");
            //var requesttoken = servis.GetRequestToken();
            //var uri = servis.GetAuthorizationUri(requesttoken);
            //Uri uri = servis.GetAuthenticationUrl(requesttoken);
            //Process.Start(uri.ToString());
            //VerifyCredentialsOptions option = new VerifyCredentialsOptions();
            //TwitterUser user = servis.VerifyCredentials(option);
            //var access = servis.GetAccessToken(requesttoken);
            //OAuthAccessToken accessToken = servis.GetAccessToken(requesttoken, "aEFizII0hIvnqJd1P99WjjBqoab1Mf5y");


        }





        private void Form1_Load(object sender, EventArgs e)
        {
        }

       



        private void button1_Click(object sender, EventArgs e)
        {
            var tweetat = servis.SendTweet(new SendTweetOptions() { Status = richTextBox1.Text });
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var tweetal = servis.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions { Count = 5 });
            foreach (var tweet in tweetal)
            {
                listBox1.Items.Add(tweet.User.Name + " : " + tweet.Text);
                listBox5.Items.Add(tweet.Id);
            }
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox5.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var tweetal = servis.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions { Count = 5 });
            foreach (var tweet in tweetal)
            {
                listBox1.Items.Add(tweet.User.Name + " : " + tweet.Text);
                listBox5.Items.Add(tweet.Id);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            listBox5.SelectedIndex = listBox1.SelectedIndex;
  

            var fav = servis.FavoriteTweet(new FavoriteTweetOptions() { Id = long.Parse(listBox5.SelectedItem.ToString()) });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox5.SelectedIndex = listBox1.SelectedIndex;


            var retweet = servis.Retweet(new RetweetOptions() { Id = long.Parse(listBox5.SelectedItem.ToString()) });
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var search = servis.Search(new SearchOptions() { Q = richTextBox1.Text });
            foreach (var tweet in search.Statuses)
            {
                listBox1.Items.Add(tweet.User.Name + " : " + tweet.Text);
                listBox5.Items.Add(tweet.Id);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var getFav = servis.ListFavoriteTweets(new ListFavoriteTweetsOptions { Count = 5 });
            foreach (var tweet in getFav)
            {
                listBox2.Items.Add(tweet.User.Name + " : " + tweet.Text);
                
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var getRet = servis.ListRetweetsOfMyTweets(new ListRetweetsOfMyTweetsOptions { Count = 5 });
            foreach (var tweet in getRet)
            {
                listBox3.Items.Add(tweet.User.Name + " : " + tweet.Text);

            }
        }
    }
}
