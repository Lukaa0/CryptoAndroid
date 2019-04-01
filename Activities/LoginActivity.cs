using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using HandyCrypto.DataHelper;
using HandyCrypto.Model;

namespace HandyCrypto.Activities
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        
        List<User> users;
        User user;
        Button LoginBtn;
        Button RegisterBtn;
        EditText usernameTxt;
        EditText passTxt;
        private DataHelper<Wallet> db;

        protected  override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.LoginPage);
            path = Path.Combine(path, "crypto.db");
            db = new DataHelper<Wallet>();
            db.createDatabase();
            users = new List<User>();
           // users = await db.selectUsers();
            FindViews();
            RegisterBtn.Click += RegisterBtn_Click;
            LoginBtn.Click += LoginBtn_Click;


        }
        private void FindViews()
        {
            RegisterBtn = FindViewById<Button>(Resource.Id.regBtn);
            usernameTxt = FindViewById<EditText>(Resource.Id.nameTxt);
            passTxt = FindViewById<EditText>(Resource.Id.passTxt);
            LoginBtn = FindViewById<Button>(Resource.Id.loginBtn);
        }
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (users.Exists(x => x.Username == usernameTxt.Text && x.Password==passTxt.Text))
            {
                Toast.MakeText(this, "Login Successful", ToastLength.Long).Show();
                Intent intent = new Intent(this, typeof(MainActivity));
                this.StartActivity(intent);
                this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
            }
            else
                Toast.MakeText(this, "Invalid login", ToastLength.Long).Show();

        }

        private  void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (users.Any(x => x.Username == usernameTxt.Text))
            {
                Toast.MakeText(this, "Username already exists", ToastLength.Long).Show();
            }
            else
            {
                user =  new User(usernameTxt.Text, passTxt.Text);
                //await db.insertUpdateDataAsync(user);
                users.Add(user);
                Toast.MakeText(this, "Registration is successful", ToastLength.Long).Show();

            }
        }
    }
}