package mono.com.orhanobut.dialogplus;


public class OnHolderListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.orhanobut.dialogplus.OnHolderListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onItemClick:(Ljava/lang/Object;Landroid/view/View;I)V:GetOnItemClick_Ljava_lang_Object_Landroid_view_View_IHandler:Com.Orhanobut.Dialogplus.IOnHolderListenerInvoker, Naxam.DialogPlus.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Orhanobut.Dialogplus.IOnHolderListenerImplementor, Naxam.DialogPlus.Droid", OnHolderListenerImplementor.class, __md_methods);
	}


	public OnHolderListenerImplementor ()
	{
		super ();
		if (getClass () == OnHolderListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Orhanobut.Dialogplus.IOnHolderListenerImplementor, Naxam.DialogPlus.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onItemClick (java.lang.Object p0, android.view.View p1, int p2)
	{
		n_onItemClick (p0, p1, p2);
	}

	private native void n_onItemClick (java.lang.Object p0, android.view.View p1, int p2);

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
