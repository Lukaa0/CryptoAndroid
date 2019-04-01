package md50d6b00770e125eb499194054ca0ec587;


public class MyViewPropertyAnimatorListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.view.ViewPropertyAnimatorListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnimationCancel:(Landroid/view/View;)V:GetOnAnimationCancel_Landroid_view_View_Handler:Android.Support.V4.View.IViewPropertyAnimatorListenerInvoker, Xamarin.Android.Support.Compat\n" +
			"n_onAnimationEnd:(Landroid/view/View;)V:GetOnAnimationEnd_Landroid_view_View_Handler:Android.Support.V4.View.IViewPropertyAnimatorListenerInvoker, Xamarin.Android.Support.Compat\n" +
			"n_onAnimationStart:(Landroid/view/View;)V:GetOnAnimationStart_Landroid_view_View_Handler:Android.Support.V4.View.IViewPropertyAnimatorListenerInvoker, Xamarin.Android.Support.Compat\n" +
			"";
		mono.android.Runtime.register ("BR.Com.Mauker.MaterialSearchViewLib.Listeners.MyViewPropertyAnimatorListener, MaterialSearchView", MyViewPropertyAnimatorListener.class, __md_methods);
	}


	public MyViewPropertyAnimatorListener ()
	{
		super ();
		if (getClass () == MyViewPropertyAnimatorListener.class)
			mono.android.TypeManager.Activate ("BR.Com.Mauker.MaterialSearchViewLib.Listeners.MyViewPropertyAnimatorListener, MaterialSearchView", "", this, new java.lang.Object[] {  });
	}


	public void onAnimationCancel (android.view.View p0)
	{
		n_onAnimationCancel (p0);
	}

	private native void n_onAnimationCancel (android.view.View p0);


	public void onAnimationEnd (android.view.View p0)
	{
		n_onAnimationEnd (p0);
	}

	private native void n_onAnimationEnd (android.view.View p0);


	public void onAnimationStart (android.view.View p0)
	{
		n_onAnimationStart (p0);
	}

	private native void n_onAnimationStart (android.view.View p0);

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
