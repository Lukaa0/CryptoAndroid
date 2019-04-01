using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Clans.Fab;
using Com.Orhanobut.Dialogplus;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using HandyCrypto.Adapters;
using HandyCrypto.Model;

namespace HandyCrypto.Activities
{
    [Activity(Label = "BroActivity")]
    public class ChatActivity : AppCompatActivity,IValueEventListener
    {
        private List<MessageContent> lstMessage = new List<MessageContent>();
        private RecyclerView lstChat;
        private EditText edtChat;
        private Button fab;
        private DialogPlus dialog;
        private ChatRecyclerViewAdapter adapter;
        private TextView usernameTxt;
        private Button confirmBtn;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.chat_main_layout);

            if (HandyFirebaseClient.Instance.Authenticator.CurrentUser == null)
            {
                var view = LayoutInflater.From(this).Inflate(Resource.Layout.chat_input_dialog, null);
                dialog = DialogPlus.NewDialog(this).SetContentHolder(new ViewHolder(view))
                    .SetGravity((int) GravityFlags.Center)
                    .SetExpanded(true).SetCancelable(false)
                    .SetContentWidth(ViewGroup.LayoutParams.MatchParent)
                    .SetContentHeight(ViewGroup.LayoutParams.MatchParent).Create();
                dialog.Show();
                HandleNicknameDialog(view, dialog);
            }
            else
            {
                NextPhase();
            }


        }

        private void NextPhase()
        {
            HandyFirebaseClient.Instance.FirebaseDatabase.GetReference("test").AddValueEventListener(this);
            fab = FindViewById<Button>(Resource.Id.fabulous);
            edtChat = FindViewById<EditText>(Resource.Id.input);
            lstChat = FindViewById<RecyclerView>(Resource.Id.list_of_messages);
            adapter = new ChatRecyclerViewAdapter(this, lstMessage,
                "");
            lstChat.SetLayoutManager(new LinearLayoutManager(this));

            fab.Click += delegate { PostMessage(); };
            DisplayChatMessage();
        }

        private void HandleNicknameDialog(View view,DialogPlus dialog)
        {
             usernameTxt = view.FindViewById<TextView>(Resource.Id.username_edittext);
            confirmBtn = view.FindViewById<Button>(Resource.Id.chat_dialog_confirm_button);
            confirmBtn.Click += ConfirmBtn_Click;
            

                
            
        }

        private async void ConfirmBtn_Click(object sender, EventArgs e)
        {
            await HandyFirebaseClient.Instance.Authenticator.SignInAnonymouslyAsync();
            UserProfileChangeRequest profile =
                new UserProfileChangeRequest.Builder().SetDisplayName(usernameTxt.Text).Build();
            await HandyFirebaseClient.Instance.Authenticator.CurrentUser.UpdateProfileAsync(profile);
            dialog.Dismiss();
            NextPhase();
        }

        private async void PostMessage()
        {
            var items = await HandyFirebaseClient.Instance.MainClient.Child("test").PostAsync(
                new MessageContent(HandyFirebaseClient.Instance.Authenticator.CurrentUser.DisplayName, edtChat.Text));
            edtChat.Text = "";

        }
        public void OnCancelled(DatabaseError error)
        {

        }

        public void OnDataChange(DataSnapshot snapshot)
        {

            MessageContent model = new MessageContent();
            var obj = snapshot.Children;

            foreach (DataSnapshot snapshotChild in obj.ToEnumerable())
            {
                if (snapshotChild.GetValue(true) == null) continue;

                model.Message = snapshotChild.Child("Message")?.GetValue(true)?.ToString();
                model.Username = snapshotChild.Child("Username")?.GetValue(true)?.ToString();

            }

            this.adapter.AddMessage(model);
        }

        private async void DisplayChatMessage()
        {
            lstMessage.Clear();

            var items = await HandyFirebaseClient.Instance.MainClient.Child("test").OrderByKey().LimitToLast(15)
                .OnceAsync<MessageContent>();
            
            foreach (var item in items)
                adapter.AddMessage(item.Object);
             
            lstChat.SetAdapter(adapter);
        }
    }
    }
