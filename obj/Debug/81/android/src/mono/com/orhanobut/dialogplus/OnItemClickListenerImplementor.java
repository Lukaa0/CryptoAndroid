package mono.com.orhanobut.dialogplus;


public class OnItemClickListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.orhanobut.dialogplus.OnItemClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onItemClick:(Lcom/orhanobut/dialogplus/DialogPlus;Ljava/lang/Object;Landroid/view/View;I)V:GetOnItemClick_Lcom_orhanobut_dialogplus_DialogPlus_Ljava_lang_Object_Landroid_view_View_IHandler:Com.Orhanobut.Dialogplus.IOnItemClickListenerInvoker, Naxam.DialogPlus.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Orhanobut.Dialogplus.IOnItemClickListenerImplementor, Naxam.DialogPlus.Droid", OnItemClickListenerImplementor.class, __md_methods);
	}


	public OnItemClickListenerImplementor ()
	{
		super ();
		if (getClass () == OnItemClickListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Orhanobut.Dialogplus.IOnItemClickListenerImplementor, Naxam.DialogPlus.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onItemClick (com.orhanobut.dialogplus.DialogPlus p0, java.lang.Object p1, android.view.View p2, int p3)
	{
		n_onItemClick (p0, p1, p2, p3);
	}

	private native void n_onItemClick (com.orhanobut.dialogplus.DialogPlus p0, java.lang.Object p1, android.view.View p2, int p3);

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
