package mono.com.wdullaer.materialdatetimepicker.time;


public class TimePickerDialog_OnTimeSetListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.wdullaer.materialdatetimepicker.time.TimePickerDialog.OnTimeSetListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTimeSet:(Lcom/wdullaer/materialdatetimepicker/time/TimePickerDialog;III)V:GetOnTimeSet_Lcom_wdullaer_materialdatetimepicker_time_TimePickerDialog_IIIHandler:Wdullaer.MaterialDateTimePicker.Time.TimePickerDialog/IOnTimeSetListenerInvoker, MaterialDateTimePicker\n" +
			"";
		mono.android.Runtime.register ("Wdullaer.MaterialDateTimePicker.Time.TimePickerDialog+IOnTimeSetListenerImplementor, MaterialDateTimePicker", TimePickerDialog_OnTimeSetListenerImplementor.class, __md_methods);
	}


	public TimePickerDialog_OnTimeSetListenerImplementor ()
	{
		super ();
		if (getClass () == TimePickerDialog_OnTimeSetListenerImplementor.class)
			mono.android.TypeManager.Activate ("Wdullaer.MaterialDateTimePicker.Time.TimePickerDialog+IOnTimeSetListenerImplementor, MaterialDateTimePicker", "", this, new java.lang.Object[] {  });
	}


	public void onTimeSet (com.wdullaer.materialdatetimepicker.time.TimePickerDialog p0, int p1, int p2, int p3)
	{
		n_onTimeSet (p0, p1, p2, p3);
	}

	private native void n_onTimeSet (com.wdullaer.materialdatetimepicker.time.TimePickerDialog p0, int p1, int p2, int p3);

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
