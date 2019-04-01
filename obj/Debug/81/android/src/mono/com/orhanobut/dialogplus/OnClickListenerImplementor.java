package mono.com.orhanobut.dialogplus;


public class OnClickListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.orhanobut.dialogplus.OnClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onClick:(Lcom/orhanobut/dialogplus/DialogPlus;Landroid/view/View;)V:GetOnClick_Lcom_orhanobut_dialogplus_DialogPlus_Landroid_view_View_Handler:Com.Orhanobut.Dialogplus.IOnClickListenerInvoker, Naxam.DialogPlus.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Orhanobut.Dialogplus.IOnClickListenerImplementor, Naxam.DialogPlus.Droid", OnClickListenerImplementor.class, __md_methods);
	}


	public OnClickListenerImplementor ()
	{
		super ();
		if (getClass () == OnClickListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Orhanobut.Dialogplus.IOnClickListenerImplementor, Naxam.DialogPlus.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onClick (com.orhanobut.dialogplus.DialogPlus p0, android.view.View p1)
	{
		n_onClick (p0, p1);
	}

	private native void n_onClick (com.orhanobut.dialogplus.DialogPlus p0, android.view.View p1);

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
