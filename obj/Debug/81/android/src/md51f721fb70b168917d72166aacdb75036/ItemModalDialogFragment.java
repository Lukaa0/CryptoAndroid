package md51f721fb70b168917d72166aacdb75036;


public class ItemModalDialogFragment
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.squareup.picasso.Callback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onError:()V:GetOnErrorHandler:Square.Picasso.ICallbackInvoker, Square.Picasso\n" +
			"n_onSuccess:()V:GetOnSuccessHandler:Square.Picasso.ICallbackInvoker, Square.Picasso\n" +
			"";
		mono.android.Runtime.register ("HandyCrypto.Fragments.ItemModalDialogFragment, HC", ItemModalDialogFragment.class, __md_methods);
	}


	public ItemModalDialogFragment ()
	{
		super ();
		if (getClass () == ItemModalDialogFragment.class)
			mono.android.TypeManager.Activate ("HandyCrypto.Fragments.ItemModalDialogFragment, HC", "", this, new java.lang.Object[] {  });
	}


	public void onError ()
	{
		n_onError ();
	}

	private native void n_onError ();


	public void onSuccess ()
	{
		n_onSuccess ();
	}

	private native void n_onSuccess ();

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
