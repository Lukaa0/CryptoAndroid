package mono.com.wdullaer.materialdatetimepicker.date;


public class DayPickerView_OnPageListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.wdullaer.materialdatetimepicker.date.DayPickerView.OnPageListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPageChanged:(I)V:GetOnPageChanged_IHandler:Wdullaer.MaterialDateTimePicker.Date.DayPickerView/IOnPageListenerInvoker, MaterialDateTimePicker\n" +
			"";
		mono.android.Runtime.register ("Wdullaer.MaterialDateTimePicker.Date.DayPickerView+IOnPageListenerImplementor, MaterialDateTimePicker", DayPickerView_OnPageListenerImplementor.class, __md_methods);
	}


	public DayPickerView_OnPageListenerImplementor ()
	{
		super ();
		if (getClass () == DayPickerView_OnPageListenerImplementor.class)
			mono.android.TypeManager.Activate ("Wdullaer.MaterialDateTimePicker.Date.DayPickerView+IOnPageListenerImplementor, MaterialDateTimePicker", "", this, new java.lang.Object[] {  });
	}


	public void onPageChanged (int p0)
	{
		n_onPageChanged (p0);
	}

	private native void n_onPageChanged (int p0);

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
