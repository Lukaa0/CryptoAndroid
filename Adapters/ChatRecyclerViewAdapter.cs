using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Github.BubbleViewLib;
using HandyCrypto.Model;

namespace HandyCrypto.Adapters
{
    class ChatRecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<ChatRecyclerViewAdapterClickEventArgs> ItemClick;
        public event EventHandler<ChatRecyclerViewAdapterClickEventArgs> ItemLongClick;
        private Activity mainActivity;
        private string username;
        private List<MessageContent> lstMessage;
        private RelativeLayout.LayoutParams lp;

        public ChatRecyclerViewAdapter(Activity mainActivity, List<MessageContent> lstMessage, string userName)
        {
            this.mainActivity = mainActivity;
            this.lstMessage = lstMessage;
            lp = new RelativeLayout.LayoutParams(
                RelativeLayout.LayoutParams.WrapContent,
                RelativeLayout.LayoutParams.WrapContent);
            lp.AddRule(LayoutRules.AlignParentRight);
            username = userName;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.chat_list_item, parent, false);
            

            var vh = new ChatRecyclerViewAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }
        public void AddMessage(MessageContent messageContent)
        {
            this.lstMessage.Add(messageContent);
            NotifyItemInserted(lstMessage.Count);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = lstMessage[position];

            var holder = viewHolder as ChatRecyclerViewAdapterViewHolder;
            holder.message_user.Text = item.Username;
            holder.message_content.Text = item.Message;
            if (item.Username == HandyFirebaseClient.Instance.Authenticator.CurrentUser.DisplayName)
                holder.chatContainer.LayoutParameters = lp;
        }

        public override int ItemCount => lstMessage.Count;

        void OnClick(ChatRecyclerViewAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(ChatRecyclerViewAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }
    

    public class ChatRecyclerViewAdapterViewHolder : RecyclerView.ViewHolder
    {
       public TextView message_user, message_time, message_content;
        public RelativeLayout chatContainer;
        public ChatRecyclerViewAdapterViewHolder(View itemView, Action<ChatRecyclerViewAdapterClickEventArgs> clickListener,
                            Action<ChatRecyclerViewAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            chatContainer = ItemView.FindViewById<RelativeLayout>(Resource.Id.chat_main_container);
            message_user = ItemView.FindViewById<TextView>(Resource.Id.chat_nickname);
            message_content = ItemView.FindViewById<BubbleTextView>(Resource.Id.chat_bubbleview);
            itemView.Click += (sender, e) => clickListener(new ChatRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new ChatRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class ChatRecyclerViewAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}