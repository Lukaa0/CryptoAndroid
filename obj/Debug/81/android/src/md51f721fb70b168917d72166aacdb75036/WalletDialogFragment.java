package md51f721fb70b168917d72166aacdb75036;


public class WalletDialogFragment
	extends android.app.DialogFragment
	implements
		mono.android.IGCUserPeer,
		com.wdullaer.materialdatetimepicker.date.DatePickerDialog.OnDateSetListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_onDateSet:(Lcom/wdullaer/materialdatetimepicker/date/DatePickerDialog;III)V:GetOnDateSet_Lcom_wdullaer_materialdatetimepicker_date_DatePickerDialog_IIIHandler:Wdullaer.MaterialDateTimePicker.Date.DatePickerDialog/IOnDateSetListenerInvoker, MaterialDateTimePicker\n" +
			"";
		mono.android.Runtime.register ("HandyCrypto.Fragments.WalletDialogFragment, HC", WalletDialogFragment.class, __md_methods);
	}


	public WalletDialogFragment ()
	{
		super ();
		if (getClass () == WalletDialogFragment.class)
			mono.android.TypeManager.Activate ("HandyCrypto.Fragments.WalletDialogFragment, HC", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public void onDateSet (com.wdullaer.materialdatetimepicker.date.DatePickerDialog p0, int p1, int p2, int p3)
	{
		n_onDateSet (p0, p1, p2, p3);
	}

	private native void n_onDateSet (com.wdullaer.materialdatetimepicker.date.DatePickerDialog p0, int p1, int p2, int p3);

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
