package mono.com.orhanobut.dialogplus;


public class OnBackPressListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.orhanobut.dialogplus.OnBackPressListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onBackPressed:(Lcom/orhanobut/dialogplus/DialogPlus;)V:GetOnBackPressed_Lcom_orhanobut_dialogplus_DialogPlus_Handler:Com.Orhanobut.Dialogplus.IOnBackPressListenerInvoker, Naxam.DialogPlus.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Orhanobut.Dialogplus.IOnBackPressListenerImplementor, Naxam.DialogPlus.Droid", OnBackPressListenerImplementor.class, __md_methods);
	}


	public OnBackPressListenerImplementor ()
	{
		super ();
		if (getClass () == OnBackPressListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Orhanobut.Dialogplus.IOnBackPressListenerImplementor, Naxam.DialogPlus.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onBackPressed (com.orhanobut.dialogplus.DialogPlus p0)
	{
		n_onBackPressed (p0);
	}

	private native void n_onBackPressed (com.orhanobut.dialogplus.DialogPlus p0);

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
