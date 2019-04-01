package mono.com.orhanobut.dialogplus;


public class OnDismissListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.orhanobut.dialogplus.OnDismissListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDismiss:(Lcom/orhanobut/dialogplus/DialogPlus;)V:GetOnDismiss_Lcom_orhanobut_dialogplus_DialogPlus_Handler:Com.Orhanobut.Dialogplus.IOnDismissListenerInvoker, Naxam.DialogPlus.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Orhanobut.Dialogplus.IOnDismissListenerImplementor, Naxam.DialogPlus.Droid", OnDismissListenerImplementor.class, __md_methods);
	}


	public OnDismissListenerImplementor ()
	{
		super ();
		if (getClass () == OnDismissListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Orhanobut.Dialogplus.IOnDismissListenerImplementor, Naxam.DialogPlus.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onDismiss (com.orhanobut.dialogplus.DialogPlus p0)
	{
		n_onDismiss (p0);
	}

	private native void n_onDismiss (com.orhanobut.dialogplus.DialogPlus p0);

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
