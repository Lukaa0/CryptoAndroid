package md50d6b00770e125eb499194054ca0ec587;


public class MyAnimatorListenerAdapter
	extends android.animation.AnimatorListenerAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnimationStart:(Landroid/animation/Animator;)V:GetOnAnimationStart_Landroid_animation_Animator_Handler\n" +
			"n_onAnimationEnd:(Landroid/animation/Animator;)V:GetOnAnimationEnd_Landroid_animation_Animator_Handler\n" +
			"n_onAnimationCancel:(Landroid/animation/Animator;)V:GetOnAnimationCancel_Landroid_animation_Animator_Handler\n" +
			"";
		mono.android.Runtime.register ("BR.Com.Mauker.MaterialSearchViewLib.Listeners.MyAnimatorListenerAdapter, MaterialSearchView", MyAnimatorListenerAdapter.class, __md_methods);
	}


	public MyAnimatorListenerAdapter ()
	{
		super ();
		if (getClass () == MyAnimatorListenerAdapter.class)
			mono.android.TypeManager.Activate ("BR.Com.Mauker.MaterialSearchViewLib.Listeners.MyAnimatorListenerAdapter, MaterialSearchView", "", this, new java.lang.Object[] {  });
	}


	public void onAnimationStart (android.animation.Animator p0)
	{
		n_onAnimationStart (p0);
	}

	private native void n_onAnimationStart (android.animation.Animator p0);


	public void onAnimationEnd (android.animation.Animator p0)
	{
		n_onAnimationEnd (p0);
	}

	private native void n_onAnimationEnd (android.animation.Animator p0);


	public void onAnimationCancel (android.animation.Animator p0)
	{
		n_onAnimationCancel (p0);
	}

	private native void n_onAnimationCancel (android.animation.Animator p0);

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
