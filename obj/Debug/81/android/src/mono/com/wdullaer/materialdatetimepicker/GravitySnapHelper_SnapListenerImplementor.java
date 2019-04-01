package mono.com.wdullaer.materialdatetimepicker;


public class GravitySnapHelper_SnapListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.wdullaer.materialdatetimepicker.GravitySnapHelper.SnapListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSnap:(I)V:GetOnSnap_IHandler:Wdullaer.MaterialDateTimePicker.GravitySnapHelper/ISnapListenerInvoker, MaterialDateTimePicker\n" +
			"";
		mono.android.Runtime.register ("Wdullaer.MaterialDateTimePicker.GravitySnapHelper+ISnapListenerImplementor, MaterialDateTimePicker", GravitySnapHelper_SnapListenerImplementor.class, __md_methods);
	}


	public GravitySnapHelper_SnapListenerImplementor ()
	{
		super ();
		if (getClass () == GravitySnapHelper_SnapListenerImplementor.class)
			mono.android.TypeManager.Activate ("Wdullaer.MaterialDateTimePicker.GravitySnapHelper+ISnapListenerImplementor, MaterialDateTimePicker", "", this, new java.lang.Object[] {  });
	}


	public void onSnap (int p0)
	{
		n_onSnap (p0);
	}

	private native void n_onSnap (int p0);

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
