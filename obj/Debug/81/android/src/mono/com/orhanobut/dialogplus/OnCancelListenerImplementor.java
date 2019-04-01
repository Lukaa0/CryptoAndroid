package mono.com.orhanobut.dialogplus;


public class OnCancelListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.orhanobut.dialogplus.OnCancelListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCancel:(Lcom/orhanobut/dialogplus/DialogPlus;)V:GetOnCancel_Lcom_orhanobut_dialogplus_DialogPlus_Handler:Com.Orhanobut.Dialogplus.IOnCancelListenerInvoker, Naxam.DialogPlus.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Orhanobut.Dialogplus.IOnCancelListenerImplementor, Naxam.DialogPlus.Droid", OnCancelListenerImplementor.class, __md_methods);
	}


	public OnCancelListenerImplementor ()
	{
		super ();
		if (getClass () == OnCancelListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Orhanobut.Dialogplus.IOnCancelListenerImplementor, Naxam.DialogPlus.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onCancel (com.orhanobut.dialogplus.DialogPlus p0)
	{
		n_onCancel (p0);
	}

	private native void n_onCancel (com.orhanobut.dialogplus.DialogPlus p0);

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
