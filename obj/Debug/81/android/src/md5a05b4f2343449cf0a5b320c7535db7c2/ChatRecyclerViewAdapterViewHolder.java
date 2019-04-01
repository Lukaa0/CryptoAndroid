package md5a05b4f2343449cf0a5b320c7535db7c2;


public class ChatRecyclerViewAdapterViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("HandyCrypto.Adapters.ChatRecyclerViewAdapterViewHolder, HC", ChatRecyclerViewAdapterViewHolder.class, __md_methods);
	}


	public ChatRecyclerViewAdapterViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == ChatRecyclerViewAdapterViewHolder.class)
			mono.android.TypeManager.Activate ("HandyCrypto.Adapters.ChatRecyclerViewAdapterViewHolder, HC", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
